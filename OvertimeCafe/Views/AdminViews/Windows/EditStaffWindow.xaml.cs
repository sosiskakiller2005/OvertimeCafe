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
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        private OvertimeDbEntities _context = App.GetContext();
        private Staff _selectedStaff;
        public EditStaffWindow(Staff selectedStaff)
        {
            InitializeComponent();
            _selectedStaff = selectedStaff;
            RoleCmb.ItemsSource = _context.Role.ToList();
            RoleCmb.DisplayMemberPath = "Name";
            AddBtn.Visibility = Visibility.Collapsed;
            SaveBtn.Visibility = Visibility.Visible;
            StaffGrid.DataContext = selectedStaff;
            RoleCmb.SelectedItem = selectedStaff.Role;
            PasswordTb.Password = selectedStaff.Password;
        }
        public EditStaffWindow()
        {
            InitializeComponent();
            RoleCmb.ItemsSource = _context.Role.ToList();
            RoleCmb.DisplayMemberPath = "Name";
            AddBtn.Visibility = Visibility.Visible;
            SaveBtn.Visibility = Visibility.Collapsed;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameTb.Text != string.Empty && AgeTb.Text != string.Empty && PhoneNmberTb.Text != string.Empty && LoginTb.Text != string.Empty && PasswordTb.Password != string.Empty)
                {
                    _selectedStaff.Name = NameTb.Text;
                    _selectedStaff.Age = Convert.ToInt32(AgeTb.Text);
                    _selectedStaff.PhoneNumber = PhoneNmberTb.Text;
                    _selectedStaff.Role = RoleCmb.SelectedItem as Role;
                    _selectedStaff.Login = LoginTb.Text;
                    _selectedStaff.Password = PasswordTb.Password;
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Данные о сотруднике обновлены.");
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBoxHelper.Error("Заполните все поля для ввода.");
                }
            }
            catch (Exception)
            {
                MessageBoxHelper.Error("Заполните все поля в нужном формате.");
            }
        }

        private void DeleteBTn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxHelper.Question("Удалить выбранного сотрудника?"))
            {
                List<ShiftStaff> shiftStaff = _context.ShiftStaff.ToList();
                for (int i = 0; i < shiftStaff.Count(); i++)
                {
                    if (shiftStaff.ElementAt(i).StaffId == _selectedStaff.Id)
                    {
                        _context.ShiftStaff.Remove(shiftStaff.ElementAt(i));
                    }
                }
                _context.Staff.Remove(_selectedStaff);
                _context.SaveChanges();
                MessageBoxHelper.Information("Выбранный сотрудник удален.");
                DialogResult = true;
                Close();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameTb.Text != string.Empty && AgeTb.Text != string.Empty && PhoneNmberTb.Text != string.Empty && LoginTb.Text != string.Empty && PasswordTb.Password != string.Empty)
                {
                    Staff newStaff = new Staff()
                    {
                        Name = NameTb.Text,
                        Age = Convert.ToInt32(AgeTb.Text),
                        PhoneNumber = PhoneNmberTb.Text,
                        Role = RoleCmb.SelectedItem as Role,
                        StatusId = 2,
                        Login = LoginTb.Text,
                        Password = PasswordTb.Password
                    };
                    _context.Staff.Add(newStaff);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Новый сотрудник добавлен.");
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBoxHelper.Error("Заполните все поля для ввода.");
                }
        }
            catch (Exception)
            {
                MessageBoxHelper.Error("Заполните все поля в нужном формате.");
            }
}
    }
}
