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
    public partial class Form14 : Form {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        UserInfo usr = new UserInfo();
        string selectedToken;
        public Form14() {
            InitializeComponent();
            BindGridView();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Bold);
            dataGridView1.Columns["Token"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Date"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);
            dataGridView1.Columns["Name"].DefaultCellStyle.Font = new Font("Georgia", 10, FontStyle.Regular);

        }
        DataTable data;
        void BindGridView() {
            //conncection of bd to gridview
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT l_token AS Token, b_dateTime As Date, a_name As Name FROM Appointment"; 
               
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            if (selectedToken != null) {
                SqlConnection con = new SqlConnection(cs);
                string query = "DELETE FROM Appointment WHERE l_token = @token;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@token", selectedToken);
                con.Open();
                SqlDataReader Dr = cmd.ExecuteReader();
                if (!Dr.HasRows) {
                    MessageBox.Show("Deleted");
                }
                else if (Dr.HasRows) {
                    MessageBox.Show("No such token number");
                }

                con.Close();
            }
            else {
                MessageBox.Show("Must Double Click on a cell to delete");
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            selectedToken = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
