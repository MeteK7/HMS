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
    /// Interaction logic for DocLogin.xaml
    /// </summary>
    public partial class DocLogin : Window
    {
        public DocLogin()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Database=localhost;username=Project;password=123456;database=patient;");

        private void txtDocName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDocName.Text == "NAME")
            {
                txtDocName.Text = "";
            }

            if (String.IsNullOrEmpty(txtDocSName.Text))
            {
                txtDocSName.Text = "SURNAME";
            }
        }

        private void txtDocSName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDocSName.Text == "SURNAME")
            {
                txtDocSName.Text = "";
            }

            if (String.IsNullOrEmpty(txtDocName.Text))
            {
                txtDocName.Text = "NAME";
            }
        }

        private void pswDoc_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDocName.Text))
            {
                txtDocName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtDocSName.Text))
            {
                txtDocSName.Text = "SURNAME";
            }
        }

        private void btnDocLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtDocName.Text == "" || txtDocName.Text == "NAME" || txtDocSName.Text == "" || txtDocSName.Text == "SURNAME" || pswDoc.Password == "")
            {
                lblWarning.Content = "Please fill all fields.";
            }
            else
                CheckAccount();
        }

        private void CheckAccount()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * from docpage", con);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (txtDocName.Text == rd["firstName"].ToString() && txtDocSName.Text == rd["lastName"].ToString() && pswDoc.Password == rd["password"].ToString())
                {
                    string n = txtDocName.Text;
                    string s = txtDocSName.Text;
                    pswDoc.Password = "";
                    lblWarning.Content = "";
                    DocMain docM = new DocMain(n, s);
                    docM.Show();
                    break;
                }
                else
                    lblWarning.Content = "You've entered something uncorrect.";
            }

            con.Close();

        }

        private void btnPassRequ_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact your administrator to reset your password!");
        }
    }
}
