using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    static class GameMode
    {
        static bool isGameOver;
        static int countTurn = 0;
        static int MaxTurn = 100;
        static bool turn = true;
        static string infoVictory = "Победил ";
        static List<Character> listCharacter = new List<Character>();
        static List<String> logActions = new List<string>();
        //static List<String> listBuff = new List<string>();

        static Random rnd = new Random();


        static GameMode()
        {
            isGameOver = false;
        }
        public static void SpawnCharacter()
        {
            bool oneHero = true, twoHero = true;
            while (oneHero || twoHero)
            {
                Console.WriteLine("Выберите 1-ого героя: \n1. Гоблин\n2. Зачарованный гоблин");
                switch (Console.ReadLine())
                {
                    case "1":
                        //listCharacter.Add(new SimpleMage(100 + rnd.Next(-10, 10),20+rnd.Next(-2,2)));
                        listCharacter.Add(new Goblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        oneHero = false;
                        break;
                    case "2":
                        // listCharacter.Add(new SuperMage(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        listCharacter.Add(new GoblinCharms(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        //listCharacter.Add(new Goblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        oneHero = false;
                        break;
                }
                Console.WriteLine("Выберите 2-ого героя: \n1. Гоблин\n2. Зачарованный гоблин");
                switch (Console.ReadLine())
                {
                    case "1":
                        // listCharacter.Add(new SimpleMage(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        listCharacter.Add(new Goblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        twoHero = false;
                        break;
                    case "2":
                        // listCharacter.Add(new SuperMage(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        listCharacter.Add(new GoblinCharms(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        //listCharacter.Add(new Goblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        twoHero = false;
                        break;
                }
            }
            PrintInfoCharacter();

        }

        public static void PrintInfoCharacter()
        {
            Console.WriteLine();
            Console.WriteLine(listCharacter[0].Name + "\t\t\t\t" + listCharacter[1].Name);
            Console.WriteLine("ОЗ: " + listCharacter[0].CurrentHP + "/" + listCharacter[0].MaxHP + "\t\t\t\t" + "ОЗ: " + listCharacter[1].CurrentHP + "/" + listCharacter[1].MaxHP);
            Console.WriteLine("Урон: " + listCharacter[0].CurrentDM + "\t\t\t\t" + "Урон: " + listCharacter[1].CurrentDM);
        }
        public static void Turn()
        {
            while (!isGameOver)
            {
                if (turn)
                {
                    listCharacter[0].isTurn(listCharacter[1]);
                    checkIsGameOver();
                    turn = false;
                    countTurn++;
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    listCharacter[1].isTurn(listCharacter[0]);
                    checkIsGameOver();
                    turn = true;
                    countTurn++;
                    System.Threading.Thread.Sleep(100);
                }
            }
            printResultGame();
        }

        static void checkIsGameOver()
        {
            if (listCharacter[0].CurrentHP <= 0)
            {
                isGameOver = true;
                infoVictory += listCharacter[1].Name;
            }
            else if (listCharacter[1].CurrentHP <= 0)
            {
                isGameOver = true;
                infoVictory += listCharacter[0].Name;
            }
            else if (countTurn >= MaxTurn)
            {
                if (listCharacter[0].CurrentHP == listCharacter[1].CurrentHP)
                {
                    isGameOver = true;
                    infoVictory = "Ничья!";
                }
                else if (listCharacter[0].CurrentHP > listCharacter[1].CurrentHP)
                {
                    isGameOver = true;
                    infoVictory += listCharacter[0].Name;
                }
                else
                {
                    isGameOver = true;
                    infoVictory += listCharacter[1].Name;
                }
            }
        }
        static void printResultGame()
        {
            Console.WriteLine(infoVictory);
        }

        public static void InsertLog(string NameMyHero, string Ability, string NameEnemyHero)
        {
            string message = "\n<" + NameMyHero + ">" + " применил способность " + "*" + Ability + "*" + " к " + "<" + NameEnemyHero + ">";
            logActions.Add(message);
            Console.WriteLine(message);
        }
    }
    abstract class Character
    {
        public double CurrentHP;
        public double MaxHP;
        public double CurrentDM;
        public double BaseDM;
        public string Name;
        public void enemyTurn(Character enemy)
        {
            Defend(enemy);
        }
        public void isTurn(Character enemy)
        {
            BeginTurn(enemy);
            InTurn(enemy);
            EndTurn(enemy);
            GameMode.PrintInfoCharacter();
        }
        public abstract void Defend(Character enemy);
        public abstract void BeginTurn(Character enemy);
        public abstract void InTurn(Character enemy);
        public abstract void EndTurn(Character enemy);
    }
    
    class Goblin : Character
    {
        static Random rnd = new Random();
        public Goblin(double MaxHP, double BaseDM)
        {
            this.MaxHP = MaxHP;
            CurrentHP = MaxHP;
            this.BaseDM = BaseDM;
            CurrentDM = BaseDM;
            Name = "Гоблин";
        }
        abstract class DamageController
        {
            public abstract double ModifyDamage(double incomingDamage);
        }
        private class DamageModifier : DamageController
        {
            public override double ModifyDamage(double incomingDamage)
            {
                return incomingDamage - 5;
            }
        }

        public void Attack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM;
            GameMode.InsertLog(Name, "Атака", enemy.Name);
        }

        public override void Defend(Character enemy)
        {
            DamageModifier damageModifier = new DamageModifier();
            double modifiedDamage = damageModifier.ModifyDamage(enemy.CurrentDM);
            CurrentHP += (enemy.CurrentDM - modifiedDamage);
            GameMode.InsertLog(Name, "Защита", enemy.Name);
        }

        public void DoubleAttack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM;
            enemy.CurrentHP -= (CurrentDM / 2);
            GameMode.InsertLog(Name, "Двойная атака", enemy.Name);

        }
        public void Dodge(Character enemy)
        {
            GameMode.InsertLog(Name, "Уклонение", enemy.Name);
        }
        public void Persistence(Character enemy)
        {
            if (CurrentHP < enemy.CurrentDM + (enemy.CurrentDM / 2))
            {
                CurrentHP = 1;
            }
            GameMode.InsertLog(Name, "Стойкость", enemy.Name);
        }
        public override void BeginTurn(Character enemy)
        {
            DoubleAttack(enemy);
        }
        public override void InTurn(Character enemy)
        {
            //здесь будет защита
        }
        public override void EndTurn(Character enemy)
        {
            Attack(enemy);
            //int randomNum = 0 + rnd.Next(-1, 1);
            //if (randomNum == 0)
            //{
            //    Persistence(enemy);
            //}
            //else
            //{
            //}
        }
    }
    class GoblinCharms : Character
    {
        static Random rnd = new Random();
        public GoblinCharms(double MaxHP, double BaseDM)
        {
            this.MaxHP = MaxHP;
            CurrentHP = MaxHP;
            this.BaseDM = BaseDM;
            CurrentDM = BaseDM;
            Name = "Зачарованный гоблин";
        }
        abstract class DamageController
        {
            public abstract double ModifyDamage(double incomingDamage);
        }
        private class DamageModifier : DamageController
        {
            public override double ModifyDamage(double incomingDamage)
            {
                return incomingDamage - 5;
            }
        }

        public void Attack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM;
            GameMode.InsertLog(Name, "Атака", enemy.Name);
        }

        public override void Defend(Character enemy)
        {
            DamageModifier damageModifier = new DamageModifier();
            double modifiedDamage = damageModifier.ModifyDamage(enemy.CurrentDM);
            enemy.CurrentHP += (enemy.CurrentDM - modifiedDamage); 
            GameMode.InsertLog(Name, "Защита", enemy.Name);
        }

        public void DoubleAttack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM;
            enemy.CurrentHP -= (CurrentDM / 2);
            GameMode.InsertLog(Name, "Двойная атака", enemy.Name);

        }
        public void Dodge(Character enemy)
        {
            GameMode.InsertLog(Name, "Уклонение", enemy.Name);
        }
        public void Persistence(Character enemy)
        {
            if (CurrentHP < enemy.CurrentDM + (enemy.CurrentDM / 2))
            {
                CurrentHP = 1;
            }
            GameMode.InsertLog(Name, "Стойкость", enemy.Name);
        }
        public override void BeginTurn(Character enemy)
        {
            DoubleAttack(enemy);
        }
        public override void InTurn(Character enemy)
        {
            //здесь будет защита
        }
        public override void EndTurn(Character enemy)
        {
            Attack(enemy);
            //int randomNum = 0 + rnd.Next(-1, 1);
            //if (randomNum == 0)
            //{
            //    Persistence(enemy);
            //}
            //else
            //{
            //}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GameMode.SpawnCharacter();
            GameMode.Turn();
            Console.ReadKey();
        }
    }
}
