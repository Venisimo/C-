using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace UDPClient
{
    class Program
    {
        static int localPort;
        static int remotePort;
        static IPAddress localIPAddress;
        static IPAddress remoteIPAddress;
        static Thread trec;
        static string req;
        static string host = Dns.GetHostName();
        static string[] words;
        static void Main(string[] args)
        {
            Input();
            Record();
        }
        public static void Input()
        {
            localPort = 5002;
            remotePort = 5000;
            IPAddress address = Dns.GetHostAddresses(host).First<IPAddress>
                (f=>f.AddressFamily == AddressFamily.InterNetwork);
            if (address != null) {
                localIPAddress = address;
            }
            
            Console.WriteLine("Ваш ip: " + localIPAddress);
            Console.Write("Введите ip сервера: ");
            remoteIPAddress = IPAddress.Parse(Console.ReadLine());
            Console.Write("Введите SQL запрос на сервер: ");
            req = Console.ReadLine();
        }
        public static void Record() 
        {
            try

            {
                string data = localPort.ToString() + "/" + localIPAddress.ToString() + "/" + req;
                Send(data);

                trec = new Thread(new ThreadStart(Reciver));
                trec.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        public static void Send(string data)
        {

            UdpClient sender = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(remoteIPAddress, remotePort);
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                sender.Send(bytes, bytes.Length, endPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    words = returnRecive.Split(new char[] { '/' });
                    if (words[0] == "ОТВЕТ")
                    {
                        Hello();
                    }
                   
                    CloseThread();
                }

            }
            catch (Exception ex)
            {

            }
        }
        public static void Hello()
        {
            Console.WriteLine("Hello " + words[1]);
        }
        public static void CloseThread()
        {
            trec.Abort();
        }
    }
}
