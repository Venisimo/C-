using System;
using System.Threading;


namespace Flow
{
    class Program
    {
        public class Counter
        {
            private static int Count = 0;
            public static object obj = new Object();
            public static void Increase()
            {
                lock (obj)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Count++;
                        Console.WriteLine(Count);
                    }
                }
            }
        }

        public class Single {
            private static Single instance;

            private Single(){}

            public static Single getInstance()
            {
                if (instance == null)
                    instance = new Single();
                return instance;
            }
        }
        static void Main(string[] args)
        {
            Thread tr = new Thread(new ThreadStart(Counter.Increase));
            tr.Start();

            Counter.Increase();
        }
    }
}
