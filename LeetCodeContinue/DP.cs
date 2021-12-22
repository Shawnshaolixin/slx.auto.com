using System;

namespace LeetCodeContinue
{
    /// <summary>
    /// 动态规划相关类型题
    /// </summary>
    public class DP
    {
        public int F(int n)
        {
            int[] dp = new int[n + 1];
            if (n <= 2) return n;
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
        /// <summary>
        /// 70. 爬楼梯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            if (n <= 2) return 0;
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
        /// <summary>
        /// 62. 不同路径
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            //第一步：定义数组元素的含义
            // 当机器人 从左上角，走到i，j 这个 位置时，一共有 dp[i,j] 种走法
            int[,] dp = new int[m, n];

            //第二步：找出数组之间的关系式
            // dp[i,j] = dp[i-1,j]+dp[i,j-1];

            // 第三步：找出初始值

            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

        /// <summary>
        /// 最长上升子序列 输入：nums = [10,9,2,5,3,7,101,18] 输出：4
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length <= 0)
            {
                return 0;
            }
            // 以nums[i]结尾的数，最长上升子序列个数
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);//默认值
            int currIndex = 0;
            int maxValue = 0;
            int lastValue = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                while (i > currIndex)
                {
                    var v1 = nums[currIndex];
                    var v2 = nums[i];
                    if (nums[currIndex] < nums[i])
                    {
                        if (maxValue == 0)
                        {
                            maxValue = dp[currIndex];
                        }
                        else
                        {
                            if (maxValue < dp[currIndex])
                            {
                                maxValue = dp[currIndex];
                            }
                        }
                    }
                    currIndex++;
                }
                dp[i] += maxValue;
                if (lastValue < dp[i])
                {
                    lastValue = dp[i];
                }
                maxValue = 0;
                currIndex = 0;
            }
            return lastValue;
        }

        /// <summary>
        /// 最长连续序列 给定一个未排序的整数数组 nums ，找出数字连续的最长序列（不要求序列元素在原数组中连续）的长度。
        /// 输入：nums = [100,4,200,1,3,2]
        /// 输出：4
        /// 解释：最长数字连续序列是[1, 2, 3, 4]。它的长度为 4。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive(int[] nums)
        {

            return 0;
        }
    }
}
