using System;

namespace PatternCommand
{
    public abstract class Command 
    {
        public abstract void Srart();
        public abstract void Stop();
    }
    public class Recipient
    {
        public void Action() 
        { 
        
        }
        public void Action_Two()
        { 
        
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
    public class Initiator
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run() 
        {
            command.Srart();
        }
        public void Cancel()
        {
            command.Stop();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Initiator initiator = new Initiator();
            Recipient recipient = new Recipient();
            OneCommand command = new OneCommand(recipient);
            initiator.SetCommand(command);
            initiator.Run();
            initiator.Cancel();
        }
    }
}
