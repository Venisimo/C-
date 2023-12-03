using System;
using System.Net;
using System.Linq;
namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string host = Dns.GetHostName();
            Console.WriteLine($"Имя компьютера: {host}");
            IPAddress address = Dns.GetHostAddresses(host).First<IPAddress>(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            if (address != null)
            {
                Console.WriteLine($"Адрес: {address} Семейство: {address.AddressFamily}");
            }
            Console.ReadKey();
        }
    }
}

