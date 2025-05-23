﻿using OvertimeCafe.AppData;
using OvertimeCafe.Model;
using OvertimeCafe.Views.AdminViews.Pages;
using OvertimeCafe.Views.Windows;
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
using Table = OvertimeCafe.Model.Table;

namespace OvertimeCafe.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для TablesPage.xaml
    /// </summary>
    public partial class TablesPage : Page
    {
        private static OvertimeDbEntities _context = App.GetContext();
        public TablesPage()
        {
            InitializeComponent();
            TablesLB.ItemsSource = _context.Table.ToList();
        }

        private void TablesLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Table selectedTable = TablesLB.SelectedItem as Table;
            FrameHelper.selectedFrame.Navigate(new OrdersPage(selectedTable));
        }

        /// <summary>
        /// Обновление листбокса.
        /// </summary>
        private void UpdateList()
        {
            TablesLB.ItemsSource = App.GetContext().Table.ToList();
        }
    }
}
