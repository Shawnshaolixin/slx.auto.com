using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static class TimerDemo
    {
        private static Timer s_timer;
        public static void Main2()
        {
            Console.WriteLine("Checking status every 2s");
            // 创建但不启动计时器，确保s_timer在线程池线程调用Status之前引用该计时器
            s_timer = new Timer(Status, "邵立新", Timeout.Infinite, Timeout.Infinite);

            // 现在 s_timer 已被赋值，可以启动定时器了
            // 现在在Status中调用Change,保证不会抛出NullReferenceException
            s_timer.Change(0, Timeout.Infinite);

            Console.ReadLine();
        }
        private static void Status(object obj)
        {
            // 这个方法由一个线程池线程执行
            Console.WriteLine($"In status at {DateTime.Now} name = {obj}");
            Thread.Sleep(1000);
            s_timer.Change(2000, Timeout.Infinite);

            // 这个方法返回后，线程回池中，等待下一个工作项
        }
    }
    internal static class TimerDemo1
    {
        public static void Main()
        {
            Console.WriteLine("Checking ststus every 2s");
            Status();
            Console.ReadLine();
        }
        // 该方法可以获取你想要的任何参数
        private static async void Status()
        {
            while (true)
            {
                Console.WriteLine($"Checking status at {DateTime.Now}");
                // 要检查的代码放这里

                // 在循环末尾，在不阻塞线程的前提下延迟2秒钟
                await Task.Delay(2000); // await 允许线程返回
                //2秒之后,某个线程会在 await之后介入并继续循环
            }
        }
    }
    class Program
    {
        static void Main1(string[] args)
        {
            #region ThreadPool
            //CallContext.LogicalSetData("Name", "Jeffrey");
            //ThreadPool.QueueUserWorkItem(state =>
            //{
            //    Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}");
            //});
            //ExecutionContext.SuppressFlow();

            //ThreadPool.QueueUserWorkItem(state =>
            //{
            //    Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}");
            //});

            //ExecutionContext.RestoreFlow();


            //CancellationDemo.Go();


            //var cts1 = new CancellationTokenSource();
            //cts1.Token.Register(() => { Console.WriteLine("cts1 canceled"); });
            //var cts2 = new CancellationTokenSource();
            //cts2.Token.Register(() => { Console.WriteLine("cts2 canceled"); });

            //var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);

            //linkedCts.Token.Register(() => { Console.WriteLine("linked canceled"); });

            //cts2.Cancel();
            //Console.WriteLine($"cts1 canceled = {cts1.IsCancellationRequested},cts2 canceled = {cts2.IsCancellationRequested},linked canceled = {linkedCts.IsCancellationRequested},");

            //ThreadPool.QueueUserWorkItem(ComputeBoundOp, 66);
            //new Task(ComputeBoundOp, 5, TaskCreationOptions.PreferFairness).Start(); // 用Task做相同的事情
            //Task.Run(() => ComputeBoundOp(65)); //另一个等价写法
            //CancellationTokenSource cts = new CancellationTokenSource();


            //Task<int> t = Task.Run(() => Sum(cts.Token, 1000));
            //Task cwt = t.ContinueWith(task => Console.WriteLine($"The Sum is : {task.Result}"));



            //Task<int> t = new Task<int>(n => Sum(cts.Token, 10000), cts.Token);
            //cts.Cancel();
            //t.Start();

            //Console.WriteLine(t.Result);

            //Task<int> t = Task.Run(() => Sum(cts.Token, 1000), cts.Token);

            //cts.Cancel();

            //try
            //{
            //    //如果任务已经取消，Result 会抛出一个AggregateException
            //    Console.WriteLine($"The Sum is {t.Result}");
            //}
            //catch (AggregateException x)
            //{
            //    x.Handle(e => e is OperationCanceledException);

            //    Console.WriteLine("Sum was Canceled");

            //}


            //Task<int> t = new Task<int>(n => Sum(cts.Token, 10000), cts.Token);
            //cts.Cancel();
            //t.Start();

            //t.ContinueWith(task => Console.WriteLine($"The Sum is: {task.Result}"), TaskContinuationOptions.OnlyOnRanToCompletion);

            //t.ContinueWith(task => Console.WriteLine($"Sum threw: {task.Exception.InnerExceptions}"), TaskContinuationOptions.OnlyOnFaulted);

            //t.ContinueWith(task => Console.WriteLine($"Sum was canceled: {task.Exception.InnerExceptions}"), TaskContinuationOptions.OnlyOnCanceled);


            //Task<int[]> parent = new Task<int[]>(() =>
            //{
            //    var results = new int[3];//创建 一个数组来存储结果

            //    //这个任务创建并启动3个子任务
            //    new Task(() => results[0] = Sum(10000), TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[1] = Sum(20000), TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[2] = Sum(30000), TaskCreationOptions.AttachedToParent).Start();
            //    return results;
            //});
            //var cwt = parent.ContinueWith(parentTask =>
            //{
            //    foreach (var item in parentTask.Result)
            //    {
            //        Console.WriteLine(item);
            //    }
            //});
            //parent.Start(); 
            #endregion






            Console.ReadLine();
        }
        private static void ComputeBoundOp(object state)
        {

            // 这个方法由一个专用线程执行
            Console.WriteLine($"In ComputeBoundOp: state ={state}");
            Thread.Sleep(1000);// 模拟做其他任务1秒钟

            // 这个方法返回后，专用线程将终止
        }
        private static int Sum(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {

                checked
                {
                    sum += n;
                }
            }
            return sum;
        }
        private static int Sum(CancellationToken ct, int n)
        {

            int sum = 0;
            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked
                {
                    sum += n;
                }
            }
            return sum;
        }

    }

    internal static class CancellationDemo
    {
        public static void Go()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            // 将 CancellationToken 和 要数到的数（number-to-count-to）传入操作
            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    Count(cts.Token, 1000);
            //});
            //Console.WriteLine("Press <Enter> to cancel the operation.");
            //Console.ReadLine();


            cts.Token.Register(() =>
            {
                Console.WriteLine("Cancel 1");
            });
            cts.Token.Register(() =>
            {
                Console.WriteLine("Cancel 2");
            });
            Console.ReadLine();
            cts.Cancel();//如果 Count方法已经返回，Cancel 没有任何效果


            // Cancel 立即返回，方法从这里继续运行 ...
            Console.ReadLine();

        }
        private static void Count(CancellationToken token, int countTo)
        {
            for (int i = 0; i < countTo; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is Cancelled");
                    break;
                }
                Console.WriteLine(i);
                Thread.Sleep(200);
            }
            Console.WriteLine("Count is done");
        }
    }
}
