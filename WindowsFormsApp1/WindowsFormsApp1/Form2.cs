using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBank.ListForms[0].Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String s = textBox1.SelectedText;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
            textBox1.SelectedText = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String stroka = textBox1.SelectedText;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox1.SelectedText = stroka;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String stroka = textBox1.SelectedText;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
            textBox1.SelectedText = stroka;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String stroka = textBox1.SelectedText;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Underline);
            textBox1.SelectedText = stroka;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String stroka = textBox1.SelectedText;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Strikeout);
            textBox1.SelectedText = stroka;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
    }
}
