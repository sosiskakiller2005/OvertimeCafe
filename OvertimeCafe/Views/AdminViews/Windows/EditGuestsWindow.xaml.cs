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

namespace OvertimeCafe.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditGuestsWindow.xaml
    /// </summary>
    public partial class EditGuestsWindow : Window
    {
        private OvertimeDbEntities _context = App.GetContext();
        private Model.Table _selectedTable;
        public EditGuestsWindow(Model.Table selectedTable)
        {
            InitializeComponent();
            _selectedTable = selectedTable;
            List<Guest> guests = _context.Guest.Where(g => g.TableId == selectedTable.Id).ToList();
            GuestsLB.ItemsSource = guests;
        }

        private void GuestsLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //TO DO
            //Guest selectedGuest = GuestsLB.SelectedItem as Guest;
            //if (MessageBoxHelper.Question("Удалить этого гостя?"))
            //{
            //    _context.Guest.Remove(selectedGuest);
            //    _context.SaveChanges();
            //    UpdateList();
            //    DialogResult = true;
            //}
        }

        /// <summary>
        /// Обновление листбокса.
        /// </summary>
        private void UpdateList()
        {
            GuestsLB.ItemsSource = App.GetContext().Guest.Where(g => g.Table == _selectedTable).ToList();
        }
    }
}
