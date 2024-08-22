using OvertimeCafe.Model;
using OvertimeCafe.Views.Windows;
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

namespace OvertimeCafe.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        private OvertimeDbEntities _context = App.GetContext();
        public StaffPage()
        {
            InitializeComponent();
            StaffLB.ItemsSource = _context.Staff.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            EditStaffWindow editStaffWindow = new EditStaffWindow();
            editStaffWindow.ShowDialog();
            if (editStaffWindow.DialogResult == true)
            {
                UpdateList();
            }
        }

        private void StaffLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditStaffWindow editStaffWindow = new EditStaffWindow(StaffLB.SelectedItem as Staff);
            editStaffWindow.ShowDialog();
            if (editStaffWindow.DialogResult == true)
            {
                UpdateList();
            }
        }
        private void UpdateList()
        {
            StaffLB.ItemsSource = App.GetContext().Staff.ToList();
        }
    }
}
