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
        public static string connectSring = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DB_Users.accdb";
        static OleDbConnection myConnection;
        public static string remoteReq;
        public static void startHandler()
        {
            myConnection = new OleDbConnection(connectSring);
            myConnection.Open();
        
        }
        public static void setReq(string req)
        {
            remoteReq = req;
            string subRemoteReq;
            subRemoteReq = remoteReq.Substring(0, 6);
            Console.WriteLine(remoteReq);
            if (subRemoteReq == "SELECT")
            {
                MethodSELECT();
            }
            else if (subRemoteReq == "INSERT")
            {
                MethodINSERT();
            }
            else if (subRemoteReq == "DELETE")
            {
                MethodDELETE();
            }
            else if (subRemoteReq == "UPDATE")
            {
                MethodUPDATE();
            }
        }
        
        public static void MethodSELECT()
        {
            string vidvod = "";
            startHandler();
            OleDbCommand coomandProverka = new OleDbCommand(remoteReq, myConnection);
            OleDbDataReader reader = coomandProverka.ExecuteReader();
            while (reader.Read()) 
            {
                if (reader.HasRows)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        vidvod += reader[i];
                    }
                    Console.WriteLine(vidvod);
                }
            }
            Program.Send(vidvod);
            myConnection.Close();
        }
        public static void MethodINSERT()
        {
            startHandler();
            OleDbCommand coomandProverka = new OleDbCommand(remoteReq, myConnection);
            coomandProverka.ExecuteNonQuery();
            myConnection.Close();
        }
        public static void MethodDELETE()
        {
            startHandler();
            OleDbCommand coomandProverka = new OleDbCommand(remoteReq, myConnection);
            coomandProverka.ExecuteNonQuery();
            myConnection.Close();
        }
        public static void MethodUPDATE()
        {
            startHandler();
            OleDbCommand coomandProverka = new OleDbCommand(remoteReq, myConnection);
            coomandProverka.ExecuteNonQuery();
            myConnection.Close();
        }

    }
    static class StringHandler
    {

        public static void obrabotchik(string returnRecive) 
        {
            Program.setPortIp(Int16.Parse(returnRecive.Split(new char[] { '/' })[0]),IPAddress.Parse(returnRecive.Split(new char[] { '/' })[1]));
            DataBaseHandler.setReq(returnRecive.Split(new char[] { '/' })[2]);
        }
        
    }
    class Program
    {
        private static int localPort;
        private static int remotePort;
        private static IPAddress remoteIPAddress;
        static Thread trec;
        static string host = Dns.GetHostName();
        static string[] words;

        public static void setPortIp(int port, IPAddress ip)
        {
            remotePort = port;
            remoteIPAddress=ip;

            //check
            Console.WriteLine(remotePort);
            Console.WriteLine(remoteIPAddress);
       
        }

        static void Main(string[] args)
        {
            //string returnRecive = "5009/16.1.15.2/INSERT INTO Users (Логин, Пароль, email) VALUES (" + "'Vens'" + ", " + "'FDSSDF'" + ", " + "'DSADAS')" + "";
            //string returnRecive = "5009/16.1.15.2/UPDATE Users SET Логин='Venisimo' WHERE id=3";
            
            //Console.ReadKey();


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
                Console.WriteLine(data);
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
                    StringHandler.obrabotchik(returnRecive);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение " + ex.ToString() + "\n" + ex.Message);
            }
        }
    }
}
