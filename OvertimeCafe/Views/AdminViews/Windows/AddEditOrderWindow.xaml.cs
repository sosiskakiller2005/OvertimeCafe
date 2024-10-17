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
        public AddEditOrderWindow()
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Collapsed;
            ChooseBtn.Visibility = Visibility.Visible;
        }
        public AddEditOrderWindow(GuestDish selectedOrder)
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Visible;
            ChooseBtn.Visibility = Visibility.Collapsed;
            DishGrid.DataContext = selectedOrder;
            _selectedOrder = selectedOrder;
        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
