using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroAssistUpdated {
    public partial class Form16 : Form {
        public Form16() {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            this.Close();
            Form1 f1 = new Form1();
            f1.TopLevel = false;
            guna2Panel1 .Controls.Add(f1);
            f1.BringToFront();
            f1.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/AmirH-27");
        }
    }
}
