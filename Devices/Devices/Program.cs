using System;
using System.Collections.Generic;

namespace Devices
{
    public abstract class Command
    {
        public abstract void Srart();
        public abstract void Stop();
    }
    public class Recipient
    {
        public int i = 1;
        public void Action()
        {
            Console.WriteLine("Включить TV");
        }
        public void Action_Two()
        {
            Console.WriteLine("Выключить TV");
        }
        public void Action_Three()
        {
            Console.Write("Сейчас идет канал: ");
            Console.WriteLine(i);
            Console.WriteLine("Переключить на следующий канал");
            i++;
            Console.WriteLine("Канал переключен");
            Console.Write("Сейчас идет канал: ");
            Console.WriteLine(i);
        }
        public void Action_Four()
        {
            Console.Write("Сейчас идет канал: ");
            Console.WriteLine(i);
            Console.WriteLine("Переключить на предыдущий канал");
            i--;
            Console.WriteLine("Канал переключен");
            Console.Write("Сейчас идет канал: ");
            Console.WriteLine(i);
        }
    }
    public class RecipientPelesos
    {
        public int i = 1;
        public void Action()
        {
            Console.WriteLine("Включить пылесос");
        }
        public void Action_Two()
        {
            Console.WriteLine("Выключить пылесос");
        }
        public void Action_Three()
        {
            Console.Write("Сейчас режим: ");
            Console.WriteLine(i);
            Console.WriteLine("Переключить на режим");
            i++;
            Console.WriteLine("Режим переключен");
            Console.Write("Сейчас режим: ");
            Console.WriteLine(i);
        }
        public void Action_Four()
        {
            Console.Write("Сейчас режим: ");
            Console.WriteLine(i);
            Console.WriteLine("Переключить на режим");
            i--;
            Console.WriteLine("Режим переключен");
            Console.Write("Сейчас режим: ");
            Console.WriteLine(i);
        }
    }
    public class OneCommand : Command
    {
        Recipient recipient;
        public OneCommand(Recipient rec)
        {
            recipient = rec;
        }
        public override void Srart()
        {
            recipient.Action();
        }

        public override void Stop()
        {
            recipient.Action_Two();
        }
    }
    public class TwoCommand : Command
    {
        Recipient recipientTwo;
        public TwoCommand(Recipient rec)
        {
            recipientTwo = rec;
        }
        public override void Srart()
        {
            recipientTwo.Action_Three();
        }
        public override void Stop()
        {
            recipientTwo.Action_Four();
        }
    }
    public class ThreeCommand : Command
    {
        RecipientPelesos recipientThree;
        public ThreeCommand(RecipientPelesos rec)
        {
            recipientThree = rec;
        }
        public override void Srart()
        {
            recipientThree.Action();
        }
        public override void Stop()
        {
            recipientThree.Action_Two();
        }
    }
    public class FourCommand : Command
    {
        RecipientPelesos recipientThree;
        public FourCommand(RecipientPelesos rec)
        {
            recipientThree = rec;
        }
        public override void Srart()
        {
            recipientThree.Action_Three();
        }
        public override void Stop()
        {
            recipientThree.Action_Four();
        }
    }

    public class Initiator
    {
        List<Command> commands = new List<Command>();
        public static void AtRemove(ref List<Command> commands, int index)  
        {
            List<Command> NewList = new List<Command>(commands.Count - 1); 

            for (int i = 0; i < index - 1; i++)
            {
                if (i != index)
                {
                    NewList.Remove(commands[i]);
                }
            }

            for (int i = index + 1; i < commands.Count; i++) 
            {
                if (i != index)
                {
                    NewList.Remove(commands[i]);
                }
            }
            commands = NewList;
        }
        public void SetCommand(Command c)
        {
            commands.Add(c);
        }
        public void Run()
        {
            foreach (Command command in commands)
            {
                command.Srart();
            }
            AtRemove(ref commands, 0);
        }
        public void Cancel()
        {
            foreach (Command command in commands)
            {
                command.Stop();
            }
        }
    }   
        class Program
        {
            static void Main(string[] args)
            {
                Recipient recipient = new Recipient();
                RecipientPelesos recipientPelesos = new RecipientPelesos();
                Initiator initiator = new Initiator();
                OneCommand command = new OneCommand(recipient);
                TwoCommand twoCommand = new TwoCommand(recipient);
                ThreeCommand Threecommand = new ThreeCommand(recipientPelesos);
                FourCommand FourCommand = new FourCommand(recipientPelesos);
                initiator.SetCommand(command);
                initiator.SetCommand(twoCommand);
                initiator.SetCommand(Threecommand);
                initiator.SetCommand(FourCommand);
                initiator.Run();
                initiator.Cancel();
            }
        }
    }
