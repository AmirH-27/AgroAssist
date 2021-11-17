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


namespace AgroAssistUpdated {
    public partial class Form23 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string name, fname;
        public Form23() {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE FarmOwner SET a_Name=@name, a_pass=@pass, f_Nid=@nid, " +
                "f_farmName = @farmName, f_farmAddress = @address, f_photo=@image WHERE a_Name=@name;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", guna2TextBox1.Text);
            cmd.Parameters.AddWithValue("@pass", guna2TextBox2.Text);
            cmd.Parameters.AddWithValue("@nid", Convert.ToInt32(guna2TextBox3.Text));
            cmd.Parameters.AddWithValue("@farmName", guna2TextBox4.Text);
            cmd.Parameters.AddWithValue("@address", guna2TextBox5.Text);

            cmd.Parameters.AddWithValue("@image", savePhoto());

            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a <= 0) {
                guna2Button1.Focus();
                //errorProvider1.SetError(this.guna2Button2, "Fill out all the details");
                MessageBox.Show("FarmOnwer Not Updated");
            }
            else {
                //errorProvider1.Clear();
                MessageBox.Show("FarmOwner Updated");
            }
            con.Close();

        }

        private byte[] savePhoto() {
            using (MemoryStream ms = new MemoryStream()) {
                guna2PictureBox1.Image.Save(ms, guna2PictureBox1.Image.RawFormat);
                return ms.GetBuffer();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e) {
            name = guna2TextBox1.Text;
            fname = guna2TextBox4.Text;
            SqlConnection con = new SqlConnection(cs);
            string query = "Delete From FarmOwner WHERE f_farmName=@fname;";
           // string queryLivestock = "Delete From Livestock WHERE f_farmName=@farmName;";
            string queryLogin = "Delete From Login_ACF WHERE a_Name=@name;";
            SqlCommand cmd = new SqlCommand(query, con);
            //SqlCommand cmdLive = new SqlCommand(queryLivestock, con);
            SqlCommand cmdLogin = new SqlCommand(queryLogin, con);

            cmd.Parameters.AddWithValue("@fname", guna2TextBox4.Text);
            //cmdLive.Parameters.AddWithValue("@farmName", fname);
            cmdLogin.Parameters.AddWithValue("@name", guna2TextBox1.Text);

            con.Open();

            int a = cmd.ExecuteNonQuery();
          //  int b = cmdLive.ExecuteNonQuery();
            int c = cmdLogin.ExecuteNonQuery();
            if (a <= 0) {
                guna2Button1.Focus();
                //errorProvider1.SetError(this.guna2Button2, "Fill out all the details");
                MessageBox.Show("FarmOwner Not Deleted");
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                guna2TextBox3.Clear();
                guna2TextBox4.Clear();
                guna2TextBox5.Clear();
                guna2PictureBox1.Image = Properties.Resources._1;
            }
            else {
                //errorProvider1.Clear();
                MessageBox.Show("FarmOwner Deleted");
            }
            con.Close();

            

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e) {

        }

        private void guna2Button5_Click(object sender, EventArgs e) {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select Image";
            open.Filter = "All Image Files *.*)|*.*";
            //open.ShowDialog();
            if (open.ShowDialog() == DialogResult.OK) {
                guna2PictureBox1.Image = new Bitmap(open.FileName);
            }
        }
    }
}
