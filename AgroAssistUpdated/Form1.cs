using System;
using System.Windows.Forms;

namespace AgroAssistUpdated {
    public partial class Form1 : Form {
        
        public Form1() {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e) {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            //goes to login window
            
            Form2 f2 = new Form2();
            f2.TopLevel = false;
            panel1.Controls.Add(f2);
            f2.BringToFront();
            f2.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {     
            //goes to signup window
            Form3 f3 = new Form3();
            f3.TopLevel = false;
            panel1.Controls.Add(f3);
            f3.BringToFront();
            f3.Show();     
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void guna2Button4_Click(object sender, EventArgs e) {
            //about
            Form16 f16 = new Form16();
            f16.TopLevel = false;
            panel1.Controls.Add(f16);
            f16.BringToFront();
            f16.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e) {
            //contact us
            Form15 f15 = new Form15();
            f15.TopLevel = false;
            panel1.Controls.Add(f15);
            f15.BringToFront();
            f15.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
