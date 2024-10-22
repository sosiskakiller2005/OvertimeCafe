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
using System.Windows.Shapes;

namespace OvertimeCafe.Views.AdminViews.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditOrderWindow.xaml
    /// </summary>
    public partial class AddEditOrderWindow : Window
    {
        private static OvertimeDbEntities _context = App.GetContext();
        private static GuestDish _selectedOrder;
        private static Guest _selectedGuest;
        public AddEditOrderWindow(Guest selectedGuest)
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Collapsed;
            ChooseBtn.Visibility = Visibility.Visible;
            _selectedGuest = selectedGuest;
        }
        public AddEditOrderWindow(GuestDish selectedOrder, Guest selectedGuest)
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Visible;
            ChooseBtn.Visibility = Visibility.Collapsed;
            DishGrid.DataContext = selectedOrder;
            _selectedGuest = selectedGuest;
            _selectedOrder = selectedOrder;
        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectDishWindow selectDishWindow = new SelectDishWindow();
            if (selectDishWindow.ShowDialog() == true)
            {
                GuestDish newGuestDish = new GuestDish()
                {
                    Guest = _selectedGuest,
                    Dish = Transporter.selectedDish,
                    DishStatusId = 2
                };
                _selectedOrder = newGuestDish;
                _context.GuestDish.Add(newGuestDish);
                DishGrid.DataContext = newGuestDish;
                DeleteBtn.Visibility = Visibility.Visible;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            if (MessageBoxHelper.Question("Удалить данный заказ?"))
            {
                _context.GuestDish.Remove(_selectedOrder);
                _context.SaveChanges();
                Close();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            _context.SaveChanges();
            Close();
        }
    }
}
