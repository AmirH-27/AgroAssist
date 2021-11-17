using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace AgroAssistUpdated {
    public partial class Form6 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        UserInfo usr = new UserInfo();
        string selectedToken;
        string selectedDate;
        public Form6() {
            InitializeComponent();
            getToken();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            /*SqlConnection con = new SqlConnection(cs);
            string query = "INSERT INTO Appointment VALUES('"+selectedToken+"','"+selectedDate+"','"+usr.getName()+"');";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0) {
                MessageBox.Show("Appointment Booked");
            }
            else {
                MessageBox.Show("Could not Book Appointment");
            }*/
        }
        void getToken() {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT l_token FROM SoldLivestock WHERE l_purchaseStatus = 'Booked' AND a_Name = '"+usr.getName()+"';";
            SqlCommand cmd = new SqlCommand(query, con);          
            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while(r.Read()) {
                string data = r["l_token"].ToString();
                guna2ComboBox1.Items.Add(data);
            }
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            selectedToken = guna2ComboBox1.SelectedItem.ToString();
            
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e) {
            selectedDate = guna2DateTimePicker1.Value.ToString("dd/MM/yyyy").Trim();
        }

        private void Form6_Load(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e) {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "INSERT INTO Appointment VALUES('" + guna2ComboBox1.SelectedItem.ToString() + "','" + guna2DateTimePicker1.Value.ToString("dd/MM/yyyy").Trim() + "','" + usr.getName() + "');";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0) {
                MessageBox.Show("Appointment Booked");
            }
            else {
                MessageBox.Show("Could not Book Appointment");
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e) {

        }
    }
}
