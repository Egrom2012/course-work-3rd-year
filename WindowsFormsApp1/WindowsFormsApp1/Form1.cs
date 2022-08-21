using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Connector.connectionString = "Data Source=" + textBox1.Text + ";Initial Catalog = autosalon; Integrated Security = True";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Zapros1 zapros1 = new Zapros1();
            zapros1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Zapros2 zapros2 = new Zapros2();
            zapros2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Zapros3 zapros3 = new Zapros3();
            zapros3.Show();
        }
    }
}
