using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace OXO
{
    public partial class Form1 : Form
    {
        static int localPort;
        static IPAddress localIPAddress;
        static string host = Dns.GetHostName();
        public static string user;
        static Random rnd = new Random();
        public Form1()
        {
            DataForms.ListForms.Add(this);
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            localPort = 5012;
            IPAddress address = Dns.GetHostAddresses(host).First<IPAddress>
                (f => f.AddressFamily == AddressFamily.InterNetwork);
            if (address != null)
            {
                localIPAddress = address;
            }
            
            user = localIPAddress + "/" + localPort;
            label2.Text = "Ваш Адресс: " + user;

        }
        //public void Send()
        //{
        //    Form2 obj2 = this.Owner as Form2;
        //    if (obj2 != null)
        //    {
        //        obj2.label14.Text = label3.Text;
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 obj2 = new Form2(this);
            //DataForms.ListForms.Add(obj2);
            //DataForms.ListForms[1].Show();
            obj2.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = listBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataForms.ListForms[0].Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
