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
    public partial class Form3 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        bool exists;
        public Form3() {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e) {
            this.Close();
            Form1 f1 = new Form1();
            f1.TopLevel = false;
            panel1.Controls.Add(f1);
            f1.BringToFront();
            f1.Show();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if(guna2ComboBox1.SelectedIndex == 1) {
                guna2TextBox1.Visible = true;
                guna2TextBox3.Visible = true;
            }
            else {
                guna2TextBox1.Visible = false;
                guna2TextBox3.Visible = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            // checks before inserting into the database 
            //also inputs in loginAcf 
            //selected index 1 = farm owner
            if (guna2ComboBox1.SelectedIndex == 1 && guna2TextBox2.Text != "" && 
                guna2TextBox4.Text != "" && guna2TextBox5.Text != "" && 
                guna2TextBox1.Text != "" && guna2TextBox3.Text != "") {
                SqlConnection con = new SqlConnection(cs);

               
                string query = "INSERT INTO FarmOwner VALUES(@name, @pass, @nid, @farmName, @farmAddress, @image);";
                string queryLogin = "INSERT INTO Login_ACF VALUES(@name, @pass, @type, @fName);";
                string checkUserName = " SELECT * FROM LOGIN_ACF WHERE a_Name = @name;";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmdLogin = new SqlCommand(queryLogin, con);
                SqlCommand cmdLoginCheck = new SqlCommand(checkUserName, con);

                cmd.Parameters.AddWithValue("@name", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@pass", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@nid", Convert.ToInt32(guna2TextBox5.Text));
                cmd.Parameters.AddWithValue("@farmname", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@farmAddress", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@image", savePhoto());

                cmdLogin.Parameters.AddWithValue("@name", guna2TextBox2.Text);
                cmdLogin.Parameters.AddWithValue("@pass", guna2TextBox4.Text);
                cmdLogin.Parameters.AddWithValue("@type", "FarmOwner");
                cmdLogin.Parameters.AddWithValue("@fName", guna2TextBox1.Text);

                cmdLoginCheck.Parameters.AddWithValue("@name", guna2TextBox2.Text);

                con.Open();
                SqlDataReader r = cmdLoginCheck.ExecuteReader();
                if (r.HasRows) {
                    guna2Button2.Focus();
                    errorProvider8.SetError(this.guna2Button2, "Username already exists");
                    exists = true;
                }
                con.Close();
                con.Open();
                if(exists != true) {
                    int a = cmd.ExecuteNonQuery();
                    int b = cmdLogin.ExecuteNonQuery();
                    if (a <= 0 || b <= 0) {
                        guna2Button2.Focus();
                        errorProvider8.SetError(this.guna2Button2, "Fill out all the details");
                    }
                    else {
                        errorProvider8.Clear();
                        Form2 f2 = new Form2();
                        f2.TopLevel = false;
                        panel1.Controls.Add(f2);
                        f2.BringToFront();
                        f2.Show();
                    }
                }
                else {
                    errorProvider8.SetError(this.guna2Button2, "Username already exists");
                }

                con.Close();       
            }
            //selected index = 2 is fopr customer
            else if(guna2ComboBox1.SelectedIndex == 2 && guna2TextBox2.Text != "" && guna2TextBox4.Text != "" && guna2TextBox5.Text != "") {
                SqlConnection con = new SqlConnection(cs);
                string query = "INSERT INTO Customer VALUES(@name, @pass, @nid, @image);";
                string queryLogin = "INSERT INTO Login_ACF VALUES(@name, @pass, @type, 'No Name');";
                string checkUserName = " SELECT * FROM LOGIN_ACF WHERE a_Name = @name;";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmdLogin = new SqlCommand(queryLogin, con);
                SqlCommand cmdLoginCheck = new SqlCommand(checkUserName, con);

                cmd.Parameters.AddWithValue("@name", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@pass", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@nid", Convert.ToInt32(guna2TextBox5.Text));    
                cmd.Parameters.AddWithValue("@image", savePhoto());


                cmdLogin.Parameters.AddWithValue("@name", guna2TextBox2.Text);
                cmdLogin.Parameters.AddWithValue("@pass", guna2TextBox4.Text);
                cmdLogin.Parameters.AddWithValue("@type", "Customer");

                cmdLoginCheck.Parameters.AddWithValue("@name", guna2TextBox2.Text);

                con.Open();
               

                SqlDataReader r = cmdLoginCheck.ExecuteReader();
                if (r.HasRows == true) {
                    guna2Button2.Focus();
                    errorProvider8.SetError(this.guna2Button2, "Username already exists");
                    exists = true;
                }
                con.Close();
                con.Open();

                if(exists != true){
                    int a = cmd.ExecuteNonQuery();
                    int b = cmdLogin.ExecuteNonQuery();
                    if (a <= 0 || b <= 0) {
                        guna2Button2.Focus();
                        errorProvider8.SetError(this.guna2Button2, "Fill out all the details");
                    }
                    else {
                        errorProvider8.Clear();
                        Form2 f2 = new Form2();
                        f2.TopLevel = false;
                        panel1.Controls.Add(f2);
                        f2.BringToFront();
                        f2.Show();
                    }
                }
                con.Close();
            }
            
        }

        private byte[] savePhoto() {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select Image";
            open.Filter = "All Image Files *.*)|*.*";
            //open.ShowDialog();
            if (open.ShowDialog() == DialogResult.OK) {
                guna2CirclePictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void guna2ComboBox1_Leave(object sender, EventArgs e) {
            if(guna2ComboBox1.SelectedIndex == 0) {
                guna2ComboBox1.Focus();
                errorProvider1.SetError(this.guna2ComboBox1, "Select an account type");
            }
            else {
                errorProvider1.Clear();
            }
        }

        private void guna2TextBox2_Leave(object sender, EventArgs e) {
            if (guna2TextBox2.Text == "") {
                guna2TextBox2.Focus();
                errorProvider2.SetError(this.guna2TextBox2, "Enter Username");
            }
            else {
                errorProvider2.Clear();
            }
        }

        private void guna2TextBox4_Leave(object sender, EventArgs e) {
            if (guna2TextBox4.Text == "") {
                guna2TextBox4.Focus();
                errorProvider3.SetError(this.guna2TextBox4, "Enter Password");
            }
            else {
                errorProvider3.Clear();
            }
        }

        private void guna2TextBox5_Leave(object sender, EventArgs e) {
            if (guna2TextBox5.Text == "") {
                guna2TextBox5.Focus();
                errorProvider4.SetError(this.guna2TextBox5, "Enter NID number");
            }
            else {
                errorProvider4.Clear();
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e) {
            if (guna2TextBox1.Visible==true && guna2TextBox1.Text == "") {
                guna2TextBox1.Focus();
                errorProvider5.SetError(this.guna2TextBox1, "Enter Farm Name");
            }
            else {
                errorProvider5.Clear();
            }
        }

        private void guna2TextBox3_Leave(object sender, EventArgs e) {
            if (guna2TextBox3.Visible == true && guna2TextBox3.Text == "") {
                guna2TextBox3.Focus();
                errorProvider6.SetError(this.guna2TextBox3, "Enter Farm Address");
            }
            else {
                errorProvider6.Clear();
            }
        }

        private void guna2Button1_Leave(object sender, EventArgs e) {
            if (guna2CirclePictureBox1.Image == null) {
                guna2Button1.Focus();
                errorProvider8.SetError(this.guna2Button1, "Upload an image");
            }
            else {
                errorProvider8.Clear();
            }
        }
    }
}
