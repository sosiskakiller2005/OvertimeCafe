using OvertimeCafe.Model;
using OvertimeCafe.Views.AdminViews.Pages;
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
            TablesBtn.Visibility = Visibility.Collapsed;
            AllOrdersBtn.Visibility = Visibility.Visible;
        }
        private void TablesBtn_Click(object sender, RoutedEventArgs e)
        {
            TablesBtn.Visibility = Visibility.Collapsed;
            AllOrdersBtn.Visibility = Visibility.Visible;
            TablesPage tablesPage = new TablesPage();
            MainFrame.Navigate(tablesPage);
        }

        private void StaffBtn_Click(object sender, RoutedEventArgs e)
        {
            StaffPage staffPage = new StaffPage();
            MainFrame.Navigate(staffPage);
        }

        private void ShiftBtn_Click(object sender, RoutedEventArgs e)
        {
            ShiftPage shiftPage = new ShiftPage();
            MainFrame.Navigate(shiftPage);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }

        private void AllOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            TablesBtn.Visibility = Visibility.Visible;
            AllOrdersBtn.Visibility = Visibility.Collapsed;
            AllOrdersPage allOrdersPage = new AllOrdersPage();
            MainFrame.Navigate(allOrdersPage);
        }
    }
}
