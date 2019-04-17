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
    /// Interaction logic for DocMain.xaml
    /// </summary>
    public partial class DocMain : Window
    {
        public static string patientFullName;
        string docFullName;

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
    }
}
