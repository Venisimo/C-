using System;
using System.Threading;
namespace Chocolateboiler
{
    class Program
    {
        public class SSingle
        {
            private static SSingle instance;
            public static bool empty;
            public static bool boiled;
          
            public static object obj = new Object();
           
            protected SSingle()
            {
                empty = true;
                boiled = false;
            }
            public static SSingle getInstance()
            {
                if (instance == null)
                    instance = new SSingle();
                return instance;
            }
            public void fill()
            {
                if (empty == true)
                {
                    Console.WriteLine("\nЗаливаем шоколад");
                    empty = false;
                    Console.Write("Пустой: ");
                    Console.WriteLine(empty);
                    Console.Write("Разогретый: ");
                    Console.WriteLine(boiled);
                }
            }
            public void boil()
            {
                if (boiled == false)
                {
                    Console.WriteLine("\nРазогреваем");
                    boiled = true;
                    Console.Write("Пустой: ");
                    Console.WriteLine(empty);
                    Console.Write("Разогретый: ");
                    Console.WriteLine(boiled);
                }
            }
            public void drop()
            {
                if (boiled == true && empty == false) 
                { 
                    Console.WriteLine("\nВыливаем и остужаем");
                    empty = true;
                    boiled = false;
                    Console.Write("Пустой: ");
                    Console.WriteLine(empty);
                    Console.Write("Разогретый: ");
                    Console.WriteLine(boiled);
                }
            }
        }

        static void Main(string[] args)
        {
            SSingle single = SSingle.getInstance();

            Thread t1 = new Thread(new ThreadStart(start));
            t1.Start();
            start();
            start();
            void start()
            {
                lock (single) 
                {
                    single.fill();
                    single.boil();
                    single.drop();
                }
                
            }
        }
    }
}
