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
    /// DocRegister.xaml etkileşim mantığı
    /// </summary>
    public partial class DocRegister : Window
    {
        int docTC;
        bool docAdd;
        public DocRegister(int tc, bool add)
        {
            InitializeComponent();
            docTC = tc;
            docAdd = add;
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
            if (String.IsNullOrEmpty(txtDocTC.Text))
            {
                txtDocTC.Text = "T.C. NUMBER";
            }

            if (String.IsNullOrEmpty(txtDocNum.Text))
            {
                txtDocNum.Text = "Phone Number";
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

            if (String.IsNullOrEmpty(txtDocTC.Text))
            {
                txtDocTC.Text = "T.C. NUMBER";
            }

            if (String.IsNullOrEmpty(txtDocNum.Text))
            {
                txtDocNum.Text = "Phone Number";
            }
        }

        private void txtDocTC_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDocTC.Text == "T.C. NUMBER")
            {
                txtDocTC.Text = "";
            }

            if (String.IsNullOrEmpty(txtDocName.Text))
            {
                txtDocName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtDocSName.Text))
            {
                txtDocSName.Text = "SURNAME";
            }

            if (String.IsNullOrEmpty(txtDocNum.Text))
            {
                txtDocNum.Text = "Phone Number";
            }
        }

        private void txtDocNum_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDocNum.Text == "Phone Number")
            {
                txtDocNum.Text = "";
            }

            if (String.IsNullOrEmpty(txtDocName.Text))
            {
                txtDocName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtDocSName.Text))
            {
                txtDocSName.Text = "SURNAME";
            }

            if (String.IsNullOrEmpty(txtDocTC.Text))
            {
                txtDocTC.Text = "T.C. NUMBER";
            }
        }

        private void pswDoc_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDocName.Text))
            {
                txtDocName.Text = "NAME";
            }

            if (String.IsNullOrEmpty(txtDocName.Text))
            {
                txtDocName.Text = "SURNAME";
            }

            if (String.IsNullOrEmpty(txtDocTC.Text))
            {
                txtDocTC.Text = "T.C. NUMBER";
            }

            if (String.IsNullOrEmpty(txtDocNum.Text))
            {
                txtDocNum.Text = "Phone Number";
            }
        }
    }
}
