using System;

namespace 升级之路
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 200;
            int b = 55;
            Console.WriteLine(200%55);
            int tmp;
            while (b != 0)

            {

                tmp = a % b;

                a = b;

                b = tmp;

            }
            Console.WriteLine("最大公约数=" +  a);
         
            Console.WriteLine("Hello World!");
            Console.WriteLine(200/55);
            Console.ReadKey();
        }
    }
}
