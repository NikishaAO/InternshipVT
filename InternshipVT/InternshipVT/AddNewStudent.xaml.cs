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
    /// Логика взаимодействия для AddNewStudent.xaml
    /// </summary>
    public partial class AddNewStudent : Window
    {
        MySqlConnection MSC = new MySqlConnection("host=127.0.0.1; user=root;password=;database=internshipdb;");

        public AddNewStudent()
        {
            InitializeComponent();
            GetSPList();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Contacts C = new Contacts();
            C.Show();
            Hide();
        }
        private void GetSPList()
        {
            List<string> SP = new List<string>();
            string query = "SELECT title FROM study_program";
            MSC.Open();
            MySqlCommand command = new MySqlCommand(query, MSC);
            MySqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                SP.Add(reader.GetString(i));
                i = 0;
            }
            MSC.Close();
            SelectSP.ItemsSource = SP;
        }

        private void NameField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SelectSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewStudentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO university_students (name, contacts, study_program_id, active) VALUES ('" + NameField.Text + "','" + ContactField.Text + "'," + (SelectSP.SelectedIndex + 1) + ",1)";
                MSC.Open();
                MySqlCommand command = new MySqlCommand(@query, MSC);
                command.ExecuteNonQuery();
                MSC.Close();
                MessageBox.Show("New student added");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
