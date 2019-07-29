using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace ConsoleApp3
{
    public static class MyEnumerable
    {
        public static float Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
            {
                return 0;
            }

            return 0;
        }
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            List<TSource> result = new List<TSource>();

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
    class Program
    {
        internal delegate void Feedback(int value);
        static void Main(string[] args)
        {
            #region MyRegion
            ////StaticDelegateDemo((int value, int value1) =>
            ////{
            ////    List<int> list = new List<int>();
            ////    for (int i = 0; i < value; i++)
            ////    {
            ////        list.Add(i);
            ////    }
            ////    return list;
            ////});
            //InstanceDelegateDemo((opt) =>
            //{
            //    var name = opt.Name;
            //    var password = opt.Password;
            //    Console.WriteLine(name + password);

            //}); 
            #endregion
            List<RabbitMQOptions> list = new List<RabbitMQOptions>();
            list.Add(new RabbitMQOptions
            {
                Name = "slx",
                Password = "123456"
            });
            list.Add(new RabbitMQOptions
            {
                Name = "slx",
                Password = "111111"
            });
            list.Add(new RabbitMQOptions
            {
                Name = "slx2",
                Password = "123456"
            });
            var result1 = list.Where((item) => item.Name == "slx");
            foreach (var item in result1)
            {
                Console.WriteLine("1=" + item.ToString());
            }
            var result2 = list.MyWhere((item) => item.Name == "slx");
            foreach (var item in result2)
            {
                Console.WriteLine("2=" + item.ToString());
            }
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
        public override string ToString()
        {
            return $"{Name} {Password}";
        }
    }

}
