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
using Table = OvertimeCafe.Model.Table;

namespace OvertimeCafe.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        private OvertimeDbEntities _context = App.GetContext();
        public TableWindow(Table selectedTable)
        {
            InitializeComponent();
            List<GuestDish> guestDishes = _context.GuestDish.ToList();
            GuestLB.ItemsSource = guestDishes.Where(gu => gu.Guest.TableId == selectedTable.Id).ToList();
        }
    }
}
