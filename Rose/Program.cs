using System;

namespace Rose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // 然后你就可以根据IP和端口拿到对于的服务
            var channel = new Channel("192.168.1.8", 8080, ChannelCredentials.Insecure);

            Console.ReadLine();
        }
    }
    public class A
    {
        static A()
        {
            Console.WriteLine("静态构造方法被调用了");
        }
        public A()
        {
            Console.WriteLine("构造方法被调用了");
        }
    }
}
