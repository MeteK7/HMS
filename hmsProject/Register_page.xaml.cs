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
    /// Register_page.xaml etkileşim mantığı
    /// </summary>
    public partial class Register_page : Window
    {
        public Register_page()
        {
            InitializeComponent();
        }
        MySqlConnection coni = new MySqlConnection("Database=localhost;username=Project;password=123456;database=patient;");
        private void security_control()
        {
            int toplam = 0; int toplam2 = 0; int toplam3 = 0;





            if (Txt_TC.Text.Length == 11)
            {
                if (Convert.ToInt32(Txt_TC.Text[0].ToString()) != 0) //tc kimlik numaranın ilk hanesi 0 değilse
                {
                    for (int i = 0; i < 10; i++)
                    {
                        toplam = toplam + Convert.ToInt32(Txt_TC.Text[i].ToString());
                        if (i % 2 == 0)
                        {
                            if (i != 10)
                            {
                                toplam2 = toplam2 + Convert.ToInt32(Txt_TC.Text[i].ToString()); // 7 ile çarpılacak sayıları topluyoruz
                            }

                        }
                        else
                        {
                            if (i != 9)
                            {
                                toplam3 = toplam3 + Convert.ToInt32(Txt_TC.Text[i].ToString());
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tc ID cannot be the first digit 0.");
                }
            }
            else
            {
                Txt_TC.Text = "00000000000";


            }
            if (((toplam2 * 7) - toplam3) % 10 == Convert.ToInt32(Txt_TC.Text[9].ToString()) && toplam % 10 == Convert.ToInt32(Txt_TC.Text[10].ToString()))
            {

                if (Txt_name.Text.Length == 0)
                {
                    MessageBox.Show("Name field can not be empty");
                    Txt_name.Clear();
                }
                if (Txt_SName.Text.Length == 0)
                {
                    MessageBox.Show("Surname field can not be empty");
                    Txt_SName.Clear();
                }
                if (Txt_Phone.Text.Length == 0)
                {
                    MessageBox.Show("Phone Number field can not be empty");
                    Txt_Phone.Clear();
                }
                if (Txt_Phone.Text.Length < 10)
                {
                    MessageBox.Show("Minumum 10 chracter");
                    Txt_Phone.Clear();
                }
                if (Txt_TC.Text == "00000000000")
                {

                    Txt_TC.Clear();
                    MessageBox.Show("T.C ID charcter must be 11 digit");

                }


                if (Txt_TC.Text.Length == 11 && Txt_Phone.Text.Length == 10)
                {
                    dataload();
                }
            }
            else
            {
                MessageBox.Show("T.C ID is False!");
            }
        }
        private void dataload() { }
        private void Txt_SName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
