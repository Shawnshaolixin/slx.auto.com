using System;
using System.Collections.Generic;

namespace 字符集合
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "abca";

            List<char> c = new List<char>();
            foreach (var item in str)
            {
                if (!c.Contains(item))
                {
                    c.Add(item);
                }
            }
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
