using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    public class Waiter
    {
        private IList<Command> orders = new List<Command>();

        //设置订单
        public void SetOrder(Command command)
        {
            if (command.ToString() == "ConsoleApp5.BakeChickenWingCommand")
            {
                System.Console.WriteLine("服务员：鸡翅没有了，请点别的烧烤");
            }
            else
            {
                orders.Add(command);
                System.Console.WriteLine($"增加订单：{command.ToString()},时间：{DateTime.Now}");
            }

        }
        public void Notify()
        {
            foreach (var cmd in orders)
            {
                cmd.ExecuteCommand();
            }

        }
    }
}
