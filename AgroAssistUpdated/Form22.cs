using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace AgroAssistUpdated {
    public partial class Form22 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string name;
        public Form22() {
            InitializeComponent();
            
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

        private void guna2Button1_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE Customer SET a_Name=@name, a_pass=@pass, c_Nid=@nid, c_photo=@image WHERE a_Name=@name;"; 
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", guna2TextBox1.Text);
            cmd.Parameters.AddWithValue("@pass", guna2TextBox2.Text);
            cmd.Parameters.AddWithValue("@nid", Convert.ToInt32(guna2TextBox3.Text));
            
            cmd.Parameters.AddWithValue("@image", savePhoto());

            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a <= 0) {
                guna2Button1.Focus();
                //errorProvider1.SetError(this.guna2Button2, "Fill out all the details");
                MessageBox.Show("Customer Not Updated");
            }
            else {
                //errorProvider1.Clear();
                MessageBox.Show("Customer Updated");
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
            SqlConnection con = new SqlConnection(cs);
            name = guna2TextBox1.Text;
            string query = "Delete From Customer WHERE a_Name=@name;";
            string queryLogin = "Delete From Login_ACF WHERE a_Name=@name;";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd1 = new SqlCommand(queryLogin, con);


            cmd.Parameters.AddWithValue("@name", name);
            cmd1.Parameters.AddWithValue("@name", name);

            con.Open();

            int a = cmd.ExecuteNonQuery();
            int b = cmd1.ExecuteNonQuery();
            if (a <= 0) {
                guna2Button1.Focus();
                //errorProvider1.SetError(this.guna2Button2, "Fill out all the details");
                MessageBox.Show("Customer Not Deleted");
            }
            else {
                //errorProvider1.Clear();
                MessageBox.Show("Customer Deleted");
            }
            con.Close();

            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2PictureBox1.Image = Properties.Resources._1;
        }
        
    }
}
