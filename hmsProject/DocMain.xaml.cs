﻿using System;
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

class PatientInfo
{
    public string Order { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    public string TCNum { get; set; }
    public string Priority { get; set; }
}

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
            lvPatientInfo.IsEnabled = false;
            docFullName = n + " " + s;
            LoadPatientInfo();
            lvPatientInfo.SelectedIndex = lvPatientInfo.SelectedIndex + 1;
            LvPatientInfo_IndexChanged();
            LoadLogPatientInfo();
            lvLogPatient.SelectedIndex = lvLogPatient.SelectedIndex + 1;
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

        int counter;

        private void LoadPatientInfo()
        {
            counter = 0;
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM patientinfotemp WHERE doctor = '" + docFullName + "'", con);
            MySqlDataReader readData = pullData.ExecuteReader();
            while (readData.Read())
            {
                counter = counter + 1;
                this.lvPatientInfo.Items.Add(new PatientInfo() { Order = counter.ToString(), Name = readData["name"].ToString(), Surname = readData["surname"].ToString(), Age = readData["age"].ToString(), Gender = readData["gender"].ToString(), TCNum = readData["tcnum"].ToString(), Priority = readData["priority"].ToString() });
            }
            con.Close();
        }

        private void LoadLogPatientInfo()
        {
            lvLogPatient.Items.Clear();
            counter = 0;
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM patientinfotemp WHERE doctor = '" + docFullName + "'", con);
            MySqlDataReader readData = pullData.ExecuteReader();
            while (readData.Read())
            {
                counter = counter + 1;
                this.lvLogPatient.Items.Add(new PatientInfo() { Order = counter.ToString(), Name = readData["name"].ToString(), Surname = readData["surname"].ToString(), Age = readData["age"].ToString(), Gender = readData["gender"].ToString(), TCNum = readData["tcnum"].ToString(), Priority = readData["priority"].ToString() });
            }
            con.Close();
        }

        string patFullName;

        private void LvPatientInfo_IndexChanged()
        {
            PatientInfo pat = lvPatientInfo.SelectedItem as PatientInfo;
            patFullName = pat.Name + " " + pat.Surname;
            lblPatientName.Content = pat.Name;
            lblPatientSurname.Content = pat.Surname;
            lblPatientTC.Content = pat.TCNum;
            lblPatientOrder.Content = lvPatientInfo.SelectedIndex + 1;
            lblPatientAge.Content = pat.Age;
            lblPatientGender.Content = pat.Gender;
            cboPatPrevDate.Items.Clear();
            lvMedInfo.Items.Clear();
            medNameCounter = 0;
            tblPrevMeds.Text = "";
            tblPrevComm.Text = "";
            txtBlckMedDescription.Text = "Description:";
            txtDocComments.Text = "Comments here...";
            lvPatientInfo.Items.Refresh();
            cboMedType.SelectedIndex = -1;
            cboMedName.SelectedIndex = -1;
            cboMedDosage.SelectedIndex = -1;
            cboPatPrevDate.IsEnabled = true;
            cboMedName.IsEnabled = false;
            cboMedDosage.IsEnabled = false;
            btnAddMed.IsEnabled = false;
            btnDelMed.IsEnabled = false;
            btnPatientSave.IsEnabled = false;
            btnDelete.IsEnabled = false;
            txtMedAmount.IsEnabled = false;
            txtMedAmount.Text = "1";
            CboPatientPrevDates();
            WaitingRoomScreen.patient = patFullName;
        }

