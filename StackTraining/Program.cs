using System;
using System.Collections.Generic;
using System.Linq;

namespace StackTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node1 = new TreeNode(3);
            TreeNode node2 = new TreeNode(1);
            TreeNode node3 = new TreeNode(5);
            TreeNode node4 = new TreeNode(0);
            TreeNode node5 = new TreeNode(2);
            TreeNode node6 = new TreeNode(4);
            TreeNode node7 = new TreeNode(6);
            TreeNode node8 = new TreeNode(3);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;
            node5.right = node8;
            Solution s = new Solution();
            //  s.HasPathSum(node1, 12);
            //  var list = s.LevelOrder(node1);
            // var l = s.RightSideView(node1);

            //  s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            //  var lengthest = s.LengthOfLongestSubstring("pwwkew");
            //   Console.WriteLine(lengthest);

            //Console.WriteLine($"a={(int)'a'}");
            //Console.WriteLine($"A={(int)'A'}");

            //Console.WriteLine($"z={(int)'z'}");
            //Console.WriteLine($"Z={(int)'Z'}");
            //var b = s.IsPalindrome("A man, a plan, a canal: Panama");
            //Console.WriteLine(b);
            var arrs = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
            //542

            //  var b = s.IsValidBST(node1);
            //  var ii = s.TwoSum(arrs, 542);
            //[[3,9],[7,12],[3,8],[6,8],[9,10],[2,9],[0,9],[3,9],[0,6],[2,8]]
            var testData = new int[][] { new int[] { 3,9 }, new int[] { 7, 12}, new int[] { 3, 8 },
                new int[] { 6, 8},
                new int[] { 9, 10},
                new int[] { 2, 9},
                new int[] { 0, 9} ,
                new int[] { 3, 9},
                new int[] { 0, 6},
                new int[] { 2, 8}};

            //   var testData = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 } };
            //  var testData = new int[][] { new int[] { 1, 6 }, new int[] { 2, 8 }, new int[] { 7, 12 }, new int[] { 10, 16 } };
            //    var testData = new int[][] { new int[] { 10, 16 }, new int[] { 2, 8 }, new int[] { 1, 6 }, new int[] { 7, 12 } };
            var count = s.FindMinArrowShots(testData);
            Console.WriteLine(count);
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {

        public int FindMinArrowShots(int[][] points)
        {
            if (points.Length <= 0) return 0;
            points = points.OrderBy(x => x[0]).ToArray();
            int jianshu = 1;
            var temp = points[0];
            for (int i = 0; i < points.Length - 1; i++)
            {
                if (points[i + 1][0] <= temp[1])//下一个元素的头，和当前元素的尾比较
                {
                    temp[0] = points[i + 1][0];
                    temp[1] = points[i + 1][1] < temp[1] ? points[i + 1][1] : temp[1];
                    Console.WriteLine($"范围变化射击区间{temp[0]},{temp[1]}");
                    //    Console.WriteLine("有一个设计区间");
                }
                else
                {
                    temp = points[i + 1];
                    Console.WriteLine($"新的射击区间{temp[0]},{temp[1]}");
                    jianshu++;
                }
            }
            return jianshu;
        }
        /// <summary>
        /// 目标函数的和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var c = target - nums[i];
                if (dict.ContainsKey(c))
                {
                    return new int[] { dict.GetValueOrDefault(c), i };
                }

                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
            throw new ArgumentException("No two sum solution");
        }
        /// <summary>
        /// 验证二叉搜索树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool flag = true;
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;


            Verify(root, root.left, root.right, root.val, 1);
            return flag;
        }
        public void Verify(TreeNode root, TreeNode left, TreeNode right, int rootVal, int type)
        {
            if (root.left == null && root.right == null)
            {
                return;
            };
            if (root.left == null)
            {
                if (type == 1)
                {
                    flag = root.val < root.right.val && rootVal < root.right.val;
                }
                if (type == 2)
                {
                    flag = root.val < root.right.val && rootVal > root.right.val;
                }
                if (type == 3)
                {
                    flag = root.val < root.right.val && rootVal < root.right.val;
                }
                return;
            }
            if (root.right == null)
            {
                if (type == 1)
                {
                    flag = root.val > root.left.val && rootVal > root.left.val;
                }
                if (type == 2)
                {
                    flag = root.val > root.left.val && rootVal > root.left.val;
                }
                if (type == 3)
                {
                    flag = root.val > root.left.val && rootVal < root.left.val;
                }

                return;
            }
            if (root.val > left.val && root.val < right.val)
            {
                if (type == 1)
                {
                    flag = left.val < rootVal && right.val > rootVal;
                }
                if (type == 2)
                {
                    flag = rootVal > left.val && rootVal > right.val;
                }
                if (type == 3)
                {
                    flag = rootVal < left.val && rootVal < right.val;
                }
                Verify(left, left.left, left.right, rootVal, 2);
                Verify(right, right.left, right.right, rootVal, 3);
            }
            else
            {
                flag = false;
                Console.WriteLine("不合法");
            }
            return;
        }
        /// <summary>
        /// 验证回文串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            int end = s.Length - 1;

            for (int i = 0; i < end; i++)
            {
                if (end < i) return true;
                while (!((97 <= s[i] && s[i] <= 122) || (65 <= s[i] && s[i] <= 90) || s[i] >= 48 && s[i] <= 57))
                {
                    i++;
                    if (i > end) return false;
                }

                char start = (65 <= s[i] && s[i] <= 90) ? (char)(s[i] + 32) : s[i];

                while (!((97 <= s[end] && s[end] <= 122) || (65 <= s[end] && s[end] <= 90) || s[end] >= 48 && s[end] <= 57))
                {
                    end--;
                    if (i > end) return false;
                }
                char last = (65 <= s[end] && s[end] <= 90) ? (char)(s[end] + 32) : s[end];
                end--;
                if (start != last) return false;
            }
            return true;
        }
        /// <summary>
        /// 最长子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            string result = "";
            int[] char_map = new int[128];

            for (int i = 0; i < s.Length; i++)
            {
                char_map[s[i]]++;
            }
            for (int i = 0; i < 128; i++)
            {

            }
            return result;
        }
        public int LengthOfLongestSubstring(string s)
        {
            int[] char_map = new int[128];
            int result = 0;
            int begin = 0;
            string word = "";
            for (int i = 0; i < s.Length; i++)
            {
                char_map[s[i]]++;

                if (char_map[s[i]] == 1)//没有重复
                {
                    word += s[i];
                    if (result < word.Length)
                    {
                        result = word.Length;
                    }
                }
                else // 有重复
                {
                    while (begin < i && char_map[s[i]] > 1)
                    {
                        char_map[s[begin]]--;
                        begin++;
                    }
                    word = "";
                    for (int j = begin; j <= i; j++)
                    {
                        word += s[j];
                    }

                }
            }
            return result;
        }
        /// <summary>
        /// 右视图
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode node)
        {
            IList<int> result = new List<int>();
            if (node == null) return result;
            int i = 0;
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();

            queue.Enqueue(new KeyValuePair<TreeNode, int>(node, i));
            int temp = 0;
            while (queue.Count > 0)
            {
                var pair = queue.Dequeue();
                var preious = pair.Key;
                var depth = pair.Value;

                Console.WriteLine($"第{depth}层, 值是{preious.val}");

                if (depth == result.Count)//一样
                {
                    temp = preious.val;

                }
                else
                {
                    result.Add(temp);
                    temp = preious.val;

                }
                if (preious.left != null)
                {
                    var d = depth + 1;
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.left, d));
                }

                if (preious.right != null)
                {
                    var d = depth + 1;
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.right, d));
                }
            }

            result.Add(temp);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode node)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (node == null) return result;
            int i = 0;
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            List<int> item = new List<int>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(node, i));
            while (queue.Count > 0)
            {
                var pair = queue.Dequeue();
                var preious = pair.Key;
                var depth = pair.Value;
                Console.WriteLine($"第{depth}层, 值是{preious.val}");
                if (depth == result.Count)
                {
                    item.Add(preious.val);
                }
                else
                {
                    result.Add(item.ToArray());
                    item.Clear();
                    item.Add(preious.val);
                }
                if (preious.left != null)
                {
                    var d = depth + 1;
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.left, d));
                }

                if (preious.right != null)
                {
                    var d = depth + 1;
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.right, d));
                }
            }
            result.Add(item.ToArray());
            return result;
        }
        /// <summary>
        /// 是否是镜像对称****** 没理解透彻 ******
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            return Ismirror(root, root);
        }
        public bool Ismirror(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val == q.val)
            {
                return Ismirror(p.left, q.right) && Ismirror(p.right, q.left);
            }

            return false;
        }
        /// <summary>
        /// 宽度优先遍历
        /// </summary>
        /// <param name="node"></param>
        public void ForeachTreeGuangdu(TreeNode node)
        {
            if (node == null) return;
            int i = 0;
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            IList<IList<int>> result = new List<IList<int>>();
            List<int> item = new List<int>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(node, i));

            while (queue.Count > 0)
            {
                var pair = queue.Dequeue();
                var preious = pair.Key;
                var depth = pair.Value;
                Console.WriteLine($"第{depth}层, 值是{preious.val}");
                if (depth == result.Count)
                {
                    item.Add(preious.val);

                    Console.WriteLine("深度 和结果集合相同");

                }
                else
                {
                    result.Add(item.ToArray());
                    Console.WriteLine("深度和结果集合不同");
                    item.Clear();
                    item.Add(preious.val);
                }
                if (preious.left != null)
                {

                    //  node = node.left;
                    var d = depth + 1;
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.left, d));
                }

                if (preious.right != null)
                {
                    var d = depth + 1;
                    // node = node.right;
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.right, d));
                }


            }
            result.Add(item.ToArray());

        }
        /// <summary>
        /// 接水滴
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            height = new int[] { 3, 0, 2, 1, 3, 0, 1, 0, 2 };
            bool flag = true;
            List<int> list = new List<int>();
            Stack<int> stack = new Stack<int>();
            Stack<int> stepStack = new Stack<int>();
            int temp = 0;
            int step = 0;
            int totalWater = 0;
            for (int i = 0; i < height.Length; i++)
            {

                if (i < height.Length - 1)
                {

                    if (height[i] > height[i + 1])//如果后比前一个小
                    {
                        if (flag)
                        {
                            //入栈之前 拿栈顶和要入栈的元素对比 要最小的
                            if (stack.Count > 0)
                            {
                                var a = stack.Peek() < height[i] ? stack.Peek() : height[i];
                                totalWater = totalWater + a * step - temp;

                                //如果栈顶小于入栈元素  。
                                if (stack.Peek() < height[i])
                                {
                                    var tempStackTop = stack.Pop();
                                }


                            }

                            Console.WriteLine($"入栈元素={height[i]}");
                            stepStack.Push(step);
                            stack.Push(height[i]);
                            step = 0;
                            temp = 0;
                        }
                        else
                        {
                            step++;
                            temp = height[i] + temp;
                            Console.WriteLine("不入栈的下坡元素=" + height[i] + " step=" + step + "temp = " + temp);
                        }
                        flag = false;
                    }
                    else//状态转换点 第一次进来的时候 计算
                    {
                        if (stack.Count > 0)
                        {
                            step++;
                            temp = height[i] + temp;
                            Console.WriteLine("不入栈的上坡元素=" + height[i] + " step=" + step + "temp = " + temp);
                        }
                        flag = true;
                    }
                }
                else
                {
                    Console.WriteLine("到最后一个了=" + height[i]);
                    if (height[i] >= stack.Peek())
                    {
                        if (stack.Count > 0)
                        {
                            var a = stack.Peek() < height[i] ? stack.Peek() : height[i];
                            totalWater = totalWater + a * step - temp;

                        }
                        Console.WriteLine("最后一个元素也得算一下step=" + step);
                        stepStack.Push(step);
                        stack.Push(height[i]);
                    }
                }
            }
            return totalWater;
        }
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            IList<IList<int>> result = new List<IList<int>>();

            List<int[]> resultList = new List<int[]>();
            Stack<int> stack = new Stack<int>();
            Get(root, resultList, stack);
            if (resultList.Count == 0 && sum == 0) return result;
            foreach (var item in resultList)
            {
                if (item.Sum() == sum)
                {
                    result.Add(item.Reverse().ToList());
                }
            }
            return result;
        }



        public void Get(TreeNode root, List<int[]> stackList, Stack<int> item)
        {
            if (root == null)//叶子节点
            {
                return;
            };
            item.Push(root.val);
            if (root.left == null && root.right == null)//
            {

                stackList.Add(item.ToArray());

            }
            Get(root.left, stackList, item);
            Get(root.right, stackList, item);
            item.Pop();
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            List<int[]> resultList = new List<int[]>();
            Stack<int> stack = new Stack<int>();
            Get(root, resultList, stack);
            if (resultList.Count == 0 && sum == 0) return false;
            foreach (var item in resultList)
            {
                if (item.Sum() == sum)
                {
                    return true;
                }
            }
            return false;
        }



    }
    /// <summary>
    /// 二叉树
    /// </summary>
    //public class TreeNode
    //{
    //    /// <summary>
    //    /// 根节点
    //    /// </summary>
    //    public int val { get; set; }
    //    /// <summary>
    //    /// 左子树
    //    /// </summary>
    //    public TreeNode left { get; set; }
    //    public TreeNode right { get; set; }
    //    public TreeNode(int node)
    //    {
    //        this.val = node;
    //    }
    //}
}
