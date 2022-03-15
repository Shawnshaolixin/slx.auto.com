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
            TreeNode root = new TreeNode(1);
            var right = new TreeNode(2);
            right.left = new TreeNode(3);
            root.right = right;
            var result3 = code.FindRestaurant(new string[] { "KFC","K" }, new string[] { "KFC","K" });
            Console.WriteLine(result3);

            code.InorderTraversal(root);
            int[][] VideoStitchingParam = new int[6][];
            VideoStitchingParam[0] = new int[] { 0, 2 };
            VideoStitchingParam[1] = new int[] { 4, 6 };
            VideoStitchingParam[2] = new int[] { 8, 10 };
            VideoStitchingParam[3] = new int[] { 1, 9 };
            VideoStitchingParam[4] = new int[] { 1, 5 };
            VideoStitchingParam[5] = new int[] { 5, 9 };
            var re = code.VideoStitching(VideoStitchingParam, 10);
            int[][] matrix1 = new int[3][];
            matrix1[0] = new int[] { 1, 10 };
            matrix1[1] = new int[] { 9, 1 };
            matrix1[2] = new int[] { 8, 1 };
            code.FindCenter(matrix1);
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 10, 4, 2 };
            matrix[1] = new int[] { 9, 3, 8, 7 };
            matrix[2] = new int[] { 15, 16, 17, 12 };
            code.LuckyNumbers(matrix);
            Console.ReadKey();
            var max = code.FindMaxAverage(new[] { 1, 12, -5, -6, 50, 3 }, 4);
            //  LeetCode.TestWeightBagProblem(new int[] { 1, 3, 4,4 }, new int[] { 15, 20, 30,57 }, 4);
            //  var res=  code.LastStoneWeightII(new int[] { 2, 7, 4, 1, 8, 1 });
            var res = code.GenerateMatrix(5);
            var result = code.CountKDifference(new int[] { 1 }, 1);
            code.SimplifiedFractions(6);
            Console.WriteLine("res===>" + result);
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
            //int[][] matrix = new int[4][];
            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    matrix[i] = new int[4];
            //}

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