        private void LvLogPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboDate.IsEnabled = true;
            cboDate.Items.Clear();
            tblMeds.Text = "";
            tblComm.Text = "";
            cboDateLoad();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (lvPatientInfo.SelectedIndex != counter - 1)
            {
                int index = lvPatientInfo.SelectedIndex + 1;
                clearLvPatientInfo();
                lvPatientInfo.SelectedIndex = index;
            }
            else
            {
                clearLvPatientInfo();
                lvPatientInfo.SelectedIndex = 0;
            }
            LvPatientInfo_IndexChanged();
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (lvPatientInfo.SelectedIndex != 0)
            {
                int index = lvPatientInfo.SelectedIndex - 1;
                clearLvPatientInfo();
                lvPatientInfo.SelectedIndex = index;
            }
            else
            {
                clearLvPatientInfo();
                lvPatientInfo.SelectedIndex = counter - 1;
            }
            LvPatientInfo_IndexChanged();
        }

        private void clearLvPatientInfo()
        {
            lvPatientInfo.Items.Clear();
            LoadPatientInfo();
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

        private void TxtDocComments_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDocComments.Text == "Comments here...")
            {
                txtDocComments.Text = "";
            }
        }

        private void TxtDocComments_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDocComments.Text == "")
            {
                txtDocComments.Text = "Comments here...";
            }
        }

        string totMed;

        private void BtnPatientSave_Click(object sender, RoutedEventArgs e)
        {
            string dt2;
            DateTime date = DateTime.Now;
            DateTime date2 = DateTime.Now;
            /*dt = date.ToLongTimeString();        // display format:  11:45:44 AM*/
            /*dt2 = date2.ToString("yyyy-MM-dd HH:mm:ss");     // display format:  5/22/2010*/
            /*LvMedInfo med = lvMedInfo.SelectedItem as LvMedInfo;*/
            dt2 = date2.ToString();
            string comment = "No comment";
            PatientInfo pat = lvPatientInfo.SelectedItem as PatientInfo;

            for (int i = 0; i < medNameCounter; i++)
            {
                LvMedInfo md = lvMedInfo.Items.GetItemAt(i) as LvMedInfo;
                totMed = totMed + md.Name + "   x" + md.Amount + "\n";
            }

            if (txtDocComments.Text != "Comments here...")
                comment = txtDocComments.Text;

            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM patientinfotemp WHERE doctor = '" + docFullName + "'AND tcnum='" + pat.TCNum + "'", con);
            MySqlDataReader readData = pullData.ExecuteReader();
            readData.Read();

            string secName = readData["secretary"].ToString();
            string patPhone = readData["phone"].ToString();
            string patClinic = readData["clinic"].ToString();

            con.Close();

            con.Open();
            MySqlCommand insertData = new MySqlCommand("INSERT INTO patientinfo (name,surname,age,gender,tcnum,phone,clinic,doctor,medicine,comments,priority,secretary,dateTime) values ('" + pat.Name + "','" + pat.Surname + "','" + pat.Age + "','" + pat.Gender + "', '" + pat.TCNum + "', '" + patPhone + "', '" + patClinic + "', '" + docFullName + "','" + totMed + "', '" + comment + "', '" + pat.Priority + "', '" + secName + "', '" + dt2 + "')", con);
            /*MySqlCommand upData = new MySqlCommand("UPDATE patientinfo set medicine='" + totMed + "',comments='" + comment +"', dateTime='"+ dt2 + "',priority='"+pat.Priority+"'WHERE name='" + lblPatientName.Content + "';", con);*/
            insertData.ExecuteNonQuery();
            con.Close();

            lvPatientInfo.SelectedIndex = lvPatientInfo.SelectedIndex + 1;
            LvPatientInfo_IndexChanged();
            LoadLogPatientInfo();
        }

        private void CboPatientPrevDates()
        {
            int prev = 0;
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM patientinfo WHERE tcnum = '" + lblPatientTC.Content + "'", con);
            MySqlDataReader readData = pullData.ExecuteReader();

            while (readData.Read())
            {
                cboPatPrevDate.Items.Add(readData["dateTime"]);
                prev = prev + 1;
            }
            con.Close();
            /*cboPatPrevDate.SelectedItem.ToString();*/
            if (prev == 0)
            {
                cboPatPrevDate.IsEnabled = false;
            }
        }

        private void CboPatPrevDate_DropDownClosed(object sender, EventArgs e)
        {
            if (cboPatPrevDate.SelectedIndex != -1)
            {
                string date = cboPatPrevDate.SelectedItem.ToString();
                con.Open();
                MySqlCommand pullData = new MySqlCommand("SELECT * FROM patientinfo WHERE tcnum = '" + lblPatientTC.Content + "'AND dateTime='" + date + "'", con);
                MySqlDataReader readData = pullData.ExecuteReader();

                readData.Read();

                tblPrevMeds.Text = readData["medicine"].ToString();
                tblPrevComm.Text = readData["comments"].ToString();
                con.Close();
                btnDelete.IsEnabled = true;
            }
        }

        private void cboDateLoad()
        {
            PatientInfo pat = lvLogPatient.SelectedItem as PatientInfo;

            int prev = 0;
            con.Open();
            MySqlCommand pullData = new MySqlCommand("SELECT * FROM patientinfo WHERE tcnum = '" + pat.TCNum + "'", con);
            MySqlDataReader readData = pullData.ExecuteReader();

            while (readData.Read())
            {
                cboDate.Items.Add(readData["dateTime"]);
                prev = prev + 1;
            }
            con.Close();
            /*cboPatPrevDate.SelectedItem.ToString();*/
            if (prev == 0)
            {
                cboDate.IsEnabled = false;
            }
        }

        private void CboDate_DropDownClosed(object sender, EventArgs e)
        {
            if (cboDate.SelectedIndex != -1)
            {
                PatientInfo pat = lvLogPatient.SelectedItem as PatientInfo;

                string date = cboDate.SelectedItem.ToString();
                con.Open();
                MySqlCommand pullData = new MySqlCommand("SELECT * FROM patientinfo WHERE tcnum = '" + pat.TCNum + "'AND dateTime='" + date + "'", con);
                MySqlDataReader readData = pullData.ExecuteReader();

                readData.Read();

                tblMeds.Text = readData["medicine"].ToString();
                tblComm.Text = readData["comments"].ToString();

                con.Close();
            }
        }

        private void BtnOpenWaiting_Click(object sender, RoutedEventArgs e)
        {
            WaitingRoomScreen wait = new WaitingRoomScreen();
            /*wait.tbPatFullName.Text = patFullName;*/
            wait.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand delData = new MySqlCommand("DELETE FROM patientinfo WHERE dateTime='" + cboPatPrevDate.Text + "';", con);
            delData.ExecuteNonQuery();
            con.Close();
            cboPatPrevDate.Items.Clear();
            CboPatientPrevDates();
            cboPatPrevDate.SelectedIndex = -1;
            tblPrevMeds.Text = "";
            tblPrevComm.Text = "";
        }
    }
}