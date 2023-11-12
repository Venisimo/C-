using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OXO
{
    public partial class Form2 : Form
    {
        static Random rnd = new Random();
        static int[,] array = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static int Hod = 1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            this.Hide();
            obj1.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (array[0, 0] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[0, 0] = 1;
                    button2.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[0, 0] = 2;
                    button2.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button2.Text = button2.Text;
            }
            Viktory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (array[0, 1] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[0, 1] = 1;
                    button3.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[0, 1] = 2;
                    button3.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button3.Text = button3.Text;
            }
            Viktory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (array[0, 2] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[0, 2] = 1;
                    button4.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[0, 2] = 2;
                    button4.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button4.Text = button4.Text;
            }
            Viktory();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (array[1, 0] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[1, 0] = 1;
                    button5.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[1, 0] = 2;
                    button5.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button5.Text = button5.Text;
            }
            Viktory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (array[1, 1] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[1, 1] = 1;
                    button6.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[1, 1] = 2;
                    button6.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button6.Text = button6.Text;
            }
            Viktory();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (array[1, 2] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[1, 2] = 1;
                    button7.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[1, 2] = 2;
                    button7.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button7.Text = button7.Text;
            }
            Viktory();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (array[2, 0] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[2, 0] = 1;
                    button8.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[2, 0] = 2;
                    button8.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button8.Text = button8.Text;
            }
            Viktory();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (array[2, 1] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[2, 1] = 1;
                    button9.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[2, 1] = 2;
                    button9.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button9.Text = button9.Text;
            }
            Viktory();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (array[2, 2] == 0)
            {
                if (Hod % 2 != 0)
                {
                    array[2, 2] = 1;
                    button10.Text = "X";
                    Hod++;
                }
                else if (Hod % 2 == 0)
                {
                    array[2, 2] = 2;
                    button10.Text = "O";
                    Hod++;
                }
            }
            else
            {
                button10.Text = button10.Text;
            }
            Viktory();
        }
        public void Viktory() 
        {
            for (int i = 0; i <= 2; i++)
            {
                if (array[0, i] == 'X')
                {
                    label1.Text = "ПОБЕДИЛ: X";
                }
                else if (array[i, 0] == 'X')
                {
                    label1.Text = "ПОБЕДИЛ: X";
                }
                else if (array[i, i] == 'X')
                {
                    label1.Text = "ПОБЕДИЛ: X";
                }
                else
                {
                    for (int j = 2; j >= 0; j--)
                    {
                        if (array[j, i] == 'X')
                        {
                            label1.Text = "ПОБЕДИЛ: X";
                        }
                        else
                        {
                            label1.Text = label1.Text;
                        }
                    }
                }

                if (array[0, i] == 'O')
                {
                    label1.Text = "ПОБЕДИЛ: O";
                }
                else if (array[i, 0] == 'O')
                {
                    label1.Text = "ПОБЕДИЛ: O";
                }
                else if (array[i, i] == 'O')
                {
                    label1.Text = "ПОБЕДИЛ: O";
                }
                else 
                {
                    for (int j = 2; j >= 0; j--)
                    {
                        if (array[j, i] == 'O')
                        {
                            label1.Text = "ПОБЕДИЛ: O";
                        }
                        else
                        {
                            label1.Text = label1.Text;
                        }
                    }
                }
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
