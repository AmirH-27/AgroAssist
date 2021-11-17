using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace AgroAssistUpdated {
    public partial class Form18 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form18() {
            InitializeComponent();
            BindGridView();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Bold);
            dataGridView1.Columns["Name"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Password"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Nid"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Photo"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular); 
        }
        DataTable data;
        void BindGridView() {
            //conncection of bd to gridview
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT a_Name AS Name, a_pass AS Password, c_Nid AS Nid, c_photo AS Photo FROM Customer;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 80;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            guna2Panel1.AutoScroll = false;
            Form22 f22 = new Form22();
            f22.TopLevel = false;
            guna2Panel1.Controls.Add(f22);
            f22.BringToFront();
            f22.Show();

            f22.guna2TextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f22.guna2TextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f22.guna2TextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f22.guna2PictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);
        }
        private Image GetImage(byte[] photo) {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
