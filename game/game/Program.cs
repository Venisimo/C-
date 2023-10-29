using System;
using System.Threading;
namespace game
{
    class Program
    {
        public class Game
        { 
            public DOTA2 dota2 { get; set; }
            public void Launch(string versionGame)
            {
                dota2 = DOTA2.getInstance(versionGame);
            }
        }
        public class DOTA2
        {
            private static DOTA2 instance;
            public static object obj = new Object();
            public string version { get; protected set;}
            protected DOTA2(string version) 
            {
                this.version = version;
            }
            public static DOTA2 getInstance(string version)
            {
                lock (obj) {
                    if (instance == null)
                    {
                        instance = new DOTA2(version);
                    }
                    return instance;
                }
                    
            }
        }
        static void Main(string[] args)
        {
            Game g = new Game();
            Thread t1 = new Thread(new ThreadStart(VersionLaunch));
            t1.Start();

            g.Launch("Dota2 v 1.7");
            Console.WriteLine(g.dota2.version);

            void VersionLaunch()
            {
                Game g2 = new Game();
                g2.dota2 = DOTA2.getInstance("Dota2 v 2.0");
                Console.WriteLine(g2.dota2.version);
            }
        }
    }
}
