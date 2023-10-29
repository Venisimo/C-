using System;

namespace ExampleCs2
{
    class BasedDuck
    {
        protected void Swim()
        {
            Console.WriteLine("Плывет");
        }
        protected IFly flying { get; set; }
        public IFly Flying
        {
            get
            {
                return flying;
            }
            set
            {
                flying = value;
            }
        }

        protected IEat eating { get; set; }
        public IEat Eating
        {
            get
            {
                return eating;
            }
            set
            {
                eating = value;
            }
        }
        protected IKrya kryaing { get; set; }
        public IKrya Kryaing
        {
            get
            {
                return kryaing;
            }
            set
            {
                kryaing = value;
            }
        }
        public void AlertSwim()
        {
            Swim();
        }
        public void AlertFly()
        {
            flying.Fly();
        }
        public void AlertEat()
        {
            eating.Eat();
        }
        public void AlertKrya()
        {
            kryaing.Krya();
        }
        class WildDuck : BasedDuck
        {
            public WildDuck()
            {
                flying = new FastFly();
                eating = new WildEat();
                kryaing = new WildKrya();
            }
        }

        class HomeDuck : BasedDuck
        {
            public HomeDuck()
            {
                eating = new HomeEat();
                kryaing = new HomeKrya();
            }
        }

        class LatexDuck : BasedDuck
        {
            public LatexDuck()
            {
            }
        }

        public interface IFly
        {
            void Fly();
        }
        public class FastFly : IFly
        {
            public void Fly()
            {
                Console.WriteLine("Быстро полетела");
            }
        }
        public class SlowFly : IFly
        {
            public void Fly()
            {
                Console.WriteLine("Медлено полетела");
            }
        }

        public interface IEat
        {
            void Eat();
        }
        public class WildEat : IEat
        {
            public void Eat()
            {
                Console.WriteLine("Поела добычу");
            }
        }
        public class HomeEat : IEat
        {
            public void Eat()
            {
                Console.WriteLine("Дали поесть");
            }
        }
        public interface IKrya
        {
            void Krya();
        }
        public class WildKrya : IKrya
        {
            public void Krya()
            {
                Console.WriteLine("Дико крякнула");
            }
        }
        public class HomeKrya : IKrya
        {
            public void Krya()
            {
                Console.WriteLine("Крякнула спокойно");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                WildDuck WDuck = new WildDuck();
                WDuck.AlertSwim();
                WDuck.AlertFly();
                WDuck.Flying = new SlowFly();
                WDuck.AlertFly();
                WDuck.AlertEat();
                WDuck.AlertKrya();
                HomeDuck HDuck = new HomeDuck();
                HDuck.AlertSwim();
                HDuck.AlertEat();
                HDuck.AlertKrya();
                LatexDuck LDuck = new LatexDuck();
                LDuck.AlertSwim();


            }
        }
    }
}
