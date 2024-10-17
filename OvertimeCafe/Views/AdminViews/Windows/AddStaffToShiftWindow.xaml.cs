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
using System.Windows.Shapes;

namespace OvertimeCafe.Views.AdminViews.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddStaffToShiftWindow.xaml
    /// </summary>
    public partial class AddStaffToShiftWindow : Window
    {
        private static OvertimeDbEntities _context = App.GetContext();
        private Shift _selectedShift;
        public AddStaffToShiftWindow(Shift selectedShift)
        {
            InitializeComponent();
            _selectedShift = selectedShift;
            StaffLb.ItemsSource = _context.Staff.ToList();
        }

        private void StaffLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShiftStaff newShiftStaff = new ShiftStaff()
            {
                Shift = _selectedShift,
                Staff = StaffLb.SelectedItem as Staff,
            };
            _context.ShiftStaff.Add(newShiftStaff);
            _context.SaveChanges();
            DialogResult = true;
            Close();
        }
    }
}
