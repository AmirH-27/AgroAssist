using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace AgroAssistUpdated {
    public partial class Form7 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int price, weight, pPerKg;
        public Form7() {
            InitializeComponent();
            BindGridView();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Bold);
            dataGridView1.Columns["Token"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Type"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Breed"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Color"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Age"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Length"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Height"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Weight"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Price_per_Kg"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Vaccine_Status"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Highlighted"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Image"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["FName"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
        }
        DataTable data;
        void BindGridView() {
            //conncection of bd to gridview
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT l_token AS Token, l_type AS Type, l_Breed AS Breed, l_color AS Color, " +
                "l_Age AS Age, l_length AS Length, l_height AS Height, l_weight AS Weight, l_pricePerKg AS Price_Per_Kg, l_VaccinationStatus AS Vaccine_Status," +
                "l_Hoghlighted AS Highlighted, l_image AS Image, f_farmName AS FName FROM Livestock ;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[11];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            panel3.AutoScroll = true;
            Form20 f20 = new Form20();
            f20.TopLevel = false;
            panel3.Controls.Add(f20);
            f20.BringToFront();
            f20.Show();

            f20.guna2TextBox6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f20.guna2TextBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f20.guna2TextBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f20.guna2TextBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            f20.guna2TextBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            f20.guna2TextBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            f20.guna2TextBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            f20.guna2TextBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            f20.guna2TextBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            f20.guna2TextBox10.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();


            if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() == "1") {
                f20.guna2TextBox11.Text = "Yes";
            }
            else {
                f20.guna2TextBox11.Text = "No";
            }
            //price = double.TryParse(f20.guna2TextBox8.Text, out weight) * double.TryParse(f20.guna2TextBox9.Text, out pPrice);
            weight = Convert.ToInt32(f20.guna2TextBox8.Text);
            pPerKg = Convert.ToInt32(f20.guna2TextBox9.Text);
            price = weight * pPerKg;
            f20.guna2TextBox12.Text = price.ToString();
            f20.guna2PictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[11].Value);
            f20.guna2TextBox13.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
          
            
   
        }

        private Image GetImage(byte[] photo) {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e) {
            DataView dv = new DataView(data);
            dv.RowFilter = string.Format("l_Breed LIKE '%{0}%'", guna2TextBox2.Text);
            dataGridView1.DataSource = dv;
        }
    }
}
