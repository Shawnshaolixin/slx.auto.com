using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            // 开店前的准备
            Barbecuer boy = new Barbecuer();
            Command bakeMuttonCommand1 = new BakeMuttonCommand(boy);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(boy);
            Command bakeChickenWingCommand1 = new BakeChickenWingCommand(boy);

            Waiter girl = new Waiter();

            // 开门营业

            girl.SetOrder(bakeChickenWingCommand1);
      

            girl.SetOrder(bakeMuttonCommand1);
         

            girl.SetOrder(bakeMuttonCommand2);
            girl.Notify();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
