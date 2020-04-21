using Autofac;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace AutofacTest
{
    class Program
    {
        public class OrderServiceItem
        {
            /// <summary>
            /// eg:1 服务费率开始天数
            /// </summary>

            public int ServiceRateStartName { get; set; }
            /// <summary>
            /// 例如 0.025
            /// </summary>

            public double ServiceRate { get; set; }
            /// <summary>
            /// 序号
            /// </summary>

            public int num { get; set; }
            /// <summary>
            ///eg: 15 服务费率结束天数
            /// </summary>

            public int ServiceRateEndName { get; set; }


        }
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {


            List<OrderServiceItem> serviceRates = new List<OrderServiceItem>();
            serviceRates.Add(new OrderServiceItem
            {
                num = 1,
                ServiceRate = 0.2,
                ServiceRateStartName = 1,
                ServiceRateEndName = 15

            });
            serviceRates.Add(new OrderServiceItem
            {
                num = 2,
                ServiceRate = 0.4,
                ServiceRateStartName = 16,
                ServiceRateEndName = 30

            });
            serviceRates.Add(new OrderServiceItem
            {
                num = 4,
                ServiceRate = 0.6,
                ServiceRateStartName = 31,
                ServiceRateEndName = 40

            });
            //50
            //    1-15 0.2
            //  16-30  0.4
            //  31-40  0.6
            var days = 20;

            decimal la = 100;
            bool flag = true;
            var amounts = serviceRates
                 .OrderBy(x => x.num)
                 .Select(x =>
                 {
                     if (flag)
                     {
                         if (days > x.ServiceRateEndName)
                         {
                             return Math.Round(la * Convert.ToDecimal(x.ServiceRate) * (x.ServiceRateEndName - x.ServiceRateStartName + 1));
                         }
                         else
                         {
                             flag = false;
                             return Math.Round((days - x.ServiceRateStartName + 1) * Convert.ToDecimal(x.ServiceRate) * la);
                         }
                     }
                     else
                     {
                         return 0;
                     }
                 }).Sum();
            Console.WriteLine(amounts);
            Console.ReadKey();
















            char[] arr = new char[] { 'a' };
            new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine("线程1执行了" + i);
                }
            }).Start();
            new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine("线程2执行了" + i);
                }
            }).Start();
            //var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            //Container = builder.Build();

            //// The WriteDate method is where we'll make use
            //// of our dependency injection. We'll define that
            //// in a bit.

            //WriteDate();
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                Console.WriteLine(obj);

            }, "呵呵");
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }
        private static void Marshalling()
        {
            // 获取AddDomain引用
            AppDomain adCallingThreadDomain = Thread.GetDomain();

            // 获取并展示友好的字符串名称
            String callingDomainName = adCallingThreadDomain.FriendlyName;
            Console.WriteLine($"Default AppDomain's friendly name is {callingDomainName}");

            // 获取并展示我们的AppDomain中包含了"Main" 方法的程序集
            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine($"Main assembly is {exeAssembly}");

            AppDomain ad2 = null;

            // DEMO1 :使用Marshal-by-reference 进行跨域通信
            Console.WriteLine($"{Environment.NewLine} Demo #1");

            ad2 = AppDomain.CreateDomain("AD #2");

            MarshalByRefObject mbro = null;

        }
    }

    // This interface helps decouple the concept of
    // "writing output" from the Console class. We
    // don't really "care" how the Write operation
    // happens, just that we can write.
    public interface IOutput
    {
        void Write(string content);
    }

    // This implementation of the IOutput interface
    // is actually how we write to the Console. Technically
    // we could also implement IOutput to write to Debug
    // or Trace... or anywhere else.
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    // This interface decouples the notion of writing
    // a date from the actual mechanism that performs
    // the writing. Like with IOutput, the process
    // is abstracted behind an interface.
    public interface IDateWriter
    {
        void WriteDate();
    }

    // This TodayWriter is where it all comes together.
    // Notice it takes a constructor parameter of type
    // IOutput - that lets the writer write to anywhere
    // based on the implementation. Further, it implements
    // WriteDate such that today's date is written out;
    // you could have one that writes in a different format
    // or a different date.
    public class TodayWriter : IDateWriter
    {
        private IOutput _output;
        public TodayWriter(IOutput output)
        {
            this._output = output;
        }

        public void WriteDate()
        {

            ConcurrentDictionary<string, string> dict = new ConcurrentDictionary<string, string>();
            dict.TryAdd("", "");
            this._output.Write(DateTime.Today.ToShortDateString());
        }


    }
}
