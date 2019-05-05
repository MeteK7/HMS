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
namespace hmsProject
{
    /// <summary>
    /// Sec_login.xaml etkileşim mantığı
    /// </summary>
    public partial class Sec_login : Window
    {
        public Sec_login()
        {

            InitializeComponent();
            take_clinic();
        }
        int right_of_entry = 0;
        int trial;
        MySqlConnection coni = new MySqlConnection("Database=localhost;username=Project;password=123456;database=patient;");
        private void login_control()
        {
            string sec_id, sec_pass, sec_clnc;
            coni.Open();
            MySqlCommand commnd = new MySqlCommand("Select * from secpage", coni);
            MySqlDataReader readdata = commnd.ExecuteReader();
            while (readdata.Read())
            {
                sec_id = readdata["name"].ToString();
                sec_pass = readdata["password"].ToString();
                sec_clnc = readdata["clinic"].ToString();
                if (txt_Username.Text == sec_id && txt_Password.Password == sec_pass && Cb_clinic.Text == sec_clnc)
                {

                    Register_page page = new Register_page();  //alınmadı
                    page.Show();
                    page.label4.Content = txt_Username.Text;
                    page.label4_Copy.Content = Cb_clinic.SelectedItem.ToString();
                    this.Close();
                    trial = 1;
                    break;
                }


            }//control of secretary
            if (trial != 1)
            {

                MessageBox.Show("Wrong ID or Password");
                right_of_entry += 1;

                if (right_of_entry == 3)
                {
                    MessageBox.Show("Last Trial. Be Carefull!.");
                }

                if (right_of_entry == 4)
                {
                    this.Close();
                }


            }
            coni.Close();


        }

        private void take_clinic()
        {
            coni.Open();
            MySqlCommand takedata = new MySqlCommand(" SELECT * FROM bolumler", coni);
            MySqlDataReader readdata = takedata.ExecuteReader();

            while (readdata.Read())
            {
                Cb_clinic.Items.Add(readdata["Bolum"]);
            }
            coni.Close();
        } //click data cmbbx
        private void Cb_clinic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            login_control();
        }

        private void Cb_clinic_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
