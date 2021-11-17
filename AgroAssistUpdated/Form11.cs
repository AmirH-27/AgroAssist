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
    public partial class Form11 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
      
        public Form11() {
            InitializeComponent();
            
        }

        private void guna2Button1_Click_1(object sender, EventArgs e) {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select Image";
            open.Filter = "All Image Files *.*)|*.*";
            //open.ShowDialog();
            if (open.ShowDialog() == DialogResult.OK) {
                guna2PictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE Livestock SET l_token=@token, l_type=@type, l_Breed=@breed, l_color=@color," +
                " l_Age=@age, l_length=@length, l_height=@height, " +
                "l_weight=@weight, l_pricePerKg=@price, l_VaccinationStatus=@vaccine, " +
                "l_Hoghlighted=@highlight, l_image=@image WHERE l_token = @token;";

            SqlCommand cmd = new SqlCommand(query, con);

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

            con.Open();
          
            int a = cmd.ExecuteNonQuery();
            if (a <= 0) {
                guna2Button2.Focus();
                errorProvider1.SetError(this.guna2Button2, "Fill out all the details");
            }
            else {
                errorProvider1.Clear();
                MessageBox.Show("Livestock Updated");
            }
            con.Close();

        }

        private byte[] savePhoto() {
            using (MemoryStream ms = new MemoryStream()) {
                
               guna2PictureBox1.Image.Save(ms, guna2PictureBox1.Image.RawFormat);
               return ms.GetBuffer();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
