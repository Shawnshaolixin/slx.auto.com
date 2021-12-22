using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeContinue
{
    public class LeetCode
    {

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return null;
        }
        /// <summary>
        /// 224：矩形面积
        /// </summary>
        /// <param name="ax1"></param>
        /// <param name="ay1"></param>
        /// <param name="ax2"></param>
        /// <param name="ay2"></param>
        /// <param name="bx1"></param>
        /// <param name="by1"></param>
        /// <param name="bx2"></param>
        /// <param name="by2"></param>
        /// <returns></returns>
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            var area_a = (bx2 - bx1) * (by2 - by1);
            var area_b = (ax2 - ax1) * (ay2 - ay1);
            var minX = Math.Max(ax1, bx1);
            var minY = Math.Max(ay1, by1);
            var maxX = Math.Min(ax2, bx2);
            var maxY = Math.Min(ay2, by2);
            var totalArea = area_a + area_b;
            // 表示相交
            if (minX > maxX || minY > maxY)
            {
                return totalArea;
            }
            else
            {
                return totalArea - (maxX - minX) * (maxY - minY);
            }
        }
        /// <summary>
        /// 14.最长公共前缀
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            // ["flower","flow","flight"]
            if (strs.Length <= 0)
            {
                return "";
            }
            var prefixStr = strs[0];
            int index = prefixStr.Length;
            char[] charPrefixStr = prefixStr.ToCharArray();
            while (index > 0)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    var str = strs[i];
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (str[j] == charPrefixStr[j])
                        {
                            break;
                        }
                        else
                        {

                        }
                    }
                }
                index++;

            }

            return null;
        }

        //public int Reverse(int x)
        //{
        //    int rev = 0;
        //    while (x != 0)
        //    {
        //        if (rev < int.MinValue / 10 || rev > int.MaxValue / 10)
        //        {
        //            return 0;
        //        }
        //        int digit = x % 10; // 求余数
        //        x = x / 10; // 得到商不要余数
        //        rev = rev * 10 + digit;
        //    }
        //    return rev;
        //}
        public int Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                if (rev < int.MinValue / 10 || rev > int.MaxValue / 10)
                {
                    return 0;
                }
                int d = x % 10;
                x = x / 10;
                rev = rev * 10 + d;
            }
            return rev;
        }
        /// <summary>
        /// 剑指offer 024 反转链表递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode newHead = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }


        /// <summary>
        /// 剑指offer 024 反转链表迭代
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList1(ListNode head)
        {
            ListNode pre = null;
            ListNode cur = head;
            while (cur != null)
            {
                // 把下一个节点放到一个变量里面
                ListNode next = cur.next;
                //下一个节点等于上一个节点
                cur.next = pre;
                // 把当前节点复制给上一个节点
                pre = cur;
                // 当前节点指向下一个节点
                cur = next;
            }
            return pre;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode node = new ListNode(0);
            int c = 0;//用来存放进位
            ListNode head = node;
            while (l1 != null || l2 != null) // 如果两个链表 有一个不是空的时候，就往下走
            {
                int a = 0, b = 0;//第一个链表的值，和第二个链表的值
                if (l1 != null)
                {
                    a = l1.val;
                }
                if (l2 != null)
                {
                    b = l2.val;
                }
                if ((a + b + c) >= 10)// 如果第一个加第二个加第三个加上进位 大于9，就表示 进位是1 
                {
                    node.val = (a + b + c) % 10;// 新的链表的值是余数
                    c = 1;// 进位是1
                }
                else
                {
                    node.val = a + b + c;
                    c = 0;// 否则进位是0
                }

                if (l1 != null)// 链表不为空  就往下走
                {
                    l1 = l1.next;
                }
                if (l2 != null)// 链表不为空  就往下走
                {
                    l2 = l2.next;
                }
                if (l1 != null || l2 != null) // 两个都不为空，新弄一个也往下走
                {
                    node.next = new ListNode();
                    node = node.next;
                }
            }
            if (c == 1)// 最后最后了，还有进位，就特殊整一下
            {
                node.next = new ListNode(1);
            }

            return head;
        }
        /// <summary>
        /// 128.最长连续序列
        /// 给定一个未排序的整数数组 nums ，
        /// 找出数字连续的最长序列（不要求序列元素在原数组中连续）的长度。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive(int[] nums)
        {
            // 把数组都放到哈希set里
            HashSet<int> num_set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                num_set.Add(nums[i]);
            }
            int longestStreak = 0;
            foreach (var num in num_set)
            {
                if (!num_set.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;
                    while (num_set.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            return longestStreak;
        }
        class MyClass
        {
            public int Type { get; set; }
            public int Value { get; set; }

        }
        public string CountAndSay(int n)
        {
            var result = Test("1", n);
            Console.WriteLine("CountAndSay=" + result);
            return result;
        }
        Stack<char> stack = new Stack<char>();
        int count1 = 1;
        int total = 1;
        char currChar = ' ';
        string contResult = "1";
        public string Test(string content, int n)
        {
            if (total >= n)
            {
                return contResult;
            }
            contResult = "";
            total++;
            for (int i = 0; i < content.Length; i++)
            {
                stack.Push(content[content.Length - 1 - i]);
            }

            while (stack.Count > 0)
            {
                currChar = stack.Pop();
                if (stack.Count > 0)
                {
                    while (stack.Peek() == currChar)
                    {

                        count1++;
                        currChar = stack.Pop();
                        if (stack.Count <= 0) break;
                    }
                }

                contResult += count1 + "" + (currChar - 48);

                count1 = 1;

            }

            return Test(contResult, n);
        }
        /// <summary>
        /// 67. 二进制求和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {

            if (a.Length > b.Length)
            {
                int index = 0;
                while (index < b.Length)
                {

                    int s = a[index] & b[index];
                    if (s == 1)
                    {

                    }
                    else
                    {

                    }
                }
            }
            return "";
        }

        public int MySqrt(int x)
        {


            int l = 0;
            int r = x;
            int ans = -1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                ulong result = (ulong)mid * (ulong)mid;
                if (result <= (ulong)x)
                {
                    ans = mid;
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            return ans;
        }
        /// <summary>
        /// 33. 搜索旋转排序数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            // 4,5,6,7,0,1,2     0     4
            // 4,5,6,7,0,1,2     3    -1


            var n = nums.Length;
            if (n == 0)
            {
                return -1;
            }
            if (n == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            int l = 0;
            int r = n - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                // 如果 左半部分是有序的
                if (nums[0] <= nums[mid])
                {
                    if (nums[0] <= target && target < nums[mid])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                else // 右半部分是有序的
                {
                    if (nums[mid] < target && target <= nums[n - 1])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

            }

            return -1;
        }

        /// <summary>
        /// 148. 排序链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            // 没有元素或者只有一个元素 ，直接return
            if (head == null || head.next == null)
            {
                return head;
            }
            // 只有两个元素
            if (head.next.next == null)
            {
                ListNode second1 = head.next;
                if (head.val > second1.val)
                {
                    return head;
                }
                else
                {
                    second1.next = head;
                    head.next = null;
                    return second1;
                }
            }

            // 先分割，利用快慢指针分割

            ListNode fast = head;
            ListNode slow = head;
            while (true)
            {
                if (fast == null || fast.next == null)
                {
                    break;
                }

                fast = fast.next.next;
                slow = slow.next;
            }
            // 后半部分的开头
            ListNode second = slow.next;
            second = SortList(second);

            // 前半部分开投
            slow.next = null;
            ListNode first = head;
            first = SortList(first);

            // 合并
            ListNode result = new ListNode();
            head = result;
            while (first != null && second != null)
            {
                if (first.val < second.val)
                {
                    result.next = first;
                    first = first.next;
                }
                else
                {
                    result.next = second;
                    second = second.next;
                }
                result = result.next;
            }

            if (first != null)
            {
                result.next = first;
            }
            else
            {
                result.next = second;
            }
            return head.next;
        }
        /// <summary>
        /// 129. 求根节点到叶节点数字之和
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumNumbers(TreeNode root)
        {
            return Dfs(root, 0);
        }

        private int Dfs(TreeNode root, int prevSum)
        {
            if (root == null)
            {
                return 0;
            }
            int sum = prevSum * 10 + root.val;
            if (root.left == null && root.right == null)
            {
                return sum;
            }
            else
            {
                return Dfs(root.left, sum) + Dfs(root.right, sum);
            }
        }

        /// <summary>
        /// 495. 提莫攻击
        /// 
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            // 1,4   2
            // 1 首先
            int result = 0;
            for (int i = 0; i < timeSeries.Length - 1; i++)
            {
                if (timeSeries[i + 1] - timeSeries[i] > duration)
                {
                    result += duration;
                }
                else
                {
                    result += timeSeries[i + 1] - timeSeries[i];
                }
            }
            result += duration;
            return result;
        }
        /// <summary>
        /// 73. 矩阵置零
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes(int[][] matrix)
        {
            //matrix = [[1,1,1],[1,0,1],[1,1,1]]
            //[[1,0,1],[0,0,0],[1,0,1]]

            int x = -1, y = -1;
            List<int> xs = new List<int>();
            List<int> ys = new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (xs.Contains(i) || ys.Contains(j))
                        {
                            continue;
                        }
                        xs.Add(i);
                        ys.Add(j);
                        SetZeroes(matrix, i, j);
                    }
                }
            }



        }
        private void SetZeroes(int[][] matrix, int x, int y)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (i == x)
                {
                    for (int k = 0; k < matrix.Length; k++)
                    {
                        Console.WriteLine($"i={i},k={k}");
                        matrix[i][k] = 0;
                    }


                }
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (j == y)
                    {
                        Console.WriteLine($"i={i},j={j}");
                        matrix[i][j] = 0;
                    }
                }
            }
        }
        public bool CanPartition(int[] nums)
        {
            // 1,5,11,5
            // 背包的总容量是 22 一半容量是 11
            // dp 数组 dp[i]表示，容量为 i的 背包，所背的物品价值可以最大为dp[i]

            int[] dp = new int[10001];
            for (int i = 0; i < nums.Length; i++)
            {

            }
            return false;
        }
        public int LongestPalindromeSubseq(string s)
        {


            return 0;
        }
        /// <summary>
        /// 257. 二叉树的所有路径
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            IList<string> result = new List<string>();
            string path = "";
            ConstructPaths(stack, root, result, path);
            return result;
        }
        private void ConstructPaths(Stack<TreeNode> stack, TreeNode node, IList<string> result, string path)
        {
            if (node == null)
            {
                return;
            }
            path += node.val;
            stack.Push(node);
            if (node.left == null && node.right == null) //当前是叶子节点
            {
                result.Add(path);
            }
            else
            {
                path += "->";
                ConstructPaths(stack, node.left, result, path);
                ConstructPaths(stack, node.right, result, path);
                stack.Pop();
            }

        }
        /// <summary>
        /// 347. 前 K 个高频元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums.Length == 1)
            {
                return nums;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int maxValue = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                    if (dict[nums[i]] > maxValue)
                    {
                        maxValue = dict[nums[i]];
                    }
                }
                else
                {
                    dict.Add(nums[i], 1);
                }

            }
            int[] soreArr = new int[maxValue + 1];
            foreach (var item in dict)
            {
                soreArr[item.Value] = item.Key;
            }
            var result = soreArr.Skip(soreArr.Length - k).Take(k).ToArray();
            return result;
        }
        /// <summary>
        /// 167. 两数之和 II - 输入有序数组
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {

            return null;
        }
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    result = (i - dict[nums[i]]);

                    dict[nums[i]] = i;
                    if (result <= k)
                    {
                        return true;
                    }
                }
                else
                {
                    dict.Add(nums[i], i);
                }
            }
            return false;
        }
        //public bool ContainsDuplicate(int[] nums)
        //{
        //    Dictionary<int, int> dict = new Dictionary<int, int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (dict.ContainsKey(nums[i]))
        //        {
        //            // dict[nums[i]]++;
        //            return true;
        //        }
        //        else
        //        {
        //            dict.Add(nums[i], i);
        //        }
        //    }
        //    return false;
        //}
        /// <summary>
        /// 88. 合并两个有序数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            while (n > 0)
            {
                if (m > 0)
                {
                    if (nums2[n - 1] >= nums1[m - 1])
                    {
                        nums1[m + n - 1] = nums2[n - 1];
                        n--;
                    }
                    else
                    {

                        nums1[m + n - 1] = nums1[m - 1];
                        m--;
                    }

                }
                else
                {
                    nums1[m + n - 1] = nums2[n - 1];
                    n--;
                }

            }

            //for (int i = m,j=0; i < m+n; i++,j++)
            //{
            //    nums1[i] = nums2[j];
            //}
            //Array.Sort(nums1);

        }
        public int[] DailyTemperatures(int[] temperatures)
        {

            Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();
            stack.Push(new KeyValuePair<int, int>(0, temperatures[0]));
            int[] result = new int[temperatures.Length];
            for (int i = 1; i < temperatures.Length; i++)
            {
                var value = temperatures[i];
                while (stack.Count > 0 && stack.Peek().Value < value)
                {
                    var top = stack.Pop();
                    result[top.Key] = i - top.Key;
                }
                stack.Push(new KeyValuePair<int, int>(i, temperatures[i]));
            }
            return result;
        }


        /// <summary>
        /// 739. 每日温度
        /// temperatures = [73, 74, 75, 71, 69, 72, 76, 73]
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public int[] DailyTemperatures1(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];
            for (int i = 0; i < temperatures.Length; i++)
            {
                int j = i;
                if (i > 0 && temperatures[i] == temperatures[j - 1] && result[i - 1] > 0)
                {
                    result[i] = result[i - 1] - 1;
                    continue;
                }
                while (j < temperatures.Length - 1)
                {
                    if (temperatures[i] < temperatures[j + 1])
                    {
                        result[i] = j + 1 - i;
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 剑指 Offer 39. 数组中出现次数超过一半的数字
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {

            }
            return 0;
        }
        /// <summary>
        /// 剑指 Offer 42. 连续子数组的最大和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray1(int[] nums)
        {
            if (nums.Length <= 0)
            {
                return 0;
            }
            // 动态规划五部曲
            //1、 定义dp数组，确认 i 和  dp[i] 的含义
            //2. 确认递推函数
            // [-2,1,-3,4,-1,2,1,-5,4]
            // dp[i] 表示：以 i 结尾的数，的最大和是多少
            //  int[] dp = new int[nums.Length];

            var max = nums[0];
            int value = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                //   dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                value = Math.Max(value + nums[i], nums[i]);
                if (max < value)
                {
                    max = value;
                }
            }
            return max;
        }
        /// <summary>
        /// 106. 从中序与后序遍历序列构造二叉树
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {

            TreeNode treeNode = new TreeNode(postorder[postorder.Length - 1]);
            if (postorder.Length <= 0)
            {
                return null;
            }
            BuildTree(treeNode, postorder, inorder);
            return treeNode;
        }
        private void BuildTree(TreeNode root, int[] postorder, int[] inorder)
        {
            if (postorder.Length <= 0)
            {
                return;
            }

            int index = FindValue(inorder, postorder[postorder.Length - 1]);
            if (index < 0)
            {
                return;
            }

            if (index >= 0)
            {
                //   var arr = inorder.Take(index).ToArray();
                var skip = postorder.Length - (postorder.Length - index);
                var take = postorder.Length - skip - 1;
                var new_postorder = postorder.Skip(skip).Take(take).ToArray();
                var new_inorder = inorder.Skip(index + 1).Take(take).ToArray();
                if (new_postorder.Length > 0)
                {
                    root.right = new TreeNode(new_postorder[new_postorder.Length - 1]);
                    BuildTree(root.right, new_postorder, new_inorder);

                }


            }
            if (index < postorder.Length)
            {
                var skip = postorder.Length - postorder.Length - index; // 4-1 = 3
                var take = postorder.Length - postorder.Length - skip;
                var new_postorder = postorder.Take(take).ToArray();
                var new_inorder = inorder.Take(index).ToArray();
                if (new_postorder.Length > 0)
                {
                    root.left = new TreeNode(new_postorder[new_postorder.Length - 1]);
                    BuildTree(root.left, new_postorder, new_inorder);
                }


            }

        }
        /// <summary>
        /// 105. 从前序与中序遍历序列构造二叉树
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree1(int[] preorder, int[] inorder)
        {

            TreeNode treeNode = new TreeNode(preorder[0]);
            if (preorder.Length <= 0)
            {
                return null;
            }
            BuildTree1(treeNode, preorder, inorder);
            return treeNode;
        }
        private void BuildTree1(TreeNode root, int[] preorder, int[] inorder)
        {
            if (preorder.Length <= 0)
            {
                return;
            }

            int index = FindValue(inorder, preorder[0]);
            if (index < 0)
            {
                return;
            }

            if (index >= 0)
            {
                //   var arr = inorder.Take(index).ToArray();
                var new_preorder = preorder.Skip(1).Take(index).ToArray();
                var new_inorder = inorder.Take(index).ToArray();
                if (new_preorder.Length > 0)
                {
                    root.left = new TreeNode(new_preorder[0]);
                    BuildTree1(root.left, new_preorder, new_inorder);

                }


            }
            if (index < preorder.Length)
            {
                var new_preorder = preorder.Skip(1 + index).Take(preorder.Length - 1 + index).ToArray();
                var new_inorder = inorder.Skip(index + 1).Take(preorder.Length - 1 + index).ToArray();
                if (new_preorder.Length > 0)
                {
                    root.right = new TreeNode(new_preorder[0]);
                    BuildTree1(root.right, new_preorder, new_inorder);
                }


            }

        }
        private int FindValue(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (value == arr[i])
                {
                    return i;

                }
            }
            return -1;
        }
        /// <summary>
        /// 145. 二叉树的后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            Postorder(root, result);
            return result;
        }
        public void Postorder(TreeNode root, IList<int> result)
        {
            if (root == null)
            {
                return;
            }

            Postorder(root.left, result);
            result.Add(root.val);
            Postorder(root.right, result);

        }
        /// <summary>
        /// 96. 不同的二叉搜索树
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTrees(int n)
        {

            // 动态规划五部曲

            int[] dp = new int[n];

            // 递推公式
            // 遍历 1 - n (i)
            // 比i小的，都当作左子树，比i大的都当作i的右子树
            for (int i = 1; i <= n; i++)
            {
                dp[i] = dp[i - 1] + i;
            }

            return 0;
        }
        /// <summary>
        /// 118.杨辉三角 
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            int[][] dp = new int[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                dp[i] = new int[i + 1];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    if (i == 0 || j == 0 || j == dp[i].Length - 1)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j - 1] + dp[i - 1][j];
                    }

                }
            }
            return dp;
        }
        /// <summary>
        /// 整数拆分
        /// 给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int IntegerBreak(int n)
        {
            //这个数拆分成
            int[] dp = new int[n / 2 + 2];
            //n = x + y ;
            // 设x 从1 开始，到n/2+1 的位置 计算出来y
            for (int x = 1; x <= n / 2 + 1; x++)
            {
                int y = n - x;
                dp[x] = x * y;
            }
            return dp.Max();
        }
        /// <summary>
        /// 62.不同路径
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            //确定dp数组以及下标的含义
            // dp[m][n] = dp[m-1][n]+dp[m][n-1];

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i][j] = 1;
                    }

                }
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {

                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m - 1][n - 1];
        }
        /// <summary>
        /// 63.不同路径2
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] grid)
        {
            int[][] dp = new int[grid.Length][];

            if (grid[0][0] == 1)
            {
                return 0;
            }
            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[i].Length];

                for (int j = 0; j < grid[i].Length; j++)
                {

                    if (i == 0 || j == 0)
                    {
                        if (grid[i][j] == 1)
                        {
                            break;
                        }
                        if (i > 0)
                        {
                            if (dp[i - 1][j] == 1)
                            {
                                dp[i][j] = 1;
                            }
                            else
                            {
                                dp[i][j] = 0;
                            }
                        }
                        else
                        {
                            dp[i][j] = 1;
                        }
                    }
                }
            }
            for (int i = 1; i < grid.Length; i++)
            {

                for (int j = 1; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        dp[i][j] = 0;
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    }
                }
            }
            return dp[grid.Length - 1][dp[0].Length - 1];
        }
        /// <summary>
        /// 746.使用最小花费爬楼梯
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            //动态规划五部曲
            //1.确定dp数组以及下标的含义00
            int[] dp = new int[cost.Length + 1]; //爬到第i阶的最小体力值
            dp[0] = cost[0];
            dp[1] = cost[1];
            if (cost.Length == 2)
            {
                return Math.Min(cost[0], cost[1]);
            }
            //2.确定递推公式
            for (int i = 2; i <= cost.Length; i++)
            {
                if (i < cost.Length)
                {
                    dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];
                }
                else
                {
                    dp[i] = Math.Min(dp[i - 1], dp[i - 2]);
                }

            }
            //3.dp数组如何初始化
            // 如果有一个阶梯的话，只能选一所以 dp[0]=cost[0];,如果有两个阶梯的话 dp[1]=Min(cost[0],cost[1]);
            //4.确定遍历顺序
            //5.举例推导dp数组
            return dp[cost.Length];
        }
        /// <summary>
        /// 40.组合总和II
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> path = new List<int>();
            bool[] used = new bool[candidates.Length];
            BackTrackingCombanationSum2(candidates, result, path, 0, 0, target, used);
            return result;
        }
        public void BackTrackingCombanationSum2(int[] candidates, IList<IList<int>> result, IList<int> path, int startIndex, int sum, int target, bool[] used)
        {
            if (sum > target)
            {
                return;
            }
            if (sum == target)
            {
                result.Add(path.ToArray());
                Console.WriteLine("结果------》" + string.Join(",", path));

            }
            for (int i = startIndex; i < candidates.Length && sum + candidates[i] <= target; i++)
            {
                if (i > 0 && candidates[i] == candidates[i - 1] && used[i - 1] == false)
                {
                    continue;
                }
                sum += candidates[i];
                path.Add(candidates[i]);
                used[i] = true;
                Console.WriteLine("递归-》" + string.Join(",", path));
                BackTrackingCombanationSum2(candidates, result, path, i + 1, sum, target, used);
                sum -= candidates[i];
                path.RemoveAt(path.Count - 1);
                used[i] = false;
                Console.WriteLine("回溯-》" + string.Join(",", path));
            }
        }
        /// <summary>
        /// 216.组合总和 III
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> path = new List<int>();
            BackTrackingCombinationSum3(res, path, n, k, 1);
            return res;
        }
        public void BackTrackingCombinationSum3(IList<IList<int>> result, IList<int> path, int n, int k, int startIndex)
        {
            if (path.Sum() > n)
            {
                return;
            }
            if (path.Sum() == n && path.Count == k)
            {
                result.Add(path.ToArray());
                return;
            }
            for (int i = startIndex; i <= 9 - (k - path.Count) + 1; i++)
            {
                path.Add(i);
                BackTrackingCombinationSum3(result, path, n, k, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }
        /// <summary>
        /// 77.组合
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> path = new List<int>();
            BackTrackingCombine(res, path, n, k, 1);
            return res;
        }
        public void BackTrackingCombine(IList<IList<int>> result, IList<int> path, int n, int k, int startIndex)
        {
            if (path.Count == k)
            {
                result.Add(path.ToArray());
                return;
            }
            for (int i = startIndex; i <= n - (k - path.Count) + 1; i++)
            {
                path.Add(i);
                BackTrackingCombine(result, path, n, k, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }
        public IList<IList<int>> Permute(int[] nums)
        {
            int len = nums.Length;
            // 使用一个动态数组保存所有可能的全排列
            IList<IList<int>> res = new List<IList<int>>();
            if (len == 0)
            {
                return res;
            }

            bool[] used = new bool[len];
            List<int> path = new List<int>();

            Mydfs(nums, len, 0, path, used, res);
            return res;
        }
        public void Mydfs(int[] nums, int len, int depth, List<int> path, bool[] used, IList<IList<int>> res)
        {
            if (depth == len)
            {

                res.Add(path.ToArray());
                return;
            }

            // 在非叶子结点处，产生不同的分支，这一操作的语义是：
            // 在还未选择的数中依次选择一个元素作为下一个位置的元素，这显然得通过一个循环实现。
            for (int i = 0; i < len; i++)
            {
                if (!used[i])
                {
                    path.Add(nums[i]);
                    used[i] = true;
                    Console.WriteLine("递归之前=>" + string.Join(",", path));
                    Mydfs(nums, len, depth + 1, path, used, res);
                    // 注意：下面这两行代码发生 「回溯」，回溯发生在从 深层结点 回到 浅层结点 的过程，
                    // 代码在形式上和递归之前是对称的
                    used[i] = false;
                    path.RemoveAt(path.Count - 1);
                    Console.WriteLine("递归之后=>" + string.Join(",", path));
                }
            }
        }
        /// <summary>
        /// 46.全排列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            int len = nums.Length;
            // 使用一个动态数组保存所有可能的全排列
            IList<IList<int>> res = new List<IList<int>>();
            if (len == 0)
            {
                return res;
            }
            bool[] used = new bool[len];
            List<int> path = new List<int>();
            Dictionary<int, List<int>> depthDcit = new Dictionary<int, List<int>>();
            Mydfs1(nums, len, 0, path, used, res, depthDcit);
            return res;

        }

        public void Mydfs1(int[] nums, int len, int depth, List<int> path, bool[] used, IList<IList<int>> res,
            Dictionary<int, List<int>> depthDcit)
        {
            if (depth == len)
            {

                res.Add(path.ToArray());
                // depthDcit.Clear();
                return;
            }

            // 在非叶子结点处，产生不同的分支，这一操作的语义是：
            // 在还未选择的数中依次选择一个元素作为下一个位置的元素，这显然得通过一个循环实现。
            for (int i = 0; i < len; i++)
            {
                if (!used[i])
                {

                    if (depthDcit.ContainsKey(depth))
                    {
                        if (depthDcit[depth].Contains(nums[i]))
                        {
                            if (i < len)
                            {
                                Console.WriteLine($"第{depth}层重复了{nums[i]}");
                                continue;
                            }
                        }
                        else
                        {
                            depthDcit[depth].Add(nums[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"添加了第{depth}层，value={nums[i]}");
                        depthDcit.Add(depth, new List<int> { nums[i] });
                    }
                    path.Add(nums[i]);
                    used[i] = true;
                    Console.WriteLine("递归之前=>" + string.Join(",", path));
                    Mydfs1(nums, len, depth + 1, path, used, res, depthDcit);
                    // 注意：下面这两行代码发生 「回溯」，回溯发生在从 深层结点 回到 浅层结点 的过程，
                    // 代码在形式上和递归之前是对称的
                    used[i] = false;


                    // depthDcit[]

                    if (depthDcit.ContainsKey(path.Count))
                    {
                        depthDcit.Remove(path.Count);
                    }

                    path.RemoveAt(path.Count - 1);

                    Console.WriteLine("递归之后=>" + string.Join(",", path));
                }
            }
        }

        /// <summary>
        /// 39.组合总和
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> ans = new List<int>();
            backTracking(ans, result, candidates, target, 0, 0);
            return result;
        }
        public void backTracking(IList<int> path, IList<IList<int>> result, int[] candidates,
            int target, int startIndex, int sum)
        {
            if (sum > target)
            {
                return;
            }

            if (sum == target)
            {
                result.Add(path.ToArray());
                return;
            }

            for (int i = startIndex; i < candidates.Length && sum + candidates[i] <= target; i++)
            {
                sum += candidates[i];
                path.Add(candidates[i]);
                Console.WriteLine("递归-》" + string.Join(",", path));
                backTracking(path, result, candidates, target, i, sum);
                path.RemoveAt(path.Count - 1);
                sum -= candidates[i];
                Console.WriteLine("回溯-》" + string.Join(",", path));

            }
        }
        /// <summary>
        /// 202.快乐数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {

            return false;
        }

        /// <summary>
        /// 50.Pow
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            //var result = x << n;
            return 0;
        }
        /// <summary>
        /// 279.完全平方数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1]; // 默认初始化值都为0
            for (int i = 1; i <= n; i++)
            {
                dp[i] = i; // 最坏的情况就是每次+1
                for (int j = 1; i - j * j >= 0; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1); // 动态转移方程
                }
            }
            return dp[n];
        }


        /// <summary>
        /// 70.爬楼梯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n <= 2)
            {
                return n;
            }
            int[] dp = new int[n + 1];
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
        /// 213.打家劫舍2
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob2(int[] nums)
        {
            if (nums.Length <= 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            var nums1 = new int[nums.Length - 1];
            var nums2 = new int[nums.Length - 1];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0)
                {
                    nums1[i - 1] = nums[i];
                }
                if (i != nums.Length - 1)
                {
                    nums2[i] = nums[i];
                }
            }
            return Math.Max(Rob(nums1), Rob(nums2));
            // return Math.Max(Rob())

        }
        /// <summary>
        /// 337. 打家劫舍3
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Rob(TreeNode root)
        {
            List<KeyValuePair<TreeNode, int>> list = new List<KeyValuePair<TreeNode, int>>();

            List<int> listVal = new List<int>();

            if (root == null)
            {
                return 0;
            }
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
            while (queue.Count > 0)
            {
                var tree = queue.Dequeue();

                if (tree.Key.left != null)
                {

                    queue.Enqueue(new KeyValuePair<TreeNode, int>(tree.Key.left, tree.Value + 1));
                }
                if (tree.Key.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(tree.Key.right, tree.Value + 1));
                }
                list.Add(tree);
            }
            var res = list.GroupBy(c => c.Value);

            foreach (var item in res)
            {
                listVal.Add(item.Sum(c => c.Key.val));
            }
            return Rob(listVal.ToArray());
        }
        /// <summary>
        /// 198.打家劫舍
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            // dp 里面存的是 当有 x 个房间时， 最多可以偷多少钱
            // 例如 dp[0] 当有一个房间时，最多可以偷多少钱 =nums[0]
            // dp[1] 当有两个房间时，最多可以偷多少钱 = Max(nums[0],nums[1]);
            // dp[i] ,(i>2)  dp[i]= Max(dp[i-2]+nums[i],dp[i-1];

            if (nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[nums.Length - 1];
        }
        /// <summary>
        /// 120.三角形最小路径和
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int[][] dp = new int[triangle.Count][];
            for (int i = 0; i < triangle.Count; i++)
            {
                dp[i] = new int[triangle[i].Count];
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    if (i == 0 && j == 0)//最顶层元素
                    {
                        dp[i][j] = triangle[i][j];
                    }
                    else
                    {
                        if (j == 0 || j == triangle[i].Count - 1)//如果是第一个元素，或者是最后一个元素
                        {
                            dp[i][j] = dp[i - 1][j - 1 < 0 ? 0 : j - 1] + triangle[i][j];
                        }
                        else// 中间的
                        {
                            dp[i][j] = Math.Min(dp[i - 1][j - 1], dp[i - 1][j]) + triangle[i][j];
                        }
                    }


                }
            }
            return dp[triangle.Count - 1].Min();
        }
        /// <summary>
        /// 64.最小路径和
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            int[][] dp = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[i].Length];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = grid[i][j];
                    }
                    if (i == 0 && j != 0)
                    {
                        dp[i][j] = dp[0][j - 1] + grid[i][j];
                    }
                    if (i != 0 && j == 0)
                    {
                        dp[i][j] = dp[i - 1][0] + grid[i][j];
                    }
                    if (i != 0 && j != 0)
                    {
                        dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + grid[i][j];
                    }
                }
            }
            return dp[grid.Length - 1][grid[grid.Length - 1].Length - 1];
        }
        /// <summary>
        /// 121.买卖股票的最佳时机
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
            {
                return 0;
            }
            //7,1,5,3,6,4
            int[] dp = new int[prices.Length];
            dp[0] = 0;
            dp[1] = (prices[1] - prices[0]) > 0 ? prices[1] - prices[0] : 0;
            for (int i = 2; i < prices.Length; i++)
            {
                if ((prices[i] - prices[i - 1]) > 0)
                {
                    dp[i] = dp[i - 1] + prices[i] - prices[i - 1];
                }
                else
                {
                    var sum1 = prices[i - 1] - prices[i];
                    var num = dp[i - 1] - sum1;
                    dp[i] = num > 0 ? num : 0;
                }

            }
            return dp.Max();
        }
        /// <summary>
        /// 53.最大子序和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            //
            int[] dp = new int[nums.Length];
            int sum = nums[0];
            dp[0] = sum;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
            }
            return dp.Max();
        }
        private int GetMaxSum(int[] nums, int i)
        {
            int index = 0;
            int sum = nums[0];
            while (index <= i)
            {
                var mySum = GetSum(nums, index, i);
                if (mySum > sum)
                {
                    sum = mySum;
                }
                index++;
            }
            return sum;
        }
        private int GetSum(int[] nums, int startIndex, int endIndex)
        {
            int sum = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += nums[i];
            }
            return sum;
        }
        /// <summary>
        /// 5.最长回文子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(s))
            {
                return result;
            }
            int hightIndex = s.Length - 1;
            int lowIndex = 0;
            int startIndex = lowIndex;
            int endIndex = hightIndex;
            while (lowIndex < s.Length)
            {
                if (s[startIndex] == s[endIndex])
                {
                    hightIndex = endIndex;

                    while (startIndex < endIndex)
                    {
                        if (s[startIndex] == s[endIndex])
                        {
                            startIndex++;
                            endIndex--;
                        }
                        else
                        {
                            // Console.WriteLine("不是回文串");
                            endIndex = hightIndex;
                            startIndex = lowIndex;
                            break;
                        }
                    }
                    if (startIndex == endIndex || endIndex == startIndex - 1)
                    {
                        var str = s.Substring(lowIndex, hightIndex - lowIndex + 1);
                        if (result.Length < str.Length)
                        {
                            result = str;
                        }

                        lowIndex++;
                        hightIndex = s.Length - 1;
                        startIndex = lowIndex;
                        endIndex = hightIndex;
                        continue;
                    }
                }
                if (startIndex < endIndex)
                {
                    endIndex--;
                }
            }
            return result;
        }
        public string ReverseWords(string s)
        {
            var strs = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                sb.Append(strs[strs.Length - 1 - i]);
                if (strs.Length - 1 - i != 0)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 广度优先搜索
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] LevelOrder1(TreeNode root)
        {
            List<int> list = new List<int>();
            if (root == null)
            {
                return list.ToArray();
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode tree = queue.Dequeue();
                Console.WriteLine("->" + tree.val);
                if (tree.left != null)
                {
                    queue.Enqueue(tree.left);
                }
                if (tree.right != null)
                {
                    queue.Enqueue(tree.right);
                }
                list.Add(tree.val);
            }
            return list.ToArray();
        }

        public int[] LevelOrder(TreeNode root)
        {
            List<int> list = new List<int>();

            Print(root, list);
            return list.ToArray();
        }
        public static void Print(TreeNode root, List<int> list)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.val);
            list.Add(root.val);
            Print(root.left, list);
            Print(root.right, list);
        }
        /// <summary>
        /// 338. 比特位计数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] CountBits(int n)
        {
            int[] arr = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                int result1 = 0;
                for (int j = 0; j < 32; j++)
                {
                    if ((n & (1 << j)) != 0)
                    {
                        result1++;
                    }
                }
                arr[i] = result1;
                result1 = 0;
            }
            return arr;
        }
        public int HammingWeight(uint n)
        {
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((n & (1 << i)) != 0)
                {
                    result++;
                }
            }
            return result;
        }
        /// <summary>
        /// 42.接雨水
        /// 获取所有转折点
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {

            var maxValue = height.Max();
            for (int i = 0; i < maxValue; i++)
            {
                for (int j = 0; j < height.Length; j++)
                {
                    if (j == i)
                    {

                    }
                }
            }



            ////0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1
            //Dictionary<int, int> dict = new Dictionary<int, int>();

            //int riseCount = 0;
            //int declineCount = 0;
            //for (int i = 0; i < height.Length - 1; i++)
            //{
            //    if (height[i] > height[i + 1])// 下降
            //    {
            //        declineCount++;
            //        if (riseCount != 0 || i == 0)// 第一次就是下降也算进去
            //        {
            //            Console.WriteLine($"riseCount!=0,height index={i},value=" + height[i]);
            //            dict.Add(i, height[i]);
            //        }
            //        riseCount = 0;
            //    }
            //    else
            //    {
            //        if (declineCount != 0)
            //        {
            //            Console.WriteLine($"declineCount!=0,height index={i},value=" + height[i]);
            //        }
            //        declineCount = 0;
            //        riseCount++;
            //    }

            //}
            //foreach (var item in dict[])
            //{

            //}
            return 0;
        }

        public uint reverseBits(uint n)
        {
            byte[] bytes = new byte[32];
            var str = Convert.ToString(n, 2);

            // var result = sb.ToString();
            // var b = Convert.ToByte(n);
            return n;
        }

        /// <summary>
        /// 二分法查找,二分查找的条件是原数组有序
        /// 没有找到，返回-1；找到了，则返回索引
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="low">开始索引</param>
        /// <param name="height">结束索引</param>
        /// <param name="value">要查找的对象</param>
        static int BinarySearch(int[] arr, int low, int high, int value)
        {

            if (arr == null || arr.Length == 0 || low > high)
            {
                return -1;
            }
            if (arr[low] == value)
            {
                return low;
            }
            if (arr[high] == value)
            {
                return high;
            }
            int mid = (low + high) / 2;
            if (value == arr[mid]) //刚好找到对象，返回索引
            {

                return mid;
            }
            else if (value > arr[mid]) // 要查找的对象在右边
            {
                return BinarySearch(arr, mid + 1, high, value);
            }
            else //要查找的对象在左边
            {
                return BinarySearch(arr, low, mid - 1, value);
            }

        }
        int currTargetValue = int.MaxValue;
        /// <summary>
        /// 15:三数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length <= 2)
            {
                return result;
            }
            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            Array.Sort(nums);
            int oneIndex = 0;
            int twoIndex = 1;
            int threeIndex = 2;
            while (oneIndex < nums.Length - 2)
            {

                var targetValue = nums[oneIndex] + nums[twoIndex];
                //while (targetValue == currTargetValue)
                //{
                //    twoIndex++;
                //    threeIndex = twoIndex + 1;
                //    if (twoIndex == nums.Length - 1)
                //    {
                //        oneIndex++;
                //        twoIndex = oneIndex + 1;
                //        threeIndex = twoIndex + 1;
                //    }
                //    if (twoIndex > nums.Length - 2)
                //    {
                //        break;
                //    }
                //}

                //currTargetValue = targetValue;

                int index = -1;
                if (nums.Length == 3)
                {
                    index = targetValue + nums[2] == 0 ? 2 : -1;
                }
                else
                {
                    index = BinarySearch(nums, threeIndex, nums.Length - 1, -targetValue);

                }

                if (index != -1)
                {
                    int[] arr = new int[3];
                    arr[0] = nums[oneIndex];
                    arr[1] = nums[twoIndex];
                    arr[2] = nums[index];
                    var key = arr[0].ToString() + arr[1].ToString() + arr[2].ToString();
                    if (dict.ContainsKey(key))
                    {

                    }
                    else
                    {
                        dict.Add(key, true);
                        result.Add(arr.ToList());
                    }

                }
                twoIndex++;
                threeIndex = twoIndex + 1;
                if (twoIndex == nums.Length - 1)
                {
                    oneIndex++;
                    twoIndex = oneIndex + 1;
                    threeIndex = twoIndex + 1;
                }
                if (twoIndex > nums.Length - 2)
                {
                    break;
                }
            }
            return result;
        }
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length <= 2)
            {
                return result;
            }
            Array.Sort(nums);
            return null;

        }

        int count = 0;
        /// <summary>
        /// 494: 目标和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int target)
        {
            Backtrack(nums, target, 0, 0);
            return count;

        }
        public void Backtrack(int[] nums, int target, int index, int sum)
        {
            if (index == nums.Length)
            {
                if (sum == target)
                {
                    count++;
                }
            }
            else
            {
                Backtrack(nums, target, index + 1, sum + nums[index]);
                Backtrack(nums, target, index + 1, sum - nums[index]);
            }
        }
        /// <summary>
        /// 203:移除链表元素
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }
            ListNode tempNode = head;
            ListNode preNode = head;
            ListNode nextNode = head.next;
            while (tempNode != null && tempNode.val == val)
            {
                tempNode = tempNode.next;
            }
            while (head != null)
            {
                while (head != null && head.val == val)
                {
                    head = head.next;
                    preNode.next = head;
                }
                if (head == null)
                {
                    break;
                }
                preNode = head;
                nextNode = head.next;
                head = head.next;
            }
            return tempNode;
        }
        /// <summary>
        /// 692.前K个高频词
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> TopKFrequent(string[] words, int k)
        {
            if (words == null)
            {
                return null;
            }
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var item in words)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            var sortResult = from pair in dict orderby pair.Value descending, pair.Key ascending select pair;
            return sortResult.Take(k).Select(c => c.Key).ToList();
        }
        public bool WordBreak(string s, IList<string> wordDict)
        {

            return false;
        }

        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> result = new List<IList<string>>();
            IList<string> path = new List<string>();
            BacktrackingBartition(result, path, s, 0);
            return result;
        }
        public void BacktrackingBartition(IList<IList<string>> result, IList<string> path, string s, int startIndex)
        {
            if (startIndex >= s.Length)
            {
                result.Add(path.ToArray());
                return;
            }
            for (int i = startIndex; i < s.Length; i++)
            {
                if (IsPartition(s, startIndex, i))
                {
                    var str = s.Substring(startIndex, i - startIndex + 1);
                    path.Add(str);
                }
                else
                {
                    continue;
                }
                BacktrackingBartition(result, path, s, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }

        private bool IsPartition(string s, int startIndex, int endIndex)
        {
            if (s.Length <= 0)
            {
                return false;
            }
            bool flag = true;
            while (startIndex <= endIndex)
            {
                if (s[startIndex] == s[endIndex])
                {
                    startIndex++;
                    endIndex--;
                }
                else
                {
                    flag = false;
                    break;
                }

            }
            return flag;
        }
    }
}
