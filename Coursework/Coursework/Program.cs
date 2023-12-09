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
                Console.WriteLine("Выберите 1-ого героя: \n1. Зачарованный гоблин\n2. Простой гоблин");
                switch (Console.ReadLine())
                {
                    case "1":
                        listCharacter.Add(new Goblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        oneHero = false;
                        break;
                    case "2":
                        listCharacter.Add(new SimpleGoblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-1, 1)));
                        oneHero = false;
                        break;
                }
                Console.WriteLine("Выберите 1-ого героя: \n1. Зачарованный гоблин\n2. Простой гоблин");
                switch (Console.ReadLine())
                {
                    case "1":
                        listCharacter.Add(new Goblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-2, 2)));
                        twoHero = false;
                        break;
                    case "2":
                        listCharacter.Add(new SimpleGoblin(100 + rnd.Next(-10, 10), 20 + rnd.Next(-1, 1)));
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
        public double currentHP; // текущее значение здоровья
        public double MaxHP; // максимальное значение здоровья
        public double CurrentDM; // текущее значение урона
        public double BaseDM; // базовое значение урона
        public string Name; // имя персонажа
        public virtual double ActionHP(double value)
        {
            return value;
        }
        public double CurrentHP
        {
            get { return currentHP; }
            set
            {
                if (value != currentHP)
                {
                    currentHP = ActionHP(value);
                }
            }
        }
        public void isTurn(Character enemy)
        {
            BeginTurn(enemy);
            InTurn(enemy);
            EndTurn(enemy);
            GameMode.PrintInfoCharacter();
        }

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
            currentHP = MaxHP;
            this.BaseDM = BaseDM;
            CurrentDM = BaseDM;
            Name = "Зачарованный гоблин by Ваня";
        }
        public int charge = 1;
        public int bandage = 2;
        public double enemyDM;
        public override double ActionHP(double value)
        {
            if (0 == rnd.Next(-1, 1) && value > 0)
            {
                enemyDM = currentHP - value;
                enemyDM /= 10;
                value += enemyDM;
                GameMode.InsertLog(Name, "Блок", "атаки противника");
            }
            else if (0 == rnd.Next(-3, 3) && value > 0)
            {        
                value = currentHP;
                GameMode.InsertLog(Name, "Уклонение", "атаки противника");
            }
            if (0 == rnd.Next(-1, 1) && value < 0)
            {
               if (charge > 0)
               {
                    charge -= 1;
                    value = 1;
                    GameMode.InsertLog(Name, "Стойкость", "атаки противника");
                }
            }
            return value;
        }
        public void Attack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM;
            GameMode.InsertLog(Name, "Атака", enemy.Name);
        }
        public void Heal()
        {
            if (bandage > 0)
            {
                if (CurrentHP != MaxHP)
                {
                    CurrentHP += 5;
                    if (CurrentHP > MaxHP)
                    {
                        CurrentHP = MaxHP;
                    }
                    bandage -= 1;
                    GameMode.InsertLog(Name, "Перебинтовался", Name);
                }
            }
        }

        public void DoubleAttack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM + (CurrentDM / 2);
            GameMode.InsertLog(Name, "Двойная атака", enemy.Name);

        }
        public override void BeginTurn(Character enemy)
        {
            Attack(enemy);
        }
        public override void InTurn(Character enemy)
        {
            DoubleAttack(enemy);
        }
        public override void EndTurn(Character enemy)
        {
            Heal();
        }
    }
    class SimpleGoblin : Character
    {
        static Random rnd = new Random();
        public SimpleGoblin(double MaxHP, double BaseDM)
        {
            this.MaxHP = MaxHP;
            currentHP = MaxHP;
            this.BaseDM = BaseDM;
            CurrentDM = BaseDM;
            Name = "Простой гоблин";
        }
        public void Attack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM;
            GameMode.InsertLog(Name, "Атака", enemy.Name);
        }

        public void DoubleAttack(Character enemy)
        {
            enemy.CurrentHP -= CurrentDM + (CurrentDM / 2);
            GameMode.InsertLog(Name, "Двойная атака", enemy.Name);

        }
        public override void BeginTurn(Character enemy)
        {
            Attack(enemy);
        }
        public override void InTurn(Character enemy)
        {
            DoubleAttack(enemy);
        }
        public override void EndTurn(Character enemy)
        {
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
