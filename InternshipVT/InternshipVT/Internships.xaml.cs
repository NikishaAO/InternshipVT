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
using System.Data;

namespace InternshipVT
{
    /// <summary>
    /// Логика взаимодействия для Internships.xaml
    /// </summary>
    public partial class Internships : Window
    {
        MySqlConnection MSC = new MySqlConnection("host=127.0.0.1; user=root;password=;database=internshipdb;");
        string restr = "";

        public Internships()
        {
            InitializeComponent();
            if (Properties.Settings.Default["role"].ToString() == "student")
            {
                restr = " WHERE university_students.contacts = " + Properties.Settings.Default["login"].ToString();
            }
            GetData();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MM = new MainMenu();
            MM.Show();
            Hide();
        }
        private void GetData()
        {
            string query = "SELECT university_students.name, company.title, `start_date`, `end_date`, `description`, `requirement`, internship.active FROM `internship`INNER JOIN university_students ON Student_ID = university_students.ID INNER JOIN company ON company_id = company.ID " + restr;           MSC.Open();
            MySqlCommand command = new MySqlCommand(query, MSC);

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, MSC);
            DataTable dt = new DataTable();
            //adapter.Fill(dt);
            dt.Load(command.ExecuteReader());
            Internshiptable.ItemsSource = dt.DefaultView;
            MSC.Close();


        }
    }
}
