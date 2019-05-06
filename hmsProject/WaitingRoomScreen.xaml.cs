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
    /// Interaction logic for WaitingRoomScreen.xaml
    /// </summary>
    public partial class WaitingRoomScreen : Window
    {
        public static string patient;

        public WaitingRoomScreen()
        {
            InitializeComponent();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            text();
        }

        private void text()
        {
            string patFullName = patient;
            lblCurrPatFullName.Content = "";
            lblCurrPatFullName.Content = patFullName;
        }
    }
}
