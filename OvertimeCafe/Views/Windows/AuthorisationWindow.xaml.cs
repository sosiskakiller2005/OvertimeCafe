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
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        private static OvertimeDbEntities _context = App.GetContext();
        public AuthorisationWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorisationHelper.Authorise(LoginTb.Text, PasswordTb.Password) == true)
            {
                MessageBoxHelper.Information("Пользователь авторизован.");
            }
            else
            {
                MessageBoxHelper.Information("Ебень.");
            }
        }
    }
}
