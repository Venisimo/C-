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
    public partial class Form3 : Form
    {
        string login;
        string password;
        string email;
        public static string connectSring = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DB_Users.accdb";
        OleDbConnection myConnection;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBank.ListForms[0].Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectSring);
            myConnection.Open();
            login = textBox1.Text;
            password = textBox3.Text;
            email = textBox2.Text;
            if (textBox3.Text != textBox4.Text)
            {
                label5.Text = "Пароль не совпадает...";
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                label5.Text = "Поля не должны быть пустыми";
            } else {
                if (password.Length < 8 || login.Length < 4)
                {
                    label5.Text = "Пароль или логин слишком короткий";
                }
                else if (password.Length > 20 || login.Length > 20)
                {
                    label5.Text = "Пароль или логин слишком короткий";
                }
                else
                {
                    string proverka = "SELECT Логин FROM Users WHERE Логин='" + login + "'";
                    OleDbCommand commandProverka = new OleDbCommand(proverka, myConnection);
                    OleDbDataReader reader = commandProverka.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows) {
                        label5.Text = "Такой логин уже существует";
                    } else {
                        string query = "INSERT INTO Users (Логин, Пароль, Почта) VALUES ('" + login.ToString() + "', '" + password.ToString() + "', '" + email.ToString() + "')";
                        //MessageBox.Show(query);
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        command.ExecuteNonQuery();
                        DataBank.ListForms[0].Show();
                        myConnection.Close();
                        this.Close();
                    }
                    
                }

            }
            myConnection.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') 
                || e.KeyChar == '$' || e.KeyChar == '!' || e.KeyChar == 08 || (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') 
                || e.KeyChar == '_' || e.KeyChar == 08 || (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))

            {
                return;
            }
            e.Handled = true;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBank.ListForms[0].Close();
        }
    }
}
