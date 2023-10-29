using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Data.OleDb;

namespace UDPServer
{
    class DataBaseHandler
    {
        //public static string connectSring = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DB_Users.accdb";
        //OleDbConnection myConnection;

    }
    class StringHandler
    {
        public static string connectSring = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DB_Users.accdb";
        OleDbConnection myConnection;
        void startHandler()
        {
            myConnection = new OleDbConnection(connectSring);
            myConnection.Open();
        }
        void FSelect()
        {
            startHandler();
            

        }
        void FInsert()
        {

        }
        void FDelete()
        {

        }
        void FUpdate()
        {

        }

    }
    class Program
    {
        private static int localPort;
        private static int remotePort;
        private static IPAddress remoteIPAddress;
        static void Main(string[] args)
        {
            try
            {
                localPort = 5000;
                Thread tRec = new Thread(new ThreadStart(Reciver));
                tRec.Start();
                while (true)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение " + ex.ToString() + "\n" + ex.Message);
            }
            Console.WriteLine("Hello World!");
        }
        public static void Send(string data)
        {
            UdpClient sender = new UdpClient();
            IPEndPoint endpoint = new IPEndPoint(remoteIPAddress, remotePort);
            try
            {
                data = "ОТВЕТ/" + data;
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                sender.Send(bytes, bytes.Length, endpoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение " + ex.ToString() + "\n" + ex.Message);
            }
            finally
            {
                sender.Close();

            }


        }
        public static void Reciver()
        {
            UdpClient Recive = new UdpClient(localPort);
            IPEndPoint RemIPEndPoint = null;
            try
            {
                while (true)
                {
                    byte[] bytes = Recive.Receive(ref RemIPEndPoint);
                    string returnRecive = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine(returnRecive);
                    StringHandler.startHandler(returnData);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение " + ex.ToString() + "\n" + ex.Message);
            }
        }
    }
}
