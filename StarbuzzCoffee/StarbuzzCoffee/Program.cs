using System;

namespace StarbuzzCoffee
{
    class Program
    {
        abstract class Coffe 
        {
            public Coffe(string name) 
            {
                this.Name = name;
            }
            public string Name { get; protected set; }
            public abstract int GetCost();
        }

        class Late : Coffe
        { 
            public Late() : base("Лате") {}
            public override int GetCost()
            {
                return 50;
            }
        }
        class Americano : Coffe
        {
            public Americano() : base("Американо") { }
            public override int GetCost()
            {
                return 30;
            }
        }
        class Capuchino : Coffe
        {
            public Capuchino() : base("Капучино") { }
            public override int GetCost()
            {
                return 40;
            }
        }

        abstract class CoffeDecorator : Coffe 
        {
            protected Coffe coffe;
            public CoffeDecorator(string name, Coffe coffe) : base(name) 
            {
                this.coffe = coffe;
            }
        }

        class CruasanCoffe : CoffeDecorator 
        {
            public CruasanCoffe(Coffe coffe) : base(coffe.Name + ", с курасаном", coffe) { }
            public override int GetCost()
            {
                return coffe.GetCost() + 30;
            }
        }
        class DoubleCoffe : CoffeDecorator
        {
            public DoubleCoffe(Coffe coffe) : base("Две чашки " + coffe.Name, coffe) { }
            public override int GetCost()
            {
                return coffe.GetCost() * 2;
            }
        }
        static void Main(string[] args)
        {
            string Change;
            string Additive;
            Coffe coffe;

            ChangeCoffe();
            void ChangeCoffe()
            {
                Console.WriteLine("Что вы хотите заказать");
                Console.WriteLine("1. Лате");
                Console.WriteLine("2. Капучино");
                Console.WriteLine("3. Американо");
                Change = Console.ReadLine();
                if (Change == "1")
                {
                    coffe = new Late();
                    CoffeAddative();
                }
                else if (Change == "2")
                {
                    coffe = new Capuchino();
                    CoffeAddative();
                }
                else if (Change == "3")
                {
                    coffe = new Americano();
                    CoffeAddative();
                }
                else
                {
                    Console.WriteLine("Некоректный выбор");
                    ChangeCoffe();
                }
            }

            void CoffeAddative() 
            {
                Console.WriteLine("Выберете добавку");
                Console.WriteLine("1. Круасан");
                Console.WriteLine("2. Еще одно такое же кофе");
                Console.WriteLine("3. Без добавки");
                Additive = Console.ReadLine();
                if (Additive == "1")
                {
                    coffe = new CruasanCoffe(coffe);
                    YourCoffe();
                }
                else if (Additive == "2")
                {
                    coffe = new DoubleCoffe(coffe);
                    YourCoffe();
                }
                else if (Additive == "3")
                {
                    YourCoffe();
                }
                else
                {
                    Console.WriteLine("Некоректный выбор");
                    CoffeAddative();
                }
            }
            void YourCoffe()
            {
                Console.WriteLine("Вот ваш заказ:");
                Console.WriteLine("Название: {0}", coffe.Name);
                Console.WriteLine("Цена: {0}", coffe.GetCost());
            }
        }
    }
}
