using System;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace AgroAssistUpdated {
    public partial class Form5 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int price, weight, pPerKg;
        Receipt r1 = new Receipt();
        UserInfo usr = new UserInfo();
        public Form5() {
            InitializeComponent();
            BindGridView();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Bold);
            dataGridView1.Columns["Token"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Type"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Breed"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Color"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Weight"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["TotalPrice"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["PurchaseStatus"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["TotalPrice"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Image"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
        }
        DataTable data;
        void BindGridView() {
            //conncection of bd to gridview
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT l_token AS Token, l_type AS Type, l_Breed AS Breed, l_color AS Color, " +
                "l_weight AS Weight, l_pricePerKg AS PricePerKg, l_purchaseStatus AS PurchaseStatus," +
                " l_totalPrice AS TotalPrice, l_image AS Image FROM SoldLivestock " +
                "WHERE l_purchaseStatus = 'Booked' AND a_Name = '" + usr.getName() + "';";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[8];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 70;
        }
    
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            panel3.AutoScroll = false;
            Form21 f21 = new Form21();
            f21.TopLevel = false;
            panel3.Controls.Add(f21);
            f21.BringToFront();
            f21.Show();

            f21.guna2TextBox6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f21.guna2TextBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f21.guna2TextBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            f21.guna2TextBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            f21.guna2TextBox8.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            f21.guna2TextBox9.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            weight = Convert.ToInt32(f21.guna2TextBox8.Text);
            pPerKg = Convert.ToInt32(f21.guna2TextBox9.Text);
            price = weight * pPerKg;
            f21.guna2TextBox12.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            f21.guna2TextBox4.Text = price.ToString();
            f21.guna2PictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[8].Value);

            
            r1.setToken(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            r1.setBreed(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            r1.setColor(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            r1.setWeight(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            r1.setPrice(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            r1.setTotal(price.ToString());
            r1.setName(usr.getName());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private Image GetImage(byte[] photo) {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }
        
    }
}
