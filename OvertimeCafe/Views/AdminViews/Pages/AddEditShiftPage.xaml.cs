using OvertimeCafe.AppData;
using OvertimeCafe.Model;
using OvertimeCafe.Views.AdminViews.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private static Shift _selectedShift;
        public AddEditShiftPage()
        {
            InitializeComponent();
            _selectedShift = null;
        }
        public AddEditShiftPage(Shift selectedShift)
        {
            InitializeComponent();
            _selectedShift = selectedShift;
            StaffLb.ItemsSource = _context.ShiftStaff.Where(sh => sh.ShiftId == _selectedShift.Id).ToList();
            ShiftDp.SelectedDate = _selectedShift.Date;
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedShift != null)
            {
                AddStaffToShiftWindow addStaffToShiftWindow = new AddStaffToShiftWindow(_selectedShift);
                if (addStaffToShiftWindow.ShowDialog() == true)
                {
                    StaffLb.ItemsSource = _context.ShiftStaff.Where(sh => sh.ShiftId == _selectedShift.Id).ToList();
                }
            }
            else
            {
                if (ShiftDp.SelectedDate != null)
                {
                    Shift newShift = new Shift()
                    {
                        Date = (DateTime)ShiftDp.SelectedDate
                    };
                    _context.Shift.Add(newShift);
                    _context.SaveChanges();
                    _selectedShift = newShift;
                    AddStaffToShiftWindow addStaffToShiftWindow = new AddStaffToShiftWindow(_selectedShift);

                }
                else
                {
                    MessageBoxHelper.Error("Выберите дату смены.");
                }
            }
        }

        private void StaffLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MessageBoxHelper.Question("Удалить из смены этого сотрудника?"))
            {
                List<ShiftStaff> shiftStaff = _context.ShiftStaff.ToList();
                ShiftStaff selectedShiftStaff = shiftStaff.FirstOrDefault(ss => ss == StaffLb.SelectedItem as ShiftStaff);
                _context.ShiftStaff.Remove(selectedShiftStaff);
                StaffLb.ItemsSource = _context.ShiftStaff.Where(sh => sh.ShiftId == _selectedShift.Id).ToList();
            }
        }

        private void SaveBTn_Click(object sender, RoutedEventArgs e)
        {
            if (ShiftDp.SelectedDate != null)
            {
                if (CheckShift())
                {
                    FrameHelper.selectedFrame.Navigate(new AllShiftsPage());
                }
            }
        }

        /// <summary>
        /// Проверка на полноту смены. В каждой смене должен быть хотя бы один администратор, повар, официант и бармен.
        /// </summary>
        private static bool CheckShift()
        {
            List<ShiftStaff> shiftStaff = _context.ShiftStaff.Where(ss => ss.Shift.Id == _selectedShift.Id).ToList();
            List<Staff> staff = new List<Staff>();
            for (int i = 0; i < shiftStaff.Count; i++)
            {
                if (shiftStaff.ElementAt(i).Staff != null)
                {
                    staff.Add(shiftStaff.ElementAt(i).Staff);
                }
            }
            if (staff.Any(s => s.RoleId == 1) && staff.Any(s => s.RoleId == 2) && staff.Any(s => s.RoleId == 3) && staff.Any(s => s.RoleId == 4))
            {
                MessageBoxHelper.Information("Смена изменена.");
                _context.SaveChanges();
                return true;
            }
            else
            {
                MessageBoxHelper.Error("На смене должен быть минимум один администратор, повар, официант и бармен.");
                return false;
            }
        }
    }
}
