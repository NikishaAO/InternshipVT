using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для RegisterNewUser.xaml
    /// </summary>
    public partial class RegisterNewUser : Window
    {
        MySqlConnection MSC = new MySqlConnection("host=127.0.0.1; user=root;password=;database=internshipdb;");
        public RegisterNewUser()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MM = new MainMenu();
            MM.Show();
            Hide();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            int role = 0;
            if ((bool)IsStudent.IsChecked)
                role = 0;
            else if ((bool)IsUniversity.IsChecked)
                role = 1;
            else if ((bool)IsCompany.IsChecked)
                role = 2;

            string query = "INSERT INTO `users`(`role`, `email`, `password`, `active`) VALUES (" + role.ToString() + ",'" + LoginField.Text + "','" + Password1Field.Password + "',1);"; 
            MySqlCommand Command = new MySqlCommand(query, MSC);
            try
            {
                if (Password1Field.Password == Password2Field.Password)
                {
                    MSC.Open();
                    Command.ExecuteNonQuery();
                    MSC.Close();
                    MessageBox.Show("User succesfully registered");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IsStudent_Checked(object sender, RoutedEventArgs e)
        {
            IsUniversity.IsChecked = false;
            IsCompany.IsChecked = false;
        }

        private void IsUniversity_Checked(object sender, RoutedEventArgs e)
        {
            IsStudent.IsChecked = false;
            IsCompany.IsChecked = false;
        }

        private void IsCompany_Checked(object sender, RoutedEventArgs e)
        {
            IsStudent.IsChecked = false;
            IsUniversity.IsChecked = false;
        }
    }
}
