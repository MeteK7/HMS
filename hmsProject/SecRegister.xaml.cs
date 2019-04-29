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
    /// SecRegister.xaml etkileşim mantığı
    /// </summary>
    public partial class SecRegister : Window
    {
        int secTC;
        bool secAdd;
        public SecRegister(int tc, bool add)
        {
            InitializeComponent();
            CboClinic();
            secTC = tc;
            secAdd = add;
            AddOrUpdateSec();
        }

        MySqlConnection con = new MySqlConnection("Database=localhost;username=Project;password=123456;database=patient;");
        public void AddOrUpdateSec()
        {
            if (secAdd == false)
            {
                con.Open();
                MySqlCommand pullData = new MySqlCommand("SELECT * FROM secpage WHERE tcnum='" + secTC + "';", con);
                MySqlDataReader readData = pullData.ExecuteReader();

                while (readData.Read())
                {
                    txtSecName.Text = readData["name"].ToString();
                    txtSecSName.Text = readData["surname"].ToString();
                    txtSecTC.Text = readData["tcnum"].ToString();
                    txtSecNum.Text = readData["phone"].ToString();
                    pswSec.Password = readData["password"].ToString();
                    cboClinic.SelectedItem = readData["clinic"].ToString();
                    btnSecReg.Content = "UPDATE";
                }
                con.Close();
            }
        }

        private void BtnSecReg_Click(object sender, RoutedEventArgs e)
        {
            if (secAdd == true)
            {
                SecAdd();
            }
            else
                SecUpdate();
        }

        private void SecAdd()
        {
            bool validity = true;
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM secpage", con);
            MySqlDataReader readData = pullData.ExecuteReader();
            while (readData.Read())
            {
                string tctemp = readData["tcnum"].ToString();

                if (txtSecTC.Text == tctemp)
                {
                    tblSecValidity.Text = "This person is already exist.";
                    validity = false;
                    break;
                }
            }
            con.Close();

            if (validity == true)
            {
                tblSecValidity.Text = "";
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO secpage (name, surname, tcnum, phone, password, clinic) VALUES('" + txtSecName.Text + "', '" + txtSecSName.Text + "', '" + Convert.ToInt64(txtSecTC.Text) + "', '" + Convert.ToInt64(txtSecNum.Text) + "', '" + pswSec.Password + "','" + cboClinic.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Inserted Successfully!");
            }
        }

        private void SecUpdate()
        {
            con.Open();
            MySqlCommand update = new MySqlCommand("UPDATE secpage set name='" + txtSecName.Text + "',surname='" + txtSecSName.Text + "',tcnum='" + txtSecTC.Text + "',phone='" + txtSecNum.Text + "',password='" + pswSec.Password + "',clinic='" + cboClinic.Text + "'WHERE tCNum='" + secTC + "';", con);
            update.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully!");
        }


        private void CboClinic()
        {
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM bolumler", con);
            MySqlDataReader readData = pullData.ExecuteReader();

            while (readData.Read())
            {
                cboClinic.Items.Add(readData["Bolum"]);
            }
            con.Close();
        }

        private void TxtSecName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSecName.Text == "NAME")
            {
                txtSecName.Text = "";
            }

            if (String.IsNullOrEmpty(txtSecSName.Text))
            {
                txtSecSName.Text = "SURNAME";
            }
            if (String.IsNullOrEmpty(txtSecTC.Text))
            {
                txtSecTC.Text = "T.C. NUMBER";
            }

            if (String.IsNullOrEmpty(txtSecNum.Text))
            {
                txtSecNum.Text = "Phone Number";
            }
        }

        private void TxtSecSName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSecSName.Text == "SURNAME")
            {
                txtSecSName.Text = "";
            }

            if (String.IsNullOrEmpty(txtSecName.Text))
            {
                txtSecName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtSecTC.Text))
            {
                txtSecTC.Text = "T.C. NUMBER";
            }

            if (String.IsNullOrEmpty(txtSecNum.Text))
            {
                txtSecNum.Text = "Phone Number";
            }
        }

        private void TxtSecTC_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSecTC.Text == "T.C. NUMBER")
            {
                txtSecTC.Text = "";
            }

            if (String.IsNullOrEmpty(txtSecName.Text))
            {
                txtSecName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtSecSName.Text))
            {
                txtSecSName.Text = "SURNAME";
            }

            if (String.IsNullOrEmpty(txtSecNum.Text))
            {
                txtSecNum.Text = "Phone Number";
            }
        }

        private void TxtSecNum_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSecNum.Text == "Phone Number")
            {
                txtSecNum.Text = "";
            }

            if (String.IsNullOrEmpty(txtSecName.Text))
            {
                txtSecName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtSecSName.Text))
            {
                txtSecSName.Text = "SURNAME";
            }

            if (String.IsNullOrEmpty(txtSecTC.Text))
            {
                txtSecTC.Text = "T.C. NUMBER";
            }
        }

        private void PswSec_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSecName.Text))
            {
                txtSecName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtSecName.Text))
            {
                txtSecName.Text = "SURNAME";
            }

            if (String.IsNullOrEmpty(txtSecTC.Text))
            {
                txtSecTC.Text = "T.C. NUMBER";
            }

            if (String.IsNullOrEmpty(txtSecNum.Text))
            {
                txtSecNum.Text = "Phone Number";
            }
        }
    }
}
