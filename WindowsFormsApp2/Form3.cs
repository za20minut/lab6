using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int liczba1 = int.Parse(textBox1.Text);
            globaln.X = liczba1;
            int liczba2 = int.Parse(textBox2.Text);
            globaln.Y = liczba2;
            int liczba3 = int.Parse(textBox3.Text);
            globaln.dydelf = liczba3;
            int liczba4 = int.Parse(textBox4.Text);
            globaln.krokodyl = liczba4;
            int liczba5 = int.Parse(textBox5.Text);
            globaln.czas = liczba5;
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
