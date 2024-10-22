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
using Type = OvertimeCafe.Model.Type;

namespace OvertimeCafe.Views.AdminViews.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectDishWindow.xaml
    /// </summary>
    public partial class SelectDishWindow : Window
    {
        private static OvertimeDbEntities _context = App.GetContext();
        List<Type> types = _context.Type.ToList();
        List<Dish> dishes = _context.Dish.ToList();
        public SelectDishWindow()
        {
            InitializeComponent();
            DishesLb.ItemsSource = _context.Dish.ToList();

            types.Insert(0, new Type() { Name = "Все категории" });
            CategoryCmb.ItemsSource = types;
            CategoryCmb.DisplayMemberPath = "Name";
            CategoryCmb.SelectedIndex = 0;
        }

        private void DishesLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Transporter.selectedDish = DishesLb.SelectedItem as Dish;
            DialogResult = true;
            Close();
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dishes = _context.Dish.ToList();
            if (CategoryCmb.SelectedIndex == 0)
            {
                dishes = _context.Dish.ToList();
                DishesLb.ItemsSource = dishes;
            }
            else
            {
                dishes = dishes.Where(d => d.Type == CategoryCmb.SelectedItem as Type).ToList();
                DishesLb.ItemsSource = dishes;
            }
        }
    }
}
