using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace AgroAssistUpdated {
    public partial class Form2 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        UserInfo usr = new UserInfo();
        public Form2() {
            InitializeComponent();
        }

        private void guna2CheckBox1_CheckedChanged_1(object sender, EventArgs e) {
            bool isClicked = guna2CheckBox1.Checked;
            if (isClicked) {
                guna2TextBox2.UseSystemPasswordChar = false;
            }
            else {
                guna2TextBox2.UseSystemPasswordChar = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            this.Close();
            Form1 f1 = new Form1();
            f1.TopLevel = false;
            panel1.Controls.Add(f1);
            f1.BringToFront();
            f1.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e) {
            //search in login acf username password and type then moves to specific windows
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "") {
                SqlConnection con = new SqlConnection(cs);
                string query = "SELECT * FROM Login_ACF WHERE a_Name = @name AND a_pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@pass", guna2TextBox2.Text);

                con.Open();
               
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows) {
                    errorProvider3.Clear();
                    r.Read();
                    string Atype = r["a_type"].ToString();
                    if (Atype == "Customer") {
                        usr.setName(r["a_Name"].ToString());
                        
                        Form4 f4 = new Form4();
                        f4.TopLevel = false;
                        panel1.Controls.Add(f4);
                        f4.BringToFront();
                        f4.Show();
                    }
                    else if(Atype == "FarmOwner") {
                        usr.setName(r["a_Name"].ToString());
                        usr.setFName(r["f_Name"].ToString());
                        Form8 f8 = new Form8();
                        f8.TopLevel = false;
                        panel1.Controls.Add(f8);
                        f8.BringToFront();
                        f8.Show();
                    }
                    else if(Atype == "Admin") {
                        usr.Name = r["a_Name"].ToString();
                        Form17 f17 = new Form17();
                        f17.TopLevel = false;
                        panel1.Controls.Add(f17);
                        f17.BringToFront();
                        f17.Show();
                    }
                }
                else {
                    errorProvider3.SetError(this.guna2Button1, "Username or Password is not correct");
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox1.PlaceholderText = "Re-enter Username";
                    guna2TextBox2.PlaceholderText = "Re-enter Password";
                }
                con.Close();
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e) {
            if(guna2TextBox1.Text == "") {
                guna2TextBox1.Focus();
                errorProvider1.SetError(this.guna2TextBox1, "Enter UserName");
            }
            else {
                errorProvider1.Clear();
            }
        }

        private void guna2TextBox2_Leave(object sender, EventArgs e) {
            if (guna2TextBox2.Text == "") {
                guna2TextBox2.Focus();
                errorProvider2.SetError(this.guna2TextBox2, "Enter Password");
            }
            else {
                errorProvider2.Clear();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
