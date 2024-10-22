using OvertimeCafe.AppData;
using OvertimeCafe.Model;
using OvertimeCafe.Views.AdminViews.Windows;
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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private static OvertimeDbEntities _context = App.GetContext();
        public OrdersPage(Model.Table selectedTable)
        {
            InitializeComponent();
            GuestCmb.ItemsSource = _context.Guest.ToList();
            GuestCmb.DisplayMemberPath = "Name";
            GuestCmb.SelectedIndex = 0;
            TableTbl.Text = selectedTable.Number.ToString() + " столик";
            List<GuestDish> dishes = _context.GuestDish.Where(gd => gd.GuestId == GuestCmb.SelectedIndex + 1).ToList();
            DishesLb.ItemsSource = dishes;
        }
        private void GuestCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<GuestDish> dishes = _context.GuestDish.Where(gd => gd.GuestId == GuestCmb.SelectedIndex + 1).ToList();
            DishesLb.ItemsSource = dishes;
        }

        private void DishesLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddEditOrderWindow addEditOrderWindow = new AddEditOrderWindow(DishesLb.SelectedItem as GuestDish, GuestCmb.SelectedItem as Guest);
            addEditOrderWindow.ShowDialog();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.GoBack();
        }

        private void AddOrderBTn_Click(object sender, RoutedEventArgs e)
        {
            AddEditOrderWindow addEditOrderWindow = new AddEditOrderWindow(GuestCmb.SelectedItem as Guest);
            if (addEditOrderWindow.ShowDialog() == true)
            {
                List<GuestDish> dishes = App.GetContext().GuestDish.Where(gd => gd.GuestId == GuestCmb.SelectedIndex + 1).ToList();
                DishesLb.ItemsSource = dishes;
            }
        }
    }
}
