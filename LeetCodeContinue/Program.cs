using System;

namespace LeetCodeContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            LeetCode code = new LeetCode();
            int[][] matrix = new int[4][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[4];
            }

            matrix[0] = new int[] { 1, 2, 3, 4 };
            matrix[1] = new int[] { 5, 6, 7, 8 };
            matrix[2] = new int[] { 9, 10, 11, 12 };
            matrix[3] = new int[] { 13, 14, 15, 16 };
            var result = code.SpiralOrder(matrix);
            Console.ReadKey();
        }
    }
}
