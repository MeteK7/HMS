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

class MedInfo
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Dosage { get; set; }
    public string Barcode { get; set; }
}

namespace hmsProject
{
    /// <summary>
    /// AdminScreen.xaml etkileşim mantığı
    /// </summary>
    public partial class AdminScreen : Window
    {
        public AdminScreen()
        {
            InitializeComponent();
            DgMed();
            CboMedType();
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

        private void DgMed()
        {
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM medicineinfo", con);
            MySqlDataReader readData = pullData.ExecuteReader();

            while (readData.Read())
            {
                dataGridMedInfo.Items.Add(new MedInfo() { Name = readData["name"].ToString(), Type = readData["type"].ToString(), Dosage = readData["dosage"].ToString(), Barcode = readData["barcode"].ToString() });
            }
            con.Close();
        }

        private void RefreshDgMed()
        {
            dataGridMedInfo.SelectedIndex = -1;
            dataGridMedInfo.Items.Clear();
            DgMed();
        }


        private void ClearTexts()
        {
            txtMedName.Text = "";
            txtDosage.Text = "";
            txtBarcode.Text = "";
            txtMedDescription.Text = "";
            cboMedType.SelectedIndex = -1;
        }

        private void DataGridMedInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridMedInfo.SelectedIndex != -1)
            {
                MedInfo med = dataGridMedInfo.SelectedItem as MedInfo;
                con.Open();
                MySqlCommand pullData = new MySqlCommand("SELECT * FROM medicineinfo WHERE barcode='" + med.Barcode + "';", con);
                MySqlDataReader readData = pullData.ExecuteReader();
                readData.Read();
                txtMedName.Text = med.Name;
                txtDosage.Text = med.Dosage;
                txtBarcode.Text = med.Barcode;
                txtMedDescription.Text = readData["description"].ToString();
                cboMedType.SelectedItem = med.Type;
                con.Close();
            }
        }

        private void BtnDelMed_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMedInfo.SelectedIndex != -1)
            {
                MedInfo med = dataGridMedInfo.SelectedItem as MedInfo;

                con.Open();
                MySqlCommand delData = new MySqlCommand("DELETE FROM medicineinfo WHERE barcode='" + med.Barcode + "';", con);
                delData.ExecuteNonQuery();
                con.Close();
                ClearTexts();
                RefreshDgMed();
            }
            else
            {
                MessageBox.Show("Please choose a medicine from the list to delete.");
            }
        }

        private void BtnAddMedType_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO medicinetype (type) VALUES('" + txtMedType.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Successfully!");
            cboMedType.Items.Clear();
            CboMedType();
        }

        private void BtnAddMed_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO medicineinfo (type, name, dosage, barcode, description) VALUES('" + cboMedType.Text + "','" + txtMedName.Text + "','" + txtDosage.Text + "','" + txtBarcode.Text + "','" + txtMedDescription.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ClearTexts();
            RefreshDgMed();
        }

        private void BtnUpdateMed_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMedInfo.SelectedIndex != -1)
            {
                MedInfo med = dataGridMedInfo.SelectedItem as MedInfo;
                con.Open();
                MySqlCommand upData = new MySqlCommand("UPDATE medicineinfo set name='" + txtMedName.Text + "',type='" + cboMedType.Text + "',dosage='" + txtDosage.Text + "',barcode='" + txtBarcode.Text + "',description='" + txtMedDescription.Text + "'WHERE barcode='" + med.Barcode + "';", con);
                MySqlDataReader readData = upData.ExecuteReader();
                readData.Read();
                con.Close();
                RefreshDgMed();
            }
            else
            {
                MessageBox.Show("Please select a medicine from the list firstly.");
            }
        }


    }
}
