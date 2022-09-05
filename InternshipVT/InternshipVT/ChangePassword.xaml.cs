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
using MySql.Data.MySqlClient;

namespace InternshipVT
{
    /// <summary>
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        MySqlConnection MSC = new MySqlConnection("host=127.0.0.1; user=root;password=;database=internshipdb;");

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MM = new MainMenu();
            MM.Show();
            Hide();
        }

      
        private void ChangePswrdClick_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPasswordField.Password == Properties.Settings.Default["password"].ToString())
            {
                if (Password1Field.Password == Password2Field.Password)
                {
                    string query = "UPDATE `users` SET `password`='" + Password1Field.Password + "' WHERE `email`='" + Properties.Settings.Default["login"] + "'";
                    MySqlCommand command = new MySqlCommand(query, MSC);
                    MSC.Open();
                    command.ExecuteNonQuery();
                    MSC.Close();
                    MessageBox.Show("Password succesfully changed");
                }
                else { MessageBox.Show("New password don`t match"); }

            }
            else
            {
                MessageBox.Show("Wrong current password");
            }
        }
    }
}
