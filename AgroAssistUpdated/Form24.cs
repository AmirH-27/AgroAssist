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
    public partial class Form24 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form24() {
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
            dataGridView1.Columns["Name"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);

        }
        DataTable data;
        void BindGridView() {
            //conncection of bd to gridview
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT l_token AS Token, l_type AS Type, l_Breed AS Breed, l_color AS Color, " +
                "l_Age AS Age, l_length AS Length, l_height AS Height, l_weight AS Weight, l_pricePerKg AS Price_Per_Kg, " +
                "l_VaccinationStatus AS Vaccine_Status," +
                "l_Hoghlighted AS Highlighted, l_image AS Image, a_Name AS Name FROM Livestock;";
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {
            DataView dv = new DataView(data);
            dv.RowFilter = string.Format("Breed LIKE '%{0}%'", guna2TextBox1.Text);
            dataGridView1.DataSource = dv;
        }

        private Image GetImage(byte[] photo) {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            panel1.AutoScroll = true;
            Form11 f11 = new Form11();
            f11.TopLevel = false;
            panel1.Controls.Add(f11);
            f11.BringToFront();
            f11.Show();

            f11.guna2TextBox6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f11.guna2ComboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f11.guna2ComboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f11.guna2ComboBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            f11.guna2NumericUpDown5.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            f11.guna2NumericUpDown3.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            f11.guna2NumericUpDown4.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            f11.guna2NumericUpDown2.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
            f11.guna2NumericUpDown1.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());

            f11.guna2ComboBox3.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();


            if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() == "1") {
                f11.guna2CheckBox1.Checked = true;
            }
            else {
                f11.guna2CheckBox1.Checked = false;
            }

            f11.guna2PictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[11].Value);
        }

        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e) {
            panel1.AutoScroll = true;
            Form11 f11 = new Form11();
            f11.TopLevel = false;
            panel1.Controls.Add(f11);
            f11.BringToFront();
            f11.Show();

            f11.guna2TextBox6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f11.guna2ComboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f11.guna2ComboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f11.guna2ComboBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            f11.guna2NumericUpDown5.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            f11.guna2NumericUpDown3.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            f11.guna2NumericUpDown4.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            f11.guna2NumericUpDown2.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
            f11.guna2NumericUpDown1.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());

            f11.guna2ComboBox3.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();


            if (dataGridView1.SelectedRows[0].Cells[10].Value.ToString() == "1") {
                f11.guna2CheckBox1.Checked = true;
            }
            else {
                f11.guna2CheckBox1.Checked = false;
            }

            f11.guna2PictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[11].Value);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
