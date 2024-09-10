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

namespace OvertimeCafe.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private static OvertimeDbEntities _context = App.GetContext();
        public OrdersWindow(Model.Table selectedTable)
        {
            InitializeComponent();
            GuestCmb.ItemsSource = _context.Guest.ToList();
            GuestCmb.DisplayMemberPath = "Name";
            GuestCmb.SelectedIndex = 1;
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
            
        }
    }
}
