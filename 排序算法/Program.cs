using System;

namespace 排序算法
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  
            var arr = Selection(new int[] { 2, 3, 4, 1, 5 });

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            #endregion
            Console.ReadKey();
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] MaoPao(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

                }

            }

            return arr;
        }
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Selection(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int maxIndex = 0;
                int max = arr[0];
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (max > arr[j + 1])
                    {
                        maxIndex = j;
                    }
                    else
                    {
                        max = arr[j + 1];
                        maxIndex = j + 1;
                    }
                }
                var temp = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = arr[maxIndex];
                arr[maxIndex] = temp;
            }
            return arr;
        }
        public static int GetMax(int[] arr)
        {
            int max = arr[0];
            int maxIndex = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }
}
