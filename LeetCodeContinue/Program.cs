using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeContinue
{
    class Program
    {
        private const int Lower31BitMask = 0x7FFFFFFF;
        static void Main(string[] args)
        {

            LeetCode code = new LeetCode();
            //[8860,-853,6534,4477,-4589,8646,-6155,-5577,-1656,-5779,-2619,-8604,-1358,-8009,4983,7063,3104,-1560,4080,2763,5616,-2375,2848,1394,-7173,-5225,-8244,-809,8025,-4072,-4391,-9579,1407,6700,2421,-6685,5481,-1732,-8892,-6645,3077,3287,-4149,8701,-4393,-9070,-1777,2237,-3253,-506,-4931,-7366,-8132,5406,-6300,-275,-1908,67,3569,1433,-7262,-437,8303,4498,-379,3054,-6285,4203,6908,4433,3077,2288,9733,-8067,3007,9725,9669,1362,-2561,-4225,5442,-9006,-429,160,-9234,-4444,3586,-5711,-9506,-79,-4418,-4348,-5891]
      
            var max = code.FindMaxAverage(new[] { 1, 12, -5, -6, 50, 3 },  4);
            //  LeetCode.TestWeightBagProblem(new int[] { 1, 3, 4,4 }, new int[] { 15, 20, 30,57 }, 4);
            //  var res=  code.LastStoneWeightII(new int[] { 2, 7, 4, 1, 8, 1 });
            var res = code.GenerateMatrix(5);
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    Console.Write(res[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
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
