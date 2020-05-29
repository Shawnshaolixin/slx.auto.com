namespace ConsoleApp5
{
    public abstract class Command
    {
        /// <summary>
        /// 
        /// </summary>
        protected Barbecuer receiver;
        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }
        abstract public void ExecuteCommand();
    }
}
