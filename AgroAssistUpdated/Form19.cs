using System;

using System.Data;

using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace AgroAssistUpdated {
    public partial class Form19 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form19() {
            InitializeComponent();
            BindGridView();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Bold);
            dataGridView1.Columns["Name"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Password"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Nid"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["FarmName"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["FarmAddress"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Photo"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
        }
        DataTable data;
        void BindGridView() {
            //conncection of bd to gridview
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT a_Name AS Name, a_pass AS Password, f_Nid AS Nid, f_farmName AS FarmName, f_farmAddress AS FarmAddress, " +
                "f_photo AS Photo FROM FarmOwner;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
            dataGridView1.RowTemplate.Height = 50; 
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            panel3.AutoScroll = false;
            Form23 f23 = new Form23();
            f23.TopLevel = false;
            panel3.Controls.Add(f23);
            f23.BringToFront();
            f23.Show();

            f23.guna2TextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f23.guna2TextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f23.guna2TextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f23.guna2TextBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            f23.guna2TextBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            f23.guna2PictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);

        }
        private Image GetImage(byte[] photo) {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
