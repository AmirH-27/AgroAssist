using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace AgroAssistUpdated {
    public partial class Form21 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        UserInfo usr = new UserInfo();
        bool check;
        Receipt r1 = new Receipt();
        public Form21() {
            InitializeComponent();
        }

      
        private void guna2Button2_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE SoldLivestock SET l_purchaseStatus = 'Sold' WHERE l_token = @token;";
            string deleteQuery = "DELETE FROM Livestock WHERE l_token = @token;";
            
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmdDel = new SqlCommand(deleteQuery, con);
           
            cmd.Parameters.AddWithValue("@token", guna2TextBox6.Text);
            cmdDel.Parameters.AddWithValue("@token", guna2TextBox6.Text);

            con.Open();

            int a = cmd.ExecuteNonQuery();
            int b = cmdDel.ExecuteNonQuery();
            if (a <= 0 ) {
                guna2Button2.Focus();
                errorProvider11.SetError(this.guna2Button2, "Fill out all the details");
                check = false;
            }
            else {
                errorProvider11.Clear();
                //Form4 f4 = new Form4();
                //f4.panel3.AutoScroll = false;
                panel2.AutoScroll = false;
                Form25 f25 = new Form25();
                f25.TopLevel = false;
                panel2.Controls.Add(f25);
                f25.BringToFront();
                f25.Show();
            }
            con.Close();
           
            if (check) {
               

            }


        }
        public byte[] savePhoto() {
            MemoryStream ms = new MemoryStream();
            guna2PictureBox1.Image.Save(ms, guna2PictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "Delete From SoldLivestock Where l_token = @token;";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@token", guna2TextBox6.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0) {
                MessageBox.Show("Removed From Cart");
            }
            else {
                MessageBox.Show("Could not be Removed From Cart");
            }
            con.Close();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e) {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e) {

        }
    }
}
