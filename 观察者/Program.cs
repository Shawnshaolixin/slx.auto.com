using System;

namespace 观察者
{
    class Program
    {
        static void Main(string[] args)
        {

            Kid kid = new Kid();
            IObserver cat = new Cat();
            IObserver mouse = new Mouse();
            kid.AddObserver(cat);
            kid.AddObserver(mouse);
            kid.Cloud();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
