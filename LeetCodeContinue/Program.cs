using System;

namespace LeetCodeContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            DP dp = new DP();
            //  Console.WriteLine(dp.UniquePaths(30, 20));   
            int[] arr = new int[] { 10, 9, 2, 5, 3, 7, 101, 103 };
            Console.WriteLine(dp.LengthOfLIS(arr));
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
