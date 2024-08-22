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
        private Table _selectedTable;
        public TableWindow(Table selectedTable)
        {
            InitializeComponent();
            _selectedTable = selectedTable;
            List<GuestDish> guestDishes = _context.GuestDish.ToList();
            try
            {
                GuestLB.ItemsSource = guestDishes.Where(gu => gu.Guest.TableId == selectedTable.Id).ToList();

            }
            catch (Exception)
            {

            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditGuestsWindow editGuestsWindow = new EditGuestsWindow(_selectedTable);
            editGuestsWindow.ShowDialog();
            if (editGuestsWindow.DialogResult == true)
            {
                UpdateList();
            }
        }
        private void UpdateList()
        {
            GuestLB.ItemsSource = App.GetContext().Guest.Where(g => g.Table == _selectedTable).ToList();
        }
    }
}
