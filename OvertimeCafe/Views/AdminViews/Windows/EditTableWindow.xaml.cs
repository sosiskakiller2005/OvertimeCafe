using OvertimeCafe.AppData;
using OvertimeCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для EditTableWindow.xaml
    /// </summary>
    public partial class EditTableWindow : Window
    {
        private Model.Table _selectedTable;
        private OvertimeDbEntities _context = App.GetContext();
        public EditTableWindow(Model.Table selectedTable)
        {
            InitializeComponent();
            _selectedTable = selectedTable;
            TableNumberTb.Text = selectedTable.Number.ToString();
        }

        private void EidtBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedTable.Number = Convert.ToInt32(TableNumberTb.Text);
                _context.SaveChanges();
                DialogResult = true;
                Close();
            }
            catch (Exception)
            {
                MessageBoxHelper.Error("Введите номер столика в правильном формате.");
            }
        }

        private void DeleteBTn_Click(object sender, RoutedEventArgs e)
        {
            List<Guest> guests = _context.Guest.Where(g => g.TableId == _selectedTable.Id).ToList();
            if (guests.Count == 0)
            {
                if (MessageBoxHelper.Question("Удалить столик?"))
                {
                    _context.Table.Remove(_selectedTable);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Столик удален.");
                    DialogResult = true;
                    Close();
                }
            }
            else
            {
                MessageBoxHelper.Error("На выбранном столике есть незакрытые счета гостей. Закройте все счета за этим столиком, чтобы удалить его.");
            }
        }
    }
}
