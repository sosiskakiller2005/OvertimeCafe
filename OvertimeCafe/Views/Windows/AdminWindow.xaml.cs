using OvertimeCafe.Views.Pages;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            TablesPage tablesPage = new TablesPage();
            MainFrame.Navigate(tablesPage);
        }
        private void TablesBtn_Click(object sender, RoutedEventArgs e)
        {
            TablesPage tablesPage = new TablesPage();
            MainFrame.Navigate(tablesPage);
        }

        private void StaffBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShiftBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }

    }
}
