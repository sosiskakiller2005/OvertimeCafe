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
    /// Логика взаимодействия для AddEditShiftPage.xaml
    /// </summary>
    public partial class AddEditShiftPage : Page
    {
        private static OvertimeDbEntities _context = App.GetContext();
        private ShiftStaff _selectedShiftStaff;
        public AddEditShiftPage()
        {
            InitializeComponent();
        }
        public AddEditShiftPage(ShiftStaff selectedStaff)
        {
            InitializeComponent();
            _selectedShiftStaff = selectedStaff;
            StaffLb.ItemsSource = _context.ShiftStaff.Where(sh => sh.ShiftId == _selectedShiftStaff.Id).ToList();
            ShiftDp.SelectedDate = _selectedShiftStaff.Shift.Date;
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
