using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        internal delegate void Feedback(int value);
        static void Main(string[] args)
        {
            //StaticDelegateDemo((int value, int value1) =>
            //{
            //    List<int> list = new List<int>();
            //    for (int i = 0; i < value; i++)
            //    {
            //        list.Add(i);
            //    }
            //    return list;
            //});
            InstanceDelegateDemo((opt) =>
            {
                var name = opt.Name;
                var password = opt.Password;
                Console.WriteLine(name + password);

            });

            Console.ReadKey();
        }
        private static int Add(int value)
        {
            Console.WriteLine("Add 调用了" + value * value);
            return value * value;
        }
        private static void StaticDelegateDemo(Func<int, int, IList<int>> feedback)
        {
            Console.WriteLine("------static delegate demo-----");
            Thread.Sleep(3000);
            var r = feedback(3, 5);
            foreach (var item in r)
            {
                Console.WriteLine("item=" + item);
            }
        }

        private static void InstanceDelegateDemo(Action<RabbitMQOptions> options)
        {
            Console.WriteLine("-----instance delegate demo-----");
            options(new RabbitMQOptions
            {
                Name = "shaolixin",
                Password = "123456"
            });
        }
        public static void ChainDelegateDemo1(Program p)
        {
            Console.WriteLine("-----chain delegate demo1-----");
        }
        public static void ChainDelegateDemo2(Program p)
        {
            Console.WriteLine("-----chain delegate demo2-----");
        }
    }
    public class RabbitMQOptions
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }

}
