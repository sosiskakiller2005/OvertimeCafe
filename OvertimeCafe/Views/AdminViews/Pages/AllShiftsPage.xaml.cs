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
            ShiftsLb.ItemsSource = _context.Shift.ToList();
        }

        private void ShiftsLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new AddEditShiftPage(ShiftsLb.SelectedItem as Shift));
        }

        private void NewShiftBTn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new AddEditShiftPage());
        }

        private void DeleteShiftBTn_Click(object sender, RoutedEventArgs e)
        {
            Shift selectedShift = ShiftsLb.SelectedItem as Shift;
            List<ShiftStaff> shiftStaff = _context.ShiftStaff.ToList();
            if (selectedShift != null)
            {
                if (MessageBoxHelper.Question("Удалить выбранную смену?"))
                {
                    for (int i = 0; i < shiftStaff.Count(); i++)
                    {
                        if (shiftStaff.ElementAt(i).Shift == selectedShift)
                        {
                            _context.ShiftStaff.Remove(shiftStaff.ElementAt(i));
                        }
                    }
                    _context.Shift.Remove(selectedShift);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Смена удалена.");
                    ShiftsLb.ItemsSource = _context.Shift.ToList();
                }
            }
        }
    }
}
