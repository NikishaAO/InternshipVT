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
    /// Логика взаимодействия для AddNewCompany.xaml
    /// </summary>
    public partial class AddNewCompany : Window
    {
        MySqlConnection MSC = new MySqlConnection("host=127.0.0.1; user=root;password=;database=internshipdb;");

        public AddNewCompany()
        {
            InitializeComponent();
            GetCompanyList();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Contacts C = new Contacts();
            C.Show();
            Hide();
        }

        private void SelectCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewCompanyButton_Click(object sender, RoutedEventArgs e)
        {
           string query = "INSERT INTO company (title,contacts,active) VALUES ('" + TitleField.Text + "','" + CompanyContactField.Text + "',1)";

            try
            {
                MSC.Open();
                MySqlCommand command = new MySqlCommand(query, MSC);
                command.ExecuteNonQuery();
                MSC.Close();
                MessageBox.Show("New company added");
                GetCompanyList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
        private void GetCompanyList()
        {
            List<string> Companies = new List<string>();
            string query = "SELECT title FROM company";
            MSC.Open();
            MySqlCommand command = new MySqlCommand(query, MSC);
            MySqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                Companies.Add(reader.GetString(i));
                i = 0;
            }
            MSC.Close();
            SelectCompany.ItemsSource = Companies;
        }

        private void AddNewContactButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO company_persons (Company_ID, name, contacts, role_main_contact, role_internships, role_activities, role_CD, role_trainings, role_FS, active)" +
                "VALUES (" + (SelectCompany.SelectedIndex + 1) + ",'" + NameField.Text + "','" + PersonContactField.Text + "'," + MainContact.IsChecked + "," + Internship.IsChecked + "," + Activities.IsChecked + "," + CD.IsChecked + "," + Trainings.IsChecked + "," + FS.IsChecked + ", 1)"
            ; MSC.Open();
            MySqlCommand command = new MySqlCommand(query, MSC);
            command.ExecuteNonQuery();
            MSC.Close();
            MessageBox.Show("New Contact added");
          }

        
    }
}
