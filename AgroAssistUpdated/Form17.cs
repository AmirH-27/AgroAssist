using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace AgroAssistUpdated {
    public partial class Form17 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form17() {
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

        private void guna2Button1_Click(object sender, EventArgs e) {
            panel3.AutoScroll = false;
            Form24 f24 = new Form24();
            f24.TopLevel = false;
            panel3.Controls.Add(f24);
            f24.BringToFront();
            f24.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            panel3.AutoScroll = false;
            Form10 f10 = new Form10();
            f10.TopLevel = false;
            panel3.Controls.Add(f10);
            panel3.AutoScroll = true;
            f10.BringToFront();
            f10.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e) {
            panel3.AutoScroll = true;
            Form11 f11 = new Form11();
            f11.TopLevel = false;
            panel3.Controls.Add(f11);
            f11.BringToFront();
            f11.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e) {
            panel3.AutoScroll = false;
            Form12 f12 = new Form12();
            f12.TopLevel = false;
            panel3.Controls.Add(f12);
            panel3.AutoScroll = true;
            f12.BringToFront();
            f12.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e) {
            panel3.AutoScroll = false;
            Form26 f26 = new Form26();
            f26.TopLevel = false;
            panel3.Controls.Add(f26);
            f26.BringToFront();
            f26.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e) {
            panel3.AutoScroll = false;
            Form14 f14 = new Form14();
            f14.TopLevel = false;
            panel3.Controls.Add(f14);
            f14.BringToFront();
            f14.Show();
        }

        private void guna2Button11_Click(object sender, EventArgs e) {
            panel3.AutoScroll = false;
            Form18 f18 = new Form18();
            f18.TopLevel = false;
            panel3.Controls.Add(f18);
            f18.BringToFront();
            f18.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e) {
            this.Close();
            Form1 f2 = new Form1();
            f2.TopLevel = false;
            guna2Panel1.Controls.Add(f2);
            f2.BringToFront();
            f2.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e) {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
            f1.Close();
        }

        private void guna2Button12_Click(object sender, EventArgs e) {
            panel3.AutoScroll = false;
            Form19 f19 = new Form19();
            f19.TopLevel = false;
            panel3.Controls.Add(f19);
            f19.BringToFront();
            f19.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e) {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            panel3.AutoScroll = true;
            Form11 f11 = new Form11();
            f11.TopLevel = false;
            panel3.Controls.Add(f11);
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

        private Image GetImage(byte[] photo) {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {
            DataView dv = new DataView(data);
            dv.RowFilter = string.Format("Breed LIKE '%{0}%'", guna2TextBox1.Text);
            dataGridView1.DataSource = dv;
        }
    }
}
