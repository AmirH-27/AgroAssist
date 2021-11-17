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
    public partial class Form20 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        bool exist;
        UserInfo usr = new UserInfo();
    
        public Form20() {
            InitializeComponent();
        }
  
        private void guna2Button2_Click(object sender, EventArgs e) {
            
        }
        public byte[] savePhoto() {
            MemoryStream ms = new MemoryStream();
            guna2PictureBox1.Image.Save(ms, guna2PictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "INSERT INTO SoldLivestock " +
                "VALUES(@token, @type, @breed, @color," +
                "@weight, @price, @status, @totalPrice, @image, @name, @Fname);";
            string checkQuery = "Select * From SoldLivestock WHERE l_token = @token;";
            string updateQuery = "Update SoldLivestock set l_purchaseStatus = 'Booked' WHERE l_token = @token And l_purchaseStatus = 'Unsold';";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmdCheck = new SqlCommand(checkQuery, con);
            SqlCommand cmdUpdate = new SqlCommand(updateQuery, con);

            cmd.Parameters.AddWithValue("@token", guna2TextBox6.Text);
            cmd.Parameters.AddWithValue("@type", guna2TextBox1.Text);
            cmd.Parameters.AddWithValue("@breed", guna2TextBox2.Text);
            cmd.Parameters.AddWithValue("@color", guna2TextBox3.Text);
            cmd.Parameters.AddWithValue("@weight", guna2TextBox8.Text);
            cmd.Parameters.AddWithValue("@price", guna2TextBox9.Text);
            cmd.Parameters.AddWithValue("@status", "Booked");
            cmd.Parameters.AddWithValue("@totalPrice", Convert.ToInt32(guna2TextBox12.Text));

            cmd.Parameters.AddWithValue("@image", savePhoto());
            cmd.Parameters.AddWithValue("@name", usr.getName());
            cmd.Parameters.AddWithValue("@Fname", guna2TextBox13.Text);

            cmdCheck.Parameters.AddWithValue("@token", guna2TextBox6.Text);

            cmdUpdate.Parameters.AddWithValue("@token", guna2TextBox6.Text);

            con.Open();

            SqlDataReader r = cmdCheck.ExecuteReader();
            if (r.HasRows) {
                guna2Button2.Focus();
                errorProvider1.SetError(this.guna2Button2, "UserName Already exists ");
                exist = true;
            }
            con.Close();
            con.Open();
            if (exist != true) {
                int a = cmd.ExecuteNonQuery();
                if (a <= 0) {
                    guna2Button2.Focus();
                    MessageBox.Show("Livestock Not Inserted");
                }
                else {
                    int b = cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Livestock Inserted");
                }
            }
            con.Close();
        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e) {

        }
    }
}
