using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Contacts.xaml
    /// </summary>
    public partial class Contacts : Window
    {
        MySqlConnection MSC = new MySqlConnection("host=127.0.0.1; user=root;password=;database=internshipdb;");
        string role = "role_main_contact";
        string company = "";
        string StP = "";

        public Contacts()
        {
            InitializeComponent();
            GetCompanyData();
            GetStudentsData();
            GetCompanyList();
            GetSPList();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MM = new MainMenu();
            MM.Show();
            Hide();
        }

        private void GetCompanyData()
        {
            string query = "SELECT `title` AS Title, company.contacts AS 'Company contacts', company_persons.name AS 'Name', company_persons.contacts 'Person contacts', company_persons.role_main_contact AS 'Main contact', company_persons.role_internships AS 'internships', company_persons.role_activities AS 'Activities', company_persons.role_CD AS 'Career days', company_persons.role_trainings AS 'trainings', company_persons.role_FS AS 'Financial support' FROM `company_persons` INNER JOIN company ON company_persons.Company_ID = company.ID WHERE " + role + "= 1 " + company;
            MSC.Open();
            MySqlCommand command = new MySqlCommand(query, MSC);

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, MSC);
            DataTable dt = new DataTable();
            //adapter.Fill(dt);
            dt.Load(command.ExecuteReader());
            CompanyContacts.ItemsSource = dt.DefaultView;
            MSC.Close();


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleBox.SelectedIndex == 0)
                role = "role_main_contact";
            else if (RoleBox.SelectedIndex == 1)
                role = "role_internships";
            else if (RoleBox.SelectedIndex == 2)
                role = "role_activities";
            else if (RoleBox.SelectedIndex == 3)
                role = "role_CD";
            else if (RoleBox.SelectedIndex == 4)
                role = "role_trainings";
            else if (RoleBox.SelectedIndex == 5)
                role = "role_FS";

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            GetCompanyData();
        }
        private void GetCompanyList()
        {
            List<string> Companies = new List<string>();
            Companies.Add("All companies");
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

        private void SelectCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectCompany.SelectedIndex == 0)
            {
                company = "";
            }
            else
                company = "AND title = '" + SelectCompany.SelectedItem.ToString() + "';";
        }

        private void GetSPList()
        {
            List<string> SP = new List<string>();
            SP.Add("All study programs");
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
            SelectStudyProgram.ItemsSource = SP;
        }

        private void GetStudentsData()
        {
            string query = "SELECT name, contacts, study_program.title FROM university_students INNER JOIN study_program ON study_program_id = study_program.ID " + StP;
            MSC.Open();
            MySqlCommand command = new MySqlCommand(query, MSC);

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, MSC);
            DataTable dt = new DataTable();
            //adapter.Fill(dt);
            dt.Load(command.ExecuteReader());
            StudentContacts.ItemsSource = dt.DefaultView;
            MSC.Close();
        }

        private void SelectStudyProgram_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectStudyProgram.SelectedIndex == 0)
                StP = "";
            else
                StP = "WHERE study_program.title = '" + SelectStudyProgram.SelectedItem.ToString() +"'";

            GetStudentsData();
        }

        private void ToAddNewContact_Click(object sender, RoutedEventArgs e)
        {
            AddNewCompany ANC = new AddNewCompany();
            ANC.Show();
            Hide();
        }

        private void ToAddNewStudent_Click(object sender, RoutedEventArgs e)
        {
            AddNewStudent ANS = new AddNewStudent();
            ANS.Show();
            Hide();
        }
    }
}
