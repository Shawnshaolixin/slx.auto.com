using System;
using System.Collections.Generic;

namespace LeetCodeContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            LeetCode code = new LeetCode();
            //  LeetCode.TestWeightBagProblem(new int[] { 1, 3, 4,4 }, new int[] { 15, 20, 30,57 }, 4);
          var res=  code.CanPartition(new int[] { 1, 6, 1, 7,1 });
            Console.WriteLine(res);
            int[][] matrix = new int[4][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[4];
            }

            //matrix[0] = new int[] { 1, 2, 3, 4 };
            //matrix[1] = new int[] { 5, 6, 7, 8 };
            //matrix[2] = new int[] { 9, 10, 11, 12 };
            //matrix[3] = new int[] { 13, 14, 15, 16 };
            //var result = code.SpiralOrder(matrix);
            List<string> list = new List<string>();
          //  HashSet<string> hashSet = new HashSet<string>();
            list.Add("leet");
            list.Add("code");
         
         //   var result = code.WordBreak("leetcode", list);
         //   Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
