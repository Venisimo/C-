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
    public partial class Form1 : Form
    {
        public static string connectSring = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DB_Users.accdb";
        OleDbConnection myConnection;
        string login = "";
        string password = "";
        public Form1()
        {
            DataBank.ListForms.Add(this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectSring);
            myConnection.Open();
            login = textBox1.Text;
            password = textBox2.Text;
            string query = "SELECT Пароль FROM Users WHERE Логин='" + login + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows) {
                if (password != reader[0].ToString())
                {
                    label3.Text = "Логин и/или пароль неверный";
                }
                else if (password == reader[0].ToString())
                {
                    Form2 obj2 = new Form2();
                    obj2.Show();
                    this.Hide();
                }
                myConnection.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 obj3 = new Form3();
            obj3.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
