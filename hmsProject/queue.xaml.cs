using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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

namespace hmsProject
{
    /// <summary>
    /// Interaction logic for queue.xaml
    /// </summary>
    public partial class queue : Window
    {
        public queue()
        {
            InitializeComponent();
        }
        MySqlConnection coni = new MySqlConnection("Database=localhost;username=Project;password=123456;database=patient;");
        int que=0;
        private void showdate()
        {

            coni.Open();
            MySqlCommand vericek = new MySqlCommand(" SELECT * FROM patientinfotemp WHERE priority='0'", coni);
            MySqlDataReader verioku = vericek.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("surname");
            dt.Columns.Add("priority");
            dt.Columns.Add("clinic");

            while (verioku.Read())
            {
                que += 1;
                dt.Rows.Add(new string[] { que.ToString(), verioku["name"].ToString(), verioku["surname"].ToString(), ("+65"), verioku["clinic"].ToString() });


            }

            grid2.ItemsSource = dt.DefaultView;
            grid2.AutoGenerateColumns = true;
            coni.Close();

        }
        private void showdate2()
        {

            coni.Open();
            MySqlCommand vericek = new MySqlCommand(" SELECT * FROM patientinfotemp WHERE priority='1'", coni);
            MySqlDataReader verioku = vericek.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("surname");
            dt.Columns.Add("priority");
            dt.Columns.Add("clinic");

            while (verioku.Read())
            {
                que += 1;
                dt.Rows.Add(new string[] { que.ToString(), verioku["name"].ToString(), verioku["surname"].ToString(), ("Normal"), verioku["clinic"].ToString() });


            }

            grid1.ItemsSource = dt.DefaultView;
            grid1.AutoGenerateColumns = true;
            coni.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            showdate();
            showdate2();

        }

        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
