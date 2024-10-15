using OvertimeCafe.AppData;
using OvertimeCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OvertimeCafe.Views.AdminViews.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllShiftsPage.xaml
    /// </summary>
    public partial class AllShiftsPage : Page
    {
        private static OvertimeDbEntities _context = App.GetContext();
        public AllShiftsPage()
        {
            InitializeComponent();
            ShiftsLb.ItemsSource = _context.ShiftStaff.ToList();
        }

        private void ShiftsLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new AddEditShiftPage(ShiftsLb.SelectedItem as ShiftStaff));
        }

        private void NewShiftBTn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new AddEditShiftPage());
        }
    }
}
