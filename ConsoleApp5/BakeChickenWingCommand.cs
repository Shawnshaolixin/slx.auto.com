namespace ConsoleApp5
{
    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver) : base(receiver)
        {

        }
        public override void ExecuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }
}
