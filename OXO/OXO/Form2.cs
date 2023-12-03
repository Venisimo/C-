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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OXO
{
    public static class Proverka
    {
        public static bool pr = false;
    }
    public partial class Form2 : Form
    {
        static Random rnd = new Random();
        static int[,] array = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static int hod;
        static IPAddress enemyIPAddress;
        static Thread trec;
        static string you;
        static int localPort = 5012;
        static string enemy;
        static string[] words;
        static int enemyPort;
        static int XO;
        static bool CheckChoise = false;
        static int CheckUpdate = 0;
        static bool chekX = false;
        static bool chekO = false;
        static string data;
        static string[] enemyData;
        static int i;
        static int j;
        static int a;
        static int b;
        Form1 tt;
        static int ValueArr;
        public Form2(Form1 obj1)
        {
            tt = obj1;
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            enemy = tt.label3.Text;
            words = enemy.Split(new char[] { '/' });
            enemyIPAddress = IPAddress.Parse(words[0]);
            enemyPort = Int32.Parse(words[1]);
            you = Form1.user;
            DisabledButton();
            trec = new Thread(new ThreadStart(Reciver));
            trec.Start();
            if (Proverka.pr == true)
            {
                CheckGroupBoxChoise(CheckChoise);
                UpdateArray(a, b, ValueArr);
                UpdateInterface(a, b);
            }
            //Record(i, j, hod, CheckChoise);
        }
        public static void Record(int i, int j, int hod, bool CheckChoise)
        {
            try
            {
                data = i.ToString() + "/" + j.ToString() + "/" + array[i, j].ToString() + "/" + hod.ToString() + "/" + CheckChoise.ToString();
                Console.WriteLine(data);
                Send(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ОШИБКА: " + ex.Message);
            }
        }
        public static void Send(string data)
        {
            UdpClient sender = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(enemyIPAddress, enemyPort);
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                sender.Send(bytes, bytes.Length, endPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка:" + ex.Message);
            }
            finally
            {
                //sender.Close();

            }
        }
        public void Reciver()
        {
            UdpClient Recive = new UdpClient(localPort);
            IPEndPoint RemIPEndPoint = null;
            try
            {
                while (true)
                {
                    byte[] bytes = Recive.Receive(ref RemIPEndPoint);
                    string returnRecive = Encoding.UTF8.GetString(bytes);
                    enemyData = returnRecive.Split(new char[] { '/' });
                    Console.WriteLine("Receive index 1:" + enemyData[0]);
                    Console.WriteLine("Receive index 2: " + enemyData[1]);
                    Console.WriteLine("Receive Array:" + enemyData[2]);
                    Console.WriteLine("Receive - Hod: " + enemyData[3]);
                    Console.WriteLine("Receive - CheckChoise: " + enemyData[4]);

                    Console.WriteLine("Receive index 1:" + Convert.ToInt32(enemyData[0]));
                    Console.WriteLine("Receive index 2: " + Convert.ToInt32(enemyData[1]));
                    Console.WriteLine("Receive Array:" + Convert.ToInt32(enemyData[2]));
                    Console.WriteLine("Receive - Hod: " + Convert.ToInt32(enemyData[3]));
                    Console.WriteLine("Receive - CheckChoise: " + Convert.ToBoolean(enemyData[4]));

                    a = Convert.ToInt32(enemyData[0]);
                    b = Convert.ToInt32(enemyData[1]);
                    ValueArr = Convert.ToInt32(enemyData[2]);
                    CheckChoise = Convert.ToBoolean(enemyData[4]);
                    Proverka.pr = true;
                    Console.WriteLine(a.GetType());
                    Console.WriteLine(b.GetType());
                    Console.WriteLine(ValueArr.GetType());
                    Console.WriteLine(CheckChoise.GetType());

                   
                    //CloseThread();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);

            }
        }
        //public static void CloseThread()
        //{
        //    trec.Abort();
        //}
        public void CheckGroupBoxChoise(bool CheckChoise)
        {
            if (CheckChoise == false)
            {

            }
            else if (CheckChoise == true)
            {
                if (hod == 1)
                {
                    label14.Text = enemyIPAddress + "/" + enemyPort;
                    label15.Text = you;
                    chekO = true;
                    Console.WriteLine("CheckGroupBoxChoise работает");
                }
                else if (hod == 2)
                {
                    label15.Text = enemyIPAddress + "/" + enemyPort;
                    label14.Text = you;
                    chekX = true;
                    Console.WriteLine("CheckGroupBoxChoise работает");
                }
                Console.WriteLine(CheckChoise);
                Console.WriteLine("CheckGroupBoxChoise работает");
                EnabledButton();
                groupBox1.Hide();
            }
        }
        public void ChekHod()
        {
            if (hod % 2 != 0)
            {
                if (chekX == true)
                {
                    EnabledButton();
                }
                else
                {
                    DisabledButton();
                }
            }
            else if (hod % 2 == 0)
            {
                if (chekO == true)
                {
                    EnabledButton();
                }
                else
                {
                    DisabledButton();
                }
            }

        }
        public void UpdateArray(int a, int b, int ValueArr)
        {
            array[a, b] = ValueArr;
            Console.WriteLine("Update Array работает");
            Console.WriteLine(array[0, 0]);
        }
        public void UpdateInterface(int a, int b)
        {
            Console.WriteLine(array[0, 0]);
            Console.WriteLine(array[a, b]);
            if (array[0, 0] == array[a, b])
            {
                button2.Text = GetValueForButton(array[a, b]);
                Console.WriteLine(button2.Text);
                Console.WriteLine("Update interface работает");

            }
            else if (array[0, 1] == array[a, b])
            {
                button3.Text = GetValueForButton(array[0, 1]);
            }
            else if (array[0, 2] == array[a, b])
            {
                button4.Text = GetValueForButton(array[0, 2]);
            }
            else if (array[1, 0] == array[a, b])
            {
                button5.Text = GetValueForButton(array[1, 0]);
            }
            else if (array[1, 1] == array[a, b])
            {
                button6.Text = GetValueForButton(array[1, 1]);
            }
            else if (array[1, 2] == array[a, b])
            {
                button7.Text = GetValueForButton(array[1, 2]);
            }
            else if (array[2, 0] == array[a, b])
            {
                button8.Text = GetValueForButton(array[2, 0]);
            }
            else if (array[2, 1] == array[a, b])
            {
                button9.Text = GetValueForButton(array[2, 1]);
            }
            else if (array[2, 2] == array[a, b])
            {
                button10.Text = GetValueForButton(array[2, 2]);
            }
            Console.WriteLine(array[a, b]);

        }
        // Метод для определения текста для кнопки на основе значения в массиве
        public string GetValueForButton(int value)
        {
            switch (value)
            {
                case 0:
                    return "";
                case 1:
                    return "X";
                case 2:
                    return "O";
                default:
                    return "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            tt.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (array[0, 0] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[0, 0] = 1;
                    button2.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[0, 0] = 2;
                    button2.Text = "O";
                    hod++;
                }
            }
            else
            {
                button2.Text = button2.Text;
            }
            i = 0;
            j = 0;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (array[0, 1] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[0, 1] = 1;
                    button3.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[0, 1] = 2;
                    button3.Text = "O";
                    hod++;
                }
            }
            else
            {
                button3.Text = button3.Text;
            }
            i = 0;
            j = 1;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (array[0, 2] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[0, 2] = 1;
                    button4.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[0, 2] = 2;
                    button4.Text = "O";
                    hod++;
                }
            }
            else
            {
                button4.Text = button4.Text;
            }
            i = 0;
            j = 2;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (array[1, 0] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[1, 0] = 1;
                    button5.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[1, 0] = 2;
                    button5.Text = "O";
                    hod++;
                }
            }
            else
            {
                button5.Text = button5.Text;
            }
            i = 1;
            j = 0;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (array[1, 1] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[1, 1] = 1;
                    button6.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[1, 1] = 2;
                    button6.Text = "O";
                    hod++;
                }
            }
            else
            {
                button6.Text = button6.Text;
            }
            i = 1;
            j = 1;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (array[1, 2] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[1, 2] = 1;
                    button7.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[1, 2] = 2;
                    button7.Text = "O";
                    hod++;
                }
            }
            else
            {
                button7.Text = button7.Text;
            }
            i = 1;
            j = 2;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (array[2, 0] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[2, 0] = 1;
                    button8.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[2, 0] = 2;
                    button8.Text = "O";
                    hod++;
                }
            }
            else
            {
                button8.Text = button8.Text;
            }
            i = 2;
            j = 0;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (array[2, 1] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[2, 1] = 1;
                    button9.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[2, 1] = 2;
                    button9.Text = "O";
                    hod++;
                }
            }
            else
            {
                button9.Text = button9.Text;
            }
            i = 2;
            j = 1;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (array[2, 2] == 0)
            {
                if (hod % 2 != 0)
                {
                    array[2, 2] = 1;
                    button10.Text = "X";
                    hod++;
                }
                else if (hod % 2 == 0)
                {
                    array[2, 2] = 2;
                    button10.Text = "O";
                    hod++;
                }
            }
            else
            {
                button10.Text = button10.Text;
            }
            i = 2;
            j = 2;
            Record(i, j, hod, CheckChoise);

            Viktory();
        }
        public void EnabledButton()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
        }
        public void DisabledButton()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
        }
        public void Viktory()
        {

            int Viktroy = 0;
            if (array[0, 0] == 1 && array[0, 1] == 1 && array[0, 2] == 1)
            {
                Viktroy = 1;
                DisabledButton();
            }
            else if (array[1, 0] == 1 && array[1, 1] == 1 && array[1, 2] == 1)
            {
                DisabledButton();
                Viktroy = 1;
            }
            else if (array[2, 0] == 1 && array[2, 1] == 1 && array[2, 2] == 1)
            {
                DisabledButton();
                Viktroy = 1;
            }
            // ПО ГОРИЗОНТАЛИ 
            else if (array[0, 0] == 1 && array[1, 0] == 1 && array[2, 0] == 1)
            {
                DisabledButton();
                Viktroy = 1;
            }
            else if (array[0, 1] == 1 && array[1, 1] == 1 && array[2, 1] == 1)
            {
                Viktroy = 1;
            }
            else if (array[0, 2] == 1 && array[1, 2] == 1 && array[2, 2] == 1)
            {
                DisabledButton();
                Viktroy = 1;
            }
            // ПО ВЕРТИКАЛИ
            else if (array[0, 2] == 1 && array[1, 1] == 1 && array[2, 0] == 1)
            {
                DisabledButton();
                Viktroy = 1;
            }
            // ПО ДИАГОНАЛИ ВЛЕВО
            else if (array[0, 0] == 1 && array[1, 1] == 1 && array[2, 2] == 1)
            {
                DisabledButton();
                Viktroy = 1;
            }
            // ПО ДИАГОНАЛИ ВПРАВО


            if (array[0, 0] == 2 && array[0, 1] == 2 && array[0, 2] == 2)
            {
                Viktroy = 2;
            }
            else if (array[1, 0] == 2 && array[1, 1] == 2 && array[1, 2] == 2)
            {
                Viktroy = 2;
            }
            else if (array[2, 0] == 2 && array[2, 1] == 2 && array[2, 2] == 2)
            {
                Viktroy = 2;
            }
            // ПО ГОРИЗОНТАЛИ 
            else if (array[0, 0] == 2 && array[1, 0] == 2 && array[2, 0] == 2)
            {
                Viktroy = 2;
            }
            else if (array[0, 1] == 2 && array[1, 1] == 2 && array[2, 1] == 2)
            {
                Viktroy = 2;
            }
            else if (array[0, 2] == 2 && array[1, 2] == 2 && array[2, 2] == 2)
            {
                Viktroy = 2;
            }
            // ПО ВЕРТИКАЛИ
            else if (array[0, 2] == 2 && array[1, 1] == 2 && array[2, 0] == 2)
            {
                Viktroy = 2;
            }
            // ПО ДИАГОНАЛИ ВЛЕВО
            else if (array[0, 0] == 2 && array[1, 1] == 2 && array[2, 2] == 2)
            {
                Viktroy = 2;
            }
            // ПО ДИАГОНАЛИ ВПРАВО





            if (Viktroy == 1)
            {
                DisabledButton();
                label1.Text = "ПОБЕДИЛ: X";
            }
            else if (Viktroy == 2)
            {
                DisabledButton();
                label1.Text = "ПОБЕДИЛ: O";
            }
            else if (array[0, 0] != 0 && array[0, 1] != 0 && array[0, 2] != 0
                && array[1, 0] != 0 && array[1, 1] != 0 && array[1, 2] != 0
                && array[2, 0] != 0 && array[2, 1] != 0 && array[2, 2] != 0
                && array[0, 0] != 0 && array[1, 0] != 0 && array[2, 0] != 0
                && array[0, 1] != 0 && array[1, 1] != 0 && array[2, 1] != 0
                && array[0, 2] != 0 && array[1, 2] != 0 && array[2, 2] != 0
                && array[0, 2] != 0 && array[1, 1] != 0 && array[2, 0] != 0
                && array[0, 0] != 0 && array[1, 1] != 0 && array[2, 2] != 0)
            {
                DisabledButton();
                label2.Text = "НИЧЬЯ";
            }

        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (XO == 0)
            {
                hod = 1;
                label14.Text = you;
                label15.Text = enemyIPAddress + "/" + enemyPort;
                chekX = true;
                EnabledButton();
                groupBox1.Hide();
                CheckChoise = true;
                Record(i, j, hod, CheckChoise);
            }
            else if (XO == 1)
            {
                label15.Text = you;
                label14.Text = enemyIPAddress + "/" + enemyPort;
                hod = 2;
                chekO = true;
                EnabledButton();
                groupBox1.Hide();
                CheckChoise = true;
                Record(i, j, hod, CheckChoise);
            }
            else
            {

            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XO = listBox1.SelectedIndex;
            Console.WriteLine(XO);
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
