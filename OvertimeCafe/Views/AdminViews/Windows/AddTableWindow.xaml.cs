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
    /// Логика взаимодействия для AddTableWindow.xaml
    /// </summary>
    public partial class AddTableWindow : Window
    {
        private static OvertimeDbEntities _context = App.GetContext();
        public AddTableWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Table newTable = new Model.Table()
                {
                    Number = Convert.ToInt32(TableNumberTb.Text),
                };
                _context.Table.Add(newTable);
                _context.SaveChanges();
                DialogResult = true;
            }
            catch (Exception)
            {
                MessageBoxHelper.Error("Введите номер столика в правильном формате.");
            }
        }
    }
}
