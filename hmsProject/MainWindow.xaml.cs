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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hmsProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnDoctor_Click(object sender, RoutedEventArgs e)
        {
            DocLogin docLog = new DocLogin();
            docLog.Show();
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen adminPage = new AdminScreen();
            adminPage.Show();
        }

        private void btnSec_Click(object sender, RoutedEventArgs e)
        {
            Sec_login sec_Login = new Sec_login();
            sec_Login.Show();
        }
    }
}
