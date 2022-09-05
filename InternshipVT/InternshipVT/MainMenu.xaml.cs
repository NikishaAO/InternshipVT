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

namespace InternshipVT
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        
        public MainMenu()
        {
            InitializeComponent();
            CurrentUser.Content = Properties.Settings.Default["login"];
            if (Properties.Settings.Default["role"].ToString() != "university")
            {
                RegisterNewUserButton.IsEnabled = false;
                ToContacts.IsEnabled = false;
            }
        }

        private void RegisterNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterNewUser R = new RegisterNewUser();
            R.Show();
            Hide();
        }

        private void ToChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword CP = new ChangePassword();
            CP.Show();
            Hide();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["login"] = null;
            Properties.Settings.Default["password"] = null;
            Properties.Settings.Default["role"] = "null";
            Properties.Settings.Default.Save();

            MainWindow MW = new MainWindow();
            MW.Show();
            Hide();


        }

        private void ToContacts_Click(object sender, RoutedEventArgs e)
        {
            Contacts C = new Contacts();
            C.Show();
            Hide();
        }

        private void ToInternships_Click(object sender, RoutedEventArgs e)
        {
            Internships I = new Internships();
            I.Show();
            Hide();
        }
    }
}
