using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace AgroAssistUpdated {
    public partial class Form12 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form12() {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select l_token, l_type, l_Breed, l_color, l_Age, l_length," +
                "l_height, l_weight, l_pricePerKg, l_VaccinationStatus," +
                "l_Hoghlighted, l_image From Livestock WHERE l_token = @token;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.Parameters.AddWithValue("@token", guna2TextBox1.Text);
            con.Open();
            SqlDataReader r = cmd1.ExecuteReader();
            if (r.Read()) {
                guna2TextBox6.Text = r["l_token"].ToString();
                guna2ComboBox2.Text = r["l_type"].ToString();
                guna2ComboBox1.Text = r["l_Breed"].ToString();
                guna2ComboBox4.Text = r["l_color"].ToString();

                guna2NumericUpDown5.Value = Convert.ToInt32(r["l_Age"].ToString());
                guna2NumericUpDown3.Value = Convert.ToDecimal(r["l_length"].ToString());
                guna2NumericUpDown4.Value = Convert.ToDecimal(r["l_height"].ToString());
                guna2NumericUpDown2.Value = Convert.ToInt32(r["l_weight"].ToString());
                
                guna2NumericUpDown1.Value = Convert.ToInt32(r["l_pricePerKg"].ToString());

                guna2ComboBox3.Text = r["l_VaccinationStatus"].ToString();

                if (r["l_Hoghlighted"].ToString() == "1") {
                    guna2CheckBox1.Checked = true;
                }
                else {
                    guna2CheckBox1.Checked = false;
                }

                guna2PictureBox1.Image = GetImage((byte[])r["l_image"]);

            }
            con.Close();
        }

        private Image GetImage(byte[] photo) {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "DELETE FROM Livestock WHERE l_token = @token;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@token", guna2TextBox1.Text);
            con.Open();
            SqlDataReader Dr = cmd.ExecuteReader();
            if (!Dr.HasRows) {
                MessageBox.Show("Deleted");
            }
            else if(Dr.HasRows){
                MessageBox.Show("No such token number");
            }
           
            con.Close();
        }

    }
}
