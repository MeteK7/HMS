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

class LvMedInfo
{
    public string Amount { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Barcode { get; set; }
}

namespace hmsProject
{
    /// <summary>
    /// Interaction logic for DocMain.xaml
    /// </summary>
    public partial class DocMain : Window
    {
        public static string patientFullName;
        /*string docFullName;*/

        public DocMain(string n, string s)
        {
            InitializeComponent();
            CboMedType();
            cboMedName.IsEnabled = false;
            cboMedDosage.IsEnabled = false;
            btnAddMed.IsEnabled = false;
            btnDelMed.IsEnabled = false;
            btnPatientSave.IsEnabled = false;
            btnDelete.IsEnabled = false;
            txtMedAmount.IsEnabled = false;
        }

        MySqlConnection con = new MySqlConnection("Database=localhost;username=Project;password=123456;database=patient;");

        private void CboMedType()
        {
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM medicinetype", con);
            MySqlDataReader readData = pullData.ExecuteReader();

            while (readData.Read())
            {
                cboMedType.Items.Add(readData["type"]);
            }
            con.Close();
        }

        private void CboMedName()
        {
            cboMedName.Items.Clear();
            cboMedName.IsEnabled = true;

            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM medicineinfo WHERE type = '" + cboMedType.Text + "'", con);
            MySqlDataReader readData = pullData.ExecuteReader();

            while (readData.Read())
            {
                cboMedName.Items.Add(readData["name"]);
            }
            con.Close();
        }

        private void CboMedDosage()
        {
            cboMedDosage.Items.Clear();
            cboMedDosage.IsEnabled = true;

            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM medicineinfo WHERE name = '" + cboMedName.Text + "'", con);
            MySqlDataReader readData = pullData.ExecuteReader();

            while (readData.Read())
            {
                cboMedDosage.Items.Add(readData["dosage"]);
            }
            con.Close();
        }

        private void CboMedType_DropDownClosed(object sender, EventArgs e)
        {
            if (cboMedType.SelectedIndex != -1)
            {
                lblMedBarcode.Content = "";
                lblWarning.Content = "";
                txtBlckMedDescription.Text = "Description:";
                txtMedAmount.Text = "1";
                txtMedAmount.IsEnabled = false;
                btnPatientSave.IsEnabled = false;
                btnAddMed.IsEnabled = false;
                btnDelMed.IsEnabled = false;
                cboMedDosage.IsEnabled = false;
                cboMedDosage.Items.Clear();
                CboMedName();
            }

        }

        private void CboMedName_DropDownClosed(object sender, EventArgs e)
        {
            if (cboMedName.SelectedIndex != -1)
            {
                CboMedDosage();
            }
        }

        private void CboMedDosage_DropDownClosed(object sender, EventArgs e)
        {
            if (cboMedDosage.SelectedIndex != -1)
            {
                con.Open();
                MySqlCommand pullData = new MySqlCommand("SELECT * FROM medicineinfo WHERE name = '" + cboMedName.Text + "'AND dosage = '" + cboMedDosage.Text + "'", con);
                MySqlDataReader readData = pullData.ExecuteReader();
                readData.Read();
                lblMedBarcode.Content = "Barcode: " + readData["barcode"].ToString();
                txtBlckMedDescription.Text = readData["description"].ToString();
                con.Close();
                btnAddMed.IsEnabled = true;
                btnDelMed.IsEnabled = true;
                txtMedAmount.IsEnabled = true;
                btnPatientSave.IsEnabled = true;
            }

        }

        int medNameCounter = 0;

        private void BtnAddMed_Click(object sender, RoutedEventArgs e)
        {
            lblWarning.Content = "";
            bool add = true;
            int outParse;
            int tempNum = 0;

            if (txtMedAmount.Text == "" || !Int32.TryParse(txtMedAmount.Text, out outParse) || Convert.ToInt16(txtMedAmount.Text) <= 0 || Convert.ToInt16(txtMedAmount.Text) > 10)
                txtMedAmount.Text = "1";

            for (int i = 0; i < medNameCounter; i++)
            {
                LvMedInfo md = lvMedInfo.Items.GetItemAt(i) as LvMedInfo;

                if (md.Name == cboMedName.SelectedItem.ToString())
                {
                    tempNum = Convert.ToInt16(md.Amount) + Convert.ToInt16(txtMedAmount.Text);
                    md.Amount = tempNum.ToString();
                    add = false;
                    lvMedInfo.Items.Refresh();
                    break;
                }
            }

            if (add == true)
            {
                medNameCounter++;
                this.lvMedInfo.Items.Add(new LvMedInfo() { Amount = txtMedAmount.Text, Name = cboMedName.SelectedItem.ToString(), Type = cboMedType.SelectedItem.ToString() });
            }

        }

        private void BtnDelMed_Click(object sender, RoutedEventArgs e)
        {
            if (lvPatientInfo.SelectedIndex != -1)
            {
                medNameCounter = medNameCounter - 1;
                lvMedInfo.Items.RemoveAt(lvMedInfo.SelectedIndex);
                btnDelMed.IsEnabled = false;
            }
            else
                lblWarning.Content = "Please choose a med from the list to delete it.";

        }

        private void LvMedInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelMed.IsEnabled = true;
        }

    }
}
