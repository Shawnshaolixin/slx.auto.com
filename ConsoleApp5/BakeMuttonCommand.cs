namespace ConsoleApp5
{
    public class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbecuer receiver) : base(receiver)
        {

        }
        public override void ExecuteCommand()
        {
            receiver.BakeMutton();
        }
    }
}
