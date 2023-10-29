using System;

namespace PizzaFactory
{
    class Program
    {

        public abstract class Dough
        {
            public abstract void UseDough();
        }
        public abstract class Sauce
        {
            public abstract void UseSauce();
        }
        public abstract class Filling
        {
            public abstract void UseFilling();
        }
        public class ThickDough : Dough
        {
            public override void UseDough() {
                Console.WriteLine("Толстое");
            }
        }
        public class StandartDough : Dough
        {
            public override void UseDough()
            {
                Console.WriteLine("Стандартное");
            }
        }
        public class ThinDough : Dough
        {
            public override void UseDough()
            {
                Console.WriteLine("Тонкое");
            }
        }

        public class KetchupSauce : Sauce
        {
            public override void UseSauce()
            {
                Console.WriteLine("Кетчуп");
            }
        }
        public class ChesseSauce : Sauce
        {
            public override void UseSauce()
            {
                Console.WriteLine("Сырный");
            }
        }
        public class ChesnokSauce : Sauce
        {
            public override void UseSauce()
            {
                Console.WriteLine("Чесночный");
            }
        }

        public class ChesseFilling : Filling
        {
            public override void UseFilling()
            {
                Console.WriteLine("С сыром");
            }
        }
        public class TomatoFilling : Filling
        {
            public override void UseFilling()
            {
                Console.WriteLine("С томатами");
            }
        }
        public class PeperoniFilling : Filling
        {
            public override void UseFilling()
            {
                Console.WriteLine("Пеперони");
            }
        }
        public abstract class PizzaFactory
        {
            public abstract Dough CreateDough();
            public abstract Sauce CreateSauce();
            public abstract Filling CreateFilling();
        }
        public class StandartPizza : PizzaFactory
        {
            public override Dough CreateDough()
            {
                return new StandartDough();
            }
            public override Sauce CreateSauce()
            {
                return new KetchupSauce();
            }
            public override Filling CreateFilling()
            {
                return new TomatoFilling();
            }
        }

        public class ChessePizza : PizzaFactory
        {
            public override Dough CreateDough()
            {
                return new ThinDough();
            }
            public override Sauce CreateSauce()
            {
                return new ChesseSauce();
            }
            public override Filling CreateFilling()
            {
                return new ChesseFilling();
            }
        }

        public class PeperoniPizza : PizzaFactory
        {
            public override Dough CreateDough()
            {
                return new ThickDough();
            }
            public override Sauce CreateSauce()
            {
                return new ChesnokSauce();
            }
            public override Filling CreateFilling()
            {
                return new PeperoniFilling();
            }
        }

        public class Pizza
        {
            private Dough dough;
            private Sauce sauce;
            private Filling filling;
            public Pizza(PizzaFactory pf) {
                dough = pf.CreateDough();
                sauce = pf.CreateSauce();
                filling = pf.CreateFilling();
            }
            public void isDough()
            {
                Console.Write("Тесто: ");
                dough.UseDough();
            }
            public void isSauce()
            {
                Console.Write("Соус: ");
                sauce.UseSauce();
            }
            public void isFilling()
            {
                Console.Write("Начинка: ");
                filling.UseFilling();
            }
        }

        static void Main(string[] args)
        {
            Pizza oneP = new Pizza(new StandartPizza());
            oneP.isDough();
            oneP.isSauce();
            oneP.isFilling();

            Pizza twoP = new Pizza(new ChessePizza());
            twoP.isDough();
            twoP.isSauce();
            twoP.isFilling();

            Pizza threeP = new Pizza(new PeperoniPizza());
            threeP.isDough();
            threeP.isSauce();
            threeP.isFilling();
        }
    }
}
