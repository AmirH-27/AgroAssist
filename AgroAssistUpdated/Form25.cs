using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroAssistUpdated {
    public partial class Form25 : Form {
        PrintPreviewDialog pp = new PrintPreviewDialog();
        PrintDocument printDoc = new PrintDocument();
        Receipt r1 = new Receipt();
        public Form25() {
            InitializeComponent();
            guna2TextBox1.Text = r1.getToken();
            guna2TextBox2.Text = r1.getBreed();
            guna2TextBox3.Text = r1.getColor();
            guna2TextBox4.Text = r1.getWeight();
            guna2TextBox5.Text = r1.getPrice();
            guna2TextBox6.Text = r1.getTotal();
            guna2TextBox7.Text = r1.getName();
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            Print(this.panel1);
        }

        public void Print(Panel pn1) {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pn1;
            getPrintArea(pn1);
            pp.Document = printDoc;
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_printpage);
            pp.ShowDialog();

        }

        private void printDoc_printpage(object sender, PrintPageEventArgs e) {
            Rectangle pageArea = e.PageBounds;
            e.Graphics.DrawImage(memmory, (pageArea.Width / 2) - this.panel1.Width / 2, this.panel1.Location.Y);

        }

        Bitmap memmory;
        public void getPrintArea(Panel p1) {
            memmory = new Bitmap(p1.Width, p1.Height);
            p1.DrawToBitmap(memmory, new Rectangle(0, 50, p1.Width, 50+p1.Height));
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
