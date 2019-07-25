using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static Task<string> GetAsync()
        {
            return Task.Run(() =>
             {
                 return "hello world";
             });
        }
        static Task<string> GetStringAsync()
        {
            return Task.FromResult<string>("hehe");
        }
        static void Main(string[] args)
        {

            //Console.WriteLine("main thread: starting a dedicated thread to do an asynchronous operation");

            //Thread dedicatedThread = new Thread(ComputeBoundOp);
            //dedicatedThread.Start(8);

            //Console.WriteLine("main thread: do other work here ...");
            //Thread.Sleep(10000); // 模拟做其他工作10秒钟

            //dedicatedThread.Join();// 等待线程终止
            //Console.WriteLine("Hit <Enter> to end this program...");



            //Thread t = new Thread(Worker);
            //t.IsBackground = false;
            //t.Start();
            //Console.WriteLine("Returning from main");

            //Console.WriteLine("main thread: starting a dedicated thread to do an asynchronous operation");
            //ThreadPool.QueueUserWorkItem(ComputeBoundOp,88);
            //Console.WriteLine("main thread: do other work here ...");
            //Thread.Sleep(10000); // 模拟做其他工作10秒钟

            //Console.WriteLine("Hit <Enter> to end this program...");

            var s = GetAsync().GetAwaiter().GetResult();
       
            Console.WriteLine(s);

            Console.ReadLine();
        }
        private static void Worker()
        {
            Thread.Sleep(10000);

            Console.WriteLine("Return from worker");
        }
        private static void ComputeBoundOp(object state)
        {

            // 这个方法由一个专用线程执行
            Console.WriteLine($"In ComputeBoundOp: state ={state}");
            Thread.Sleep(1000);// 模拟做其他任务1秒钟

            // 这个方法返回后，专用线程将终止
        }
    }
    internal class Employee
    {
        public string Name { get; set; }
        public Int32 GetYearsEmployed()
        {

            return 5;
        }
        public virtual string GetProgressReport()
        {
            return "Employee getprogressreport";
        }


        public static Employee Lookup(string name)
        {

            return new Employee() { Name = name };
        }
    }
    internal sealed class Manager : Employee
    {
        public override string GetProgressReport()
        {
            return "Manager GetPRogressRepost";
        }


    }
}
