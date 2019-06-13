using System;

namespace 楚楚街2016招聘笔试_解密_
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "WHL";
            int[] codes = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                codes[i] = (int)str[i];
              
            }
            for (int i = 0; i < codes.Length; i++)
            {
                Console.WriteLine(codes[i]);
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        static string Input(string str)
        {
            return "";
        }
    }
}
