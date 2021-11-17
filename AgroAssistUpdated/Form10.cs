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
    public partial class Form10 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        bool exists;
        UserInfo usr = new UserInfo();
        public string isHighlighted;
        public Form10() {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select Image";
            open.Filter = "All Image Files *.*)|*.*";
            //open.ShowDialog();
            if (open.ShowDialog() == DialogResult.OK) {
                guna2PictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            if (guna2TextBox6.Text != "" && guna2ComboBox2.SelectedIndex != 0 && 
                guna2ComboBox1.SelectedIndex != 0 && guna2ComboBox4.SelectedIndex != 0 && 
                guna2NumericUpDown3.Value != 0 && guna2NumericUpDown4.Value != 0 &&
                guna2NumericUpDown5.Value != 0 && guna2NumericUpDown2.Value != 0 &&
                guna2NumericUpDown1.Value != 0 && guna2ComboBox3.SelectedIndex != 0 &&
                isHighlighted != "") {

                SqlConnection con = new SqlConnection(cs);
                string query = "INSERT INTO Livestock " +
                    "VALUES(@token, @type, @breed, @color, @age, @length, @height, @weight, @price, @vaccine, @highlight, @image, @name, @fName);";
                string checkQuery = "SELECT * FROM Livestock WHERE l_token = @token;";

                string updateQ="UPDATE Login_ACF SET f_Name = '@fname' WHERE a_Name = '@token'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmdCheck = new SqlCommand(checkQuery, con);
                SqlCommand cmdUp = new SqlCommand(updateQ, con);

                cmd.Parameters.AddWithValue("@token", guna2TextBox6.Text);
                cmd.Parameters.AddWithValue("@type", guna2ComboBox2.Text);
                cmd.Parameters.AddWithValue("@breed", guna2ComboBox1.Text);
                cmd.Parameters.AddWithValue("@color", guna2ComboBox4.Text);
                cmd.Parameters.AddWithValue("@age", guna2NumericUpDown5.Value);
                cmd.Parameters.AddWithValue("@length", guna2NumericUpDown3.Value);
                cmd.Parameters.AddWithValue("@height", guna2NumericUpDown4.Value);
                cmd.Parameters.AddWithValue("@weight", guna2NumericUpDown2.Value);
                cmd.Parameters.AddWithValue("@price", guna2NumericUpDown1.Value);
                cmd.Parameters.AddWithValue("@vaccine", guna2ComboBox3.Text);
                cmd.Parameters.AddWithValue("@highlight", guna2CheckBox1.Checked);
                cmd.Parameters.AddWithValue("@image", savePhoto());
                cmd.Parameters.AddWithValue("@name", usr.getName());
                cmd.Parameters.AddWithValue("@fName", usr.getFName());

                cmdCheck.Parameters.AddWithValue("@token", guna2TextBox6.Text);

                cmdUp.Parameters.AddWithValue("@token", guna2TextBox6.Text);
                cmdUp.Parameters.AddWithValue("@fName", usr.getFName());

                con.Open();
                SqlDataReader r = cmdCheck.ExecuteReader();
                if (r.HasRows == true) {
                    guna2Button2.Focus();
                    errorProvider11.SetError(this.guna2Button2, "Token Number Already exists");
                    exists = true;
                }
                else {
                    exists = false;
                }
                con.Close();
                con.Open();

                if(exists!=true) {
                    int a = cmd.ExecuteNonQuery();
                    if (a <= 0) {
                        guna2Button2.Focus();
                        errorProvider11.SetError(this.guna2Button2, "Fill out all the details");
                    }
                    else {
                        errorProvider11.Clear();
                        MessageBox.Show("Livestock Inserted");
                    }
                }
                con.Close();
            }
        }
        public byte[] savePhoto() {
            MemoryStream ms = new MemoryStream();
            guna2PictureBox1.Image.Save(ms, guna2PictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        private void guna2TextBox6_Leave(object sender, EventArgs e) {
            if(guna2TextBox6.Text == "") {
                guna2TextBox6.Focus();
                errorProvider1.SetError(this.guna2TextBox6, "Insert Token Number");
            }
            else {
                errorProvider1.Clear();
            }
        }

        private void guna2ComboBox2_Leave(object sender, EventArgs e) {
            if (guna2ComboBox2.SelectedIndex == 0) {
                guna2ComboBox2.Focus();
                errorProvider2.SetError(this.guna2ComboBox2, "Select animal type");
            }
            else {
                errorProvider2.Clear();
            }
        }

        private void guna2ComboBox1_Leave(object sender, EventArgs e) {
            if (guna2ComboBox1.SelectedIndex == 0) {
                guna2ComboBox1.Focus();
                errorProvider3.SetError(this.guna2ComboBox1, "Select Breed");
            }
            else {
                errorProvider3.Clear();
            }
        }

        private void guna2ComboBox4_Leave(object sender, EventArgs e) {
            if (guna2ComboBox4.SelectedIndex == 0) {
                guna2ComboBox4.Focus();
                errorProvider4.SetError(this.guna2ComboBox4, "Select Color");
            }
            else {
                errorProvider4.Clear();
            }
        }

        private void guna2NumericUpDown3_Leave(object sender, EventArgs e) {
            if (guna2NumericUpDown3.Value == 0) {
                guna2NumericUpDown3.Focus();
                errorProvider5.SetError(this.guna2NumericUpDown3, "Insert Length");
            }
            else {
                errorProvider5.Clear();
            }
        }

        private void guna2NumericUpDown4_Leave(object sender, EventArgs e) {
            if (guna2NumericUpDown4.Value == 0) {
                guna2NumericUpDown4.Focus();
                errorProvider6.SetError(this.guna2NumericUpDown4, "Insert Height");
            }
            else {
                errorProvider6.Clear();
            }
        }

        private void guna2NumericUpDown5_Leave(object sender, EventArgs e) {
            if (guna2NumericUpDown5.Value == 0) {
                guna2NumericUpDown5.Focus();
                errorProvider7.SetError(this.guna2NumericUpDown5, "Insert Age");
            }
            else {
                errorProvider7.Clear();
            }
        }

        private void guna2NumericUpDown2_Leave(object sender, EventArgs e) {
            if (guna2NumericUpDown2.Value == 0) {
                guna2NumericUpDown2.Focus();
                errorProvider8.SetError(this.guna2NumericUpDown2, "Insert Live Weight");
            }
            else {
                errorProvider8.Clear();
            }
        }

        private void guna2NumericUpDown1_Leave(object sender, EventArgs e) {
            if (guna2NumericUpDown1.Value == 0) {
                guna2NumericUpDown1.Focus();
                errorProvider9.SetError(this.guna2NumericUpDown1, "Insert Cost per Kg");
            }
            else {
                errorProvider9.Clear();
            }
        }

        private void guna2ComboBox3_Leave(object sender, EventArgs e) {
            if (guna2ComboBox3.SelectedIndex == 0) {
                guna2ComboBox3.Focus();
                errorProvider10.SetError(this.guna2ComboBox3, "Select Vaccination Status");
            }
            else {
                errorProvider10.Clear();
            }
        }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e) {
            bool isclicked = guna2CheckBox1.Checked;
            if(isclicked == true) {
                isHighlighted = "Yes";
            }
            else if(isclicked == false){
                isHighlighted = "No";
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e) {
            guna2TextBox6.Clear();
            guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
            guna2NumericUpDown5.ResetText();
            guna2NumericUpDown3.ResetText();
            guna2NumericUpDown4.ResetText();
            guna2NumericUpDown2.ResetText();
            guna2NumericUpDown1.ResetText();
            guna2ComboBox3.SelectedIndex = 0;
            guna2PictureBox1.Image = Properties.Resources._1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
