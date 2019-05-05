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
using System.Text.RegularExpressions;
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
        private void take_clinic()
        {
            String bolum = Convert.ToString(label4_Copy.Content);
            coni.Open();
            MySqlCommand takedata = new MySqlCommand(" SELECT * FROM docpage Where major='" +bolum+"'", coni);
            MySqlDataReader readdata = takedata.ExecuteReader();

            while (readdata.Read())
            {
                cb_doctor.Items.Add(readdata["firstName"]);
            }
            coni.Close();
        } //click data cmbbx
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
        private void dataload() {
            coni.Open();
            string isim, soyisim, bolum,tc,tel,doc,gen,sec;
            int yas, oncelikli = 1;

            isim = Txt_name.Text.ToString();
            soyisim = Txt_SName.Text.ToString();
            yas = Convert.ToInt16(Txt_Birth.Text);
            bolum = cb_Clinic.SelectedItem.ToString();
            doc = cb_doctor.SelectedItem.ToString();
            gen = cb_gender.SelectedItem.ToString();
            tc = Convert.ToString(Txt_TC.Text);
            tel= Convert.ToString(Txt_Phone.Text);
            sec = Convert.ToString(label4.Content);
            if (yas <= 1953)
            {
                oncelikli = 0;
            }
            MessageBox.Show(doc);


            MySqlCommand komut = new MySqlCommand("Insert Into patientinfotemp(tcnum,name,surname,age,phone,priority,clinic,doctor,gender,secretary) values ('" + Convert.ToInt64(tc) + "', '" + isim + "', '" + soyisim + "', '" + yas + "', '" + Convert.ToInt64(tel) + "', '" + oncelikli + "', '" + bolum + "', '" + doc + "', '" + gen + "', '" + sec + "')", coni);
            komut.ExecuteNonQuery();
            MessageBox.Show("Succesfully");
            coni.Close();
            Txt_name.Clear();
            Txt_SName.Clear();
            Txt_Phone.Clear();
            Txt_TC.Clear();
            Txt_Birth.Clear();




        }
        private void Txt_SName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Queue_Click(object sender, RoutedEventArgs e)
        {
            queue page = new queue();  //alınmadı
            page.Show();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            security_control();
            if (radio.IsChecked==true)
                dataload();
        }

        private void cb_doctor_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cb_doctor.Items.Clear();
            take_clinic();
        }

        private void cb_Clinic_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void cb_Clinic_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string deger = Convert.ToString(label4_Copy.Content);
            cb_Clinic.Items.Clear();
            cb_Clinic.Items.Add(deger);

        }

        private void Txt_TC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Txt_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

        }

        private void Txt_Birth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void cb_gender_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string deger1 = "Man";
            string deger2 = "Woman";
            cb_gender.Items.Clear();
            cb_gender.Items.Add(deger1);
            cb_gender.Items.Add(deger2);

        }
    }
}
