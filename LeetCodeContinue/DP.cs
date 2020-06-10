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
            // 当机器人 从左上角，走到i，j 这个 未知时，一共有 dp[i,j] 种走法
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
    }
}
