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
        }

        private void btnPassRequ_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact your administrator to reset your password!");
        }
    }
}
