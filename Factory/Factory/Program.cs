using System;

namespace Factory
{
    class Program
    { 
        public abstract class Weapon 
        {
            public abstract void UseWeapon();
        }
        public abstract class CombatTactics
        {
            public abstract void UseTactics();
        }

        public class AssaultRifle : Weapon 
        {
            public override void UseWeapon()
            {
                Console.WriteLine("Штурмовая винтовка");
            }
        }
        public class SniperRifle : Weapon
        {
            public override void UseWeapon()
            {
                Console.WriteLine("Снайперская винтовка");
            }
        }
        public class SubmachineGun : Weapon
        {
            public override void UseWeapon()
            {
                Console.WriteLine("Пистолет-пулемет");
            }
        }
        public class OneTactics : CombatTactics
        {
            public override void UseTactics()
            {
                Console.WriteLine("Участие в первой линии");
            }
        }
        public class TwoTactics : CombatTactics
        {
            public override void UseTactics()
            {
                Console.WriteLine("Участие в третьей линии");
            }

        }
        public class ThreeTactics : CombatTactics
        {
            public override void UseTactics()
            {
                Console.WriteLine("Участие в тылу врага");
            }
        }
        public abstract class SoldierFactory
        {
            public abstract Weapon CreateWeapon();
            public abstract CombatTactics CreateTactics();
        }

        public class BaseSoldier : SoldierFactory
        {
            public override Weapon CreateWeapon()
            {
                return new AssaultRifle();
            }
            public override CombatTactics CreateTactics()
            {
                return new OneTactics();
            }

        }
        public class SniperSoldier : SoldierFactory
        {
            public override Weapon CreateWeapon()
            {
                return new SniperRifle();
            }
            public override CombatTactics CreateTactics()
            {
                return new TwoTactics();
            }

        }
        public class SpecialForce : SoldierFactory
        {
            public override Weapon CreateWeapon()
            {
                return new SubmachineGun();
            }
            public override CombatTactics CreateTactics()
            {
                return new ThreeTactics();
            }

        }
        public class Soldier
        {
            private Weapon weapon;
            private CombatTactics tactics;
            public Soldier(SoldierFactory sf) 
            {
                weapon = sf.CreateWeapon();
                tactics = sf.CreateTactics();
            }
            public void isWeapon()
            {
                Console.Write("Оружие: ");
                weapon.UseWeapon();
            }
            public void isTactics()
            {
                Console.Write("Тактика: ");
                tactics.UseTactics();
            }
        }

        static void Main(string[] args)
        {
            Soldier oneS = new Soldier(new BaseSoldier());
            oneS.isWeapon();
            oneS.isTactics();

            Soldier twoS = new Soldier(new SniperSoldier());
            twoS.isWeapon();
            twoS.isTactics();

            Soldier threeS = new Soldier(new SpecialForce());
            threeS.isWeapon();
            threeS.isTactics();
        } 
    }
}
