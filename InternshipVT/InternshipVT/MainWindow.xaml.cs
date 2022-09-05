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
using MySql.Data.MySqlClient;

namespace InternshipVT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection MSC = new MySqlConnection("host=127.0.0.1; user=root;password=;database=internshipdb;");

        public MainWindow()
        {

            InitializeComponent();
            if (Properties.Settings.Default["role"].ToString() != "null")
            {
                MainMenu MM = new MainMenu();
                MM.Show();
                Hide();
            }
            

        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM users WHERE email='" + LoginField.Text + "'AND password='" + PasswordField.Password + "';";
            MySqlCommand command = new MySqlCommand(query, MSC);
            MySqlDataReader reader;
            MSC.Open();
            reader= command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("login successful!");
                        MSC.Close();

                        Properties.Settings.Default["role"] = GetRole();
                        Properties.Settings.Default["login"] = LoginField.Text;
                        Properties.Settings.Default["password"] = PasswordField.Password;
                        Properties.Settings.Default.Save();
                        MainMenu MM = new MainMenu();
                        MM.Show();
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong login or password");
                    MSC.Close();

                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private string GetRole()
        {
            string role = "";
            string query = "SELECT role FROM users WHERE email = '" + LoginField.Text + "'";
            MSC.Open();
            MySqlCommand command = new MySqlCommand(@query, MSC);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                role = reader.GetString(0);
            }
            MSC.Close();

            if (role == "0")
                return "student";
            else if (role == "1")
                return "university";
            else if (role == "2")
                return "company";
            else
                return "null";

        }



    }
}
