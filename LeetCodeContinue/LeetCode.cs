using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeContinue
{
    public class Solution
    {

        /// <summary>
        /// 497. 非重叠矩形中的随机点
        /// </summary>
        /// <param name="rects"></param>
        public Solution(int[][] rects)
        {

        }

        public int[] Pick()
        {
            return null;
        }
    }

    /// <summary>
    ///   最近的请求次数
    /// </summary>
    public class RecentCounter
    {
        List<int> list = new List<int>();

        public RecentCounter()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t">t:是毫秒</param>
        /// <returns></returns>
        public int Ping(int t)
        {
            int count = 0;

            list.Add(t);
            var lastIndex = list.Count() - 1;
            int value = list[lastIndex];
            while (t - value <= 3000 && lastIndex >= 0)
            {
                count++;
                if (lastIndex == 0)
                {
                    return count;
                }
                lastIndex--;
                value = list[lastIndex];

            }

            return count;

        }
    }
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
    public class Node1
    {
        public int val;
        public Node1 left;
        public Node1 right;
        public Node1 next;

        public Node1() { }

        public Node1(int _val)
        {
            val = _val;
        }

        public Node1(int _val, Node1 _left, Node1 _right, Node1 _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class StockSpanner
    {
        List<int> list;
        /// <summary>
        /// 
        /// </summary>
        public StockSpanner()
        {
            list = new List<int>();
        }
        public int Next(int price)
        {
            list.Add(price);
            if (list.Count == 1)
            {
                return 1;
            }
            int count = 0;
            var last = list[list.Count - 1];
            for (int i = 0; i < list.Count; i++)
            {
                var curr = list[list.Count - i - 1];//最后一个元素
                if (last >= curr)
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            return count;
        }
    }
    public class LeetCode
    {

        /// <summary>
        /// 剑指 Offer 47. 礼物的最大价值
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue(int[][] grid)
        {
            int[][] dp = new int[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[i].Length];

            }
            dp[0][0] = grid[0][0];
            for (int i = 1; i < grid.Length; i++)
            {
                dp[i][0] = dp[i - 1][0] + grid[i][0];
            }
            for (int i = 1; i < grid[0].Length; i++)
            {
                dp[0][i] = dp[0][i - 1] + grid[0][i];
            }
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (j > 0 && i > 0)
                    {
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]) + grid[i][j];
                    }

                }
            }
            return dp[dp.Length - 1][dp[0].Length - 1];
        }
        /// <summary>
        /// 1653. 使字符串平衡的最少删除次数
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumDeletions(string s)
        {
            // 动态规划5部曲
            int[] dp = new int[s.Length];
            int[] b_arr_count = new int[s.Length];
            if (s[0] == 'b')
            {
                b_arr_count[0] = 1;
                dp[0] = 0;
            }
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    b_arr_count[i] = b_arr_count[i - 1];
                    dp[i] = Math.Min(dp[i - 1] + 1, b_arr_count[i]);
                }
                else
                {
                    dp[i] = dp[i - 1];
                    b_arr_count[i] = b_arr_count[i - 1] + 1;
                }
            }
            var result = dp[dp.Length - 1];

            return result;
        }
        //public bool AreSentencesSimilar(string sentence1, string sentence2)
        //{
        //    var arr1 = sentence1.Split(" ");
        //    var arr2 = sentence2.Split(" ");

        //    if (arr1.Length>arr2.Length)
        //    {
        //        sentence1.Split(sentence2);
        //    }
        //    return false;
        //}
        /// <summary>
        /// 1813. 句子相似性 III
        /// </summary>
        /// <param name="sentence1"></param>
        /// <param name="sentence2"></param>
        /// <returns></returns>
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {

            var arr1 = sentence1.Split(" ");
            var arr2 = sentence2.Split(" ");

            int[] arr1Res = new int[arr1.Length];
            int[] arr2Res = new int[arr2.Length];

            int j = 0;
            if (arr1.Length > arr2.Length)
            {
                if (arr2.Length == 1 && arr1[0] == arr2[0] || arr2.Length == 1 && arr1[arr1.Length - 1] == arr2[0])
                {
                    return true;
                }
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (j < arr2.Length)
                    {

                        if (arr1[i] == arr2[j])
                        {
                            arr1Res[i] = 1;
                            arr2Res[j] = 1;
                            j++;
                        }
                    }
                }
            }
            else
            {
                if (arr1.Length == 1 && arr2[0] == arr1[0] || (arr1.Length == 1 && arr2[arr2.Length - 1] == arr1[0]))
                {
                    return true;
                }
                for (int i = 0; i < arr2.Length; i++)
                {
                    if (j < arr1.Length)
                    {


                        if (arr2[i] == arr1[j])
                        {
                            arr1Res[j] = 1;
                            arr2Res[i] = 1;
                            j++;
                        }
                    }
                }

            }
            Stack<int> stack = new Stack<int>();
            if (arr1.Length > arr2.Length)
            {
                for (int i = 0; i < arr2Res.Length; i++)
                {
                    if (arr2Res[i] == 0)
                    {
                        return false;
                    }
                }

                for (int i = 0; i < arr1Res.Length; i++)
                {

                    if (stack.Count == 0)
                    {
                        stack.Push(arr1Res[i]);
                    }
                    else
                    {
                        if (stack.Peek() == arr1Res[i])
                        {
                            continue;
                        }
                        else
                        {
                            stack.Push(arr1Res[i]);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr1Res.Length; i++)
                {
                    if (arr1Res[i] == 0)
                    {
                        return false;
                    }
                }

                for (int i = 0; i < arr2Res.Length; i++)
                {

                    if (stack.Count == 0)
                    {
                        stack.Push(arr2Res[i]);
                    }
                    else
                    {
                        if (stack.Peek() == arr2Res[i])
                        {
                            continue;
                        }
                        else
                        {
                            stack.Push(arr2Res[i]);
                        }
                    }
                }
            }
            int zeroCount = 0;
            int oneCount = 0;
            while (stack.Count > 0)
            {
                if (stack.Pop() == 0)
                {
                    zeroCount++;
                }
                else
                {
                    oneCount++;
                }
            }
            return zeroCount <= 1 && oneCount > 0;
        }
        /// <summary>
        /// 1807. 替换字符串中的括号内容
        /// </summary>
        /// <param name="s"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public string Evaluate1(string s, IList<IList<string>> knowledge)
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < knowledge.Count(); i++)
            {
                var kvp = knowledge[i];
                dict.Add("(" + kvp[0] + ")", kvp[1]);
            }
            string value = "";
            bool isStart = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') // 开始记录里面的内容
                {
                    isStart = true;
                    value = "";
                }

                if (isStart)
                {
                    value += s[i];
                }

                if (s[i] == ')') // 结束记录里面的内容
                {
                    isStart = false;
                    if (value != "")
                    {

                        if (dict.ContainsKey(value))
                        {
                            s = s.Replace(value, dict[value]);
                            i = i - (value.Length - dict[value].Length);
                        }
                        else
                        {
                            s = s.Replace(value, "?");
                            i = i - (value.Length - 1);
                        }
                    }
                    value = "";

                }
            }
            return s;
        }
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < knowledge.Count(); i++)
            {
                var kvp = knowledge[i];
                dict.Add(kvp[0], kvp[1]);
            }


            var arr = s.Split(")");
            if (arr.Length <= 0)
            {
                return s;
            }
            var finStr = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "")
                {
                    continue;
                }
                var res = arr[i].Split("(");
                if (res.Length == 2)
                {
                    string value = "";
                    if (dict.ContainsKey(res[1]))
                    {
                        value = res[0] + dict[res[1]];
                    }
                    else
                    {
                        value = res[0] + "?";
                    }
                    finStr += value;
                }
                else
                {
                    finStr += res[0];
                }

            }



            return finStr;
        }
        /// <summary>
        /// 2032. 至少在两个数组中出现的值
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="nums3"></param>
        /// <returns></returns>
        public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {

            HashSet<int> result = new HashSet<int>();
            HashSet<int> set1 = new HashSet<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                set1.Add(nums1[i]);
            }
            HashSet<int> set2 = new HashSet<int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                set2.Add(nums2[i]);
            }
            HashSet<int> set3 = new HashSet<int>();
            for (int i = 0; i < nums3.Length; i++)
            {
                set3.Add(nums3[i]);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                if (set2.Contains(nums1[i]) || set3.Contains(nums1[i]))
                {
                    result.Add(nums1[i]);
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (set1.Contains(nums2[i]) || set3.Contains(nums2[i]))
                {
                    result.Add(nums2[i]);
                }
            }
            for (int i = 0; i < nums3.Length; i++)
            {
                if (set2.Contains(nums3[i]) || set1.Contains(nums3[i]))
                {
                    result.Add(nums3[i]);
                }
            }

            return result.ToList();
        }
        /// <summary>
        /// 791. 自定义字符串排序
        /// </summary>
        /// <param name="order"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public string CustomSortString(string order, string s)
        {
            // order = kqep
            // s =     pekeq;

            // k q ee p
            var arr = s.ToCharArray();
            int startIndex = 0;//从第0个位置开始
            int offset = 0;
            for (int i = 0; i < order.Length; i++)
            {
                var item = order[i];
                while (startIndex < arr.Length)
                {
                    if (arr[startIndex] == item)
                    {
                        var temp = arr[offset];
                        arr[offset] = arr[startIndex];
                        arr[startIndex] = temp;
                        offset++;
                    }
                    startIndex++;
                }
                startIndex = offset;// 还原
            }

            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += string.Format("{0}", arr[i]);
            }
            return str;
        }
        /// <summary>
        /// 1684. 统计一致字符串的数目
        /// </summary>
        /// <param name="allowed"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int CountConsistentStrings(string allowed, string[] words)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < allowed.Length; i++)
            {
                set.Add(allowed[i]);
            }
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                for (int j = 0; j < word.Length; j++)
                {
                    if (!set.Contains(word[j]))
                    {
                        count--;
                        break;
                    }
                }
                count++;
            }
            return count;
        }
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return false;
        }

        public int ScoreOfParentheses(string s)
        {
            //"(()(()))" 6
            Stack<char> stack = new Stack<char>();
            int score = 0;
            int ratio = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Peek() != s[i]) // 括回了
                    {
                        //"()"    1分
                        // AB     A+B 分
                        // (A)    2*A 分
                        // score += 1;
                        stack.Pop();
                        continue;
                    }
                    else
                    {
                        stack.Push(s[i]);
                        //  ratio += 1;
                    }
                }
            }
            return 0;

        }
        /// <summary>
        /// 870. 优势洗牌
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 1)
            {
                return nums1;
            }                 //       [24,32,33,13]
                              // 输入：nums1 = , nums2 = [13,25,32,11]

            // 输入: nums1 = [2,7,11,15], nums2 = [1,10,4,11]
            // 输出：[2,11,7,15]
            // 动态规划五部曲 声明数组，确定递推公式。
            int[][] dp = new int[nums1.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[2];
            }
            dp[0][0] = nums1[0];
            if (nums1[0] > nums2[0])
            {
                dp[0][1] = 1;
            }
            else
            {
                dp[0][1] = 0;
            }
            int index = 0;
            for (int i = 1; i < nums1.Length; i++)
            {

            }

            return null;
        }
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            var sum = nums.Sum();
            if (sum % k != 0)
            {
                // 表示不可能平均分成k份
                return false;
            }
            // 表示有可能分成k份
            // 每份 的均值是 val 
            var val = sum / k;
            int[] bitArr = new int[nums.Length];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (bitArr[i] != 0)
                {
                    continue;
                }
                int item = nums[i];
                if (item > val) // 都比均值大了 肯定不行啊
                {
                    return false;
                }
                var diffVal = val - item;// 差值 
                int index = i + 1;
                while (diffVal > 0)
                {

                    while (index < nums.Length)
                    {
                        if ((diffVal - nums[index]) > 0 && bitArr[index] == 0)
                        {
                            diffVal -= nums[index];
                            bitArr[index] = 1;
                            bitArr[i] = 1;

                        }
                        index++;
                    }
                    bitArr[i] = 1;
                    index = i;
                }


            }
            for (int i = 0; i < bitArr.Length; i++)
            {
                if (bitArr[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 1636. 按照频率将数组升序排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FrequencySort(int[] nums)
        {
            // [1,1,2,2,2,3]
            // [3,1,1,2,2,2]
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            var list = dict.OrderBy(c => c.Value).ThenByDescending(c => c.Key);
            int index = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key},{item.Value}");

                int subIndex = 0;
                while (subIndex < item.Value)
                {
                    nums[index + subIndex] = item.Key;
                    subIndex++;
                }
                index = subIndex + index;

            }

            return nums;
        }
        /// <summary>
        /// 1619. 删除某些元素后的数组均值
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double TrimMean(int[] arr)
        {
            Array.Sort(arr);
            int sum = 0;
            for (int i = (arr.Length / 20); i < 19 * arr.Length / 20; i++)
            {
                sum += arr[i];
            }
            return sum / (arr.Length * 0.9f);
        }
        /// <summary>
        /// 670. 最大交换
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaximumSwap(int num)
        {
            string str = num.ToString();
            char[] arr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }

            int index = 0;

            while (index < arr.Length)
            {
                int maxValue = 0;
                int maxIndex = 0;
                for (int i = index; i < arr.Length; i++)
                {
                    if (arr[i] >= maxValue)
                    {
                        maxIndex = i;
                        maxValue = arr[i];
                    }

                }
                if (maxIndex > index)
                {
                    if (arr[index] != arr[maxIndex])
                    {
                        char temp = arr[index];
                        arr[index] = arr[maxIndex];
                        arr[maxIndex] = temp;
                        var result = int.Parse(arr);
                        return result;
                    }

                }
                index++;
            }
            return num;
        }

        /// <summary>
        /// 652. 寻找重复的子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            IList<TreeNode> result = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<List<TreeNode>> resultList = new List<List<TreeNode>>();
            ForeachTree(stack, root, resultList);
            Dictionary<int, List<TreeNode>> dict = new Dictionary<int, List<TreeNode>>();
            foreach (List<TreeNode> list in resultList)
            {
                if (!dict.ContainsKey(list[0].val))
                {
                    dict.Add(list[0].val, list);
                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var oldList = dict[list[0].val];
                        if (oldList[i].val == list[i].val)
                        {
                            result.Add(list[i]);
                        }
                        else
                        {
                            return result;
                        }
                    }
                }
            }
            return result;
        }
        public void ForeachTree(Stack<TreeNode> stack, TreeNode root, List<List<TreeNode>> resultList)
        {
            if (root == null)
            {
                return;
            }
            stack.Push(root);
            if (root.left == null && root.right == null)
            {
                Console.WriteLine("打印树：" + string.Join(',', stack.ToList<TreeNode>().Select(c => c.val).Reverse().ToList()));
                var list = stack.ToList<TreeNode>().ToList();
                resultList.Add(list);

            }
            ForeachTree(stack, stack.Peek().left, resultList);
            ForeachTree(stack, stack.Peek().right, resultList);
            stack.Pop();
        }
        /// <summary>
        /// 1475. 商品折扣后的最终价格
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int[] FinalPrices(int[] prices)
        {
            for (int i = 0; i < prices.Length - 1; i++)
            {

                int j = i + 1;
                while (j < prices.Length)
                {
                    if (prices[j] <= prices[i])
                    {
                        prices[i] = prices[i] - prices[j];
                        break;
                    }
                    j++;
                }

            }
            return prices;
        }

        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            //pushed = [1,2,3,4,5], popped = [4,3,5,1,2]
            Stack<int> stack = new Stack<int>();
            int index = 0;
            for (int i = 0; i < pushed.Length; i++)
            {
                var item = pushed[i];
                stack.Push(item);

                while (stack.Count > 0 && stack.Peek() == popped[index])
                {
                    index++;
                    stack.Pop();
                }

            }
            return stack.Count == 0;
        }
        public int DeepestLeavesSum(TreeNode root)
        {
            Queue<KeyValuePair<int, TreeNode>> queue = new Queue<KeyValuePair<int, TreeNode>>();
            queue.Enqueue(new KeyValuePair<int, TreeNode>(1, root));
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            while (queue.Count > 0)
            {
                var kvp = queue.Dequeue();
                var level = kvp.Key;
                var node = kvp.Value;
                if (dict.ContainsKey(level))
                {
                    dict[level].Add(node.val);
                }
                else
                {
                    dict.Add(level, new List<int> { node.val });
                }
                if (node.left != null)
                {
                    queue.Enqueue(new KeyValuePair<int, TreeNode>(level + 1, node.left));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new KeyValuePair<int, TreeNode>(level + 1, node.right));
                }
            }
            int maxLevel = -1;
            foreach (var item in dict)
            {
                if (item.Key > maxLevel)
                {
                    maxLevel = item.Key;
                }
            }
            var value = dict[maxLevel].Sum();
            return 0;
        }
        public string GenerateTheString(int n)
        {
            string str = "";
            if (n % 2 == 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    str += "a";
                }
                str += "b";
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    str += "a";
                }
            }
            return str;
        }
        public class MyCircularQueue
        {

            int front;//队首元素对应的索引
            int rear; //队尾元素对应的索引
            int capacity; // 容量
            int[] elements;
            public MyCircularQueue(int k)
            {
                capacity = k + 1;
                elements = new int[capacity];
                rear = front = 0;
            }

            public bool EnQueue(int value)
            {
                if (IsFull())
                {
                    return false;
                }
                elements[rear] = value;
                rear = (rear + 1) % capacity;
                return true;
            }

            public bool DeQueue()
            {
                if (IsEmpty())
                {
                    return false;
                }

                front = (front + 1) % capacity;
                return true;
            }

            public int Front()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                return elements[front];
            }

            public int Rear()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                return elements[(rear - 1 + capacity) % capacity];
            }

            public bool IsEmpty()
            {
                return rear == front;
            }

            public bool IsFull()
            {
                return ((rear + 1) % capacity) == front;
            }
        }
        public class CBTInserter
        {

            TreeNode _root;
            public CBTInserter(TreeNode root)
            {
                _root = root;
            }

            public int Insert(int val)
            {
                if (_root == null)
                {
                    _root.left = new TreeNode(val);
                }
                if (_root != null && _root.left != null && _root.left.left == null && _root.left.right == null)
                {
                    _root.right = new TreeNode(val);
                }

                return 0;
            }

            public TreeNode Get_root()
            {
                return null;
            }
        }
        public void TestMyCalendarTwo()
        {
            MyCalendarTwo two = new MyCalendarTwo();
            Console.WriteLine(two.Book(10, 20));
            Console.WriteLine(two.Book(50, 60));
            Console.WriteLine(two.Book(10, 40));
            Console.WriteLine(two.Book(5, 15));
            Console.WriteLine(two.Book(5, 10));
            Console.WriteLine(two.Book(25, 55));
        }
        public class MyCalendarTwo
        {
            int[][] intersectArr = new int[1000][];
            int[][] result = new int[1000][];
            public MyCalendarTwo()
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = new int[] { -1, -1 };
                    intersectArr[i] = new int[] { -1, -1 };
                }
            }

            public bool Book(int start, int end)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    int oldStart = result[i][0];
                    int oldEnd = result[i][1];
                    if (oldStart != -1)// 
                    {
                        if (start >= oldEnd || end < oldStart) // 不相交
                        {

                        }
                        else // 有相交
                        {
                            for (int j = 0; j < intersectArr.Length; j++)
                            {
                                if (intersectArr[j][0] != -1)
                                {
                                    if (start >= intersectArr[j][1] || end < intersectArr[j][0])
                                    {

                                    }
                                    else
                                    {

                                        return false;
                                    }
                                }
                                else
                                {
                                    int[] arr = new int[4];
                                    arr[0] = start;
                                    arr[1] = oldEnd;
                                    arr[2] = end;
                                    arr[3] = oldStart;
                                    Array.Sort(arr);

                                    intersectArr[j][0] = Math.Max(start, oldStart);
                                    intersectArr[j][1] = Math.Min(end, oldEnd);
                                    break;
                                }
                            }
                            //  return false;
                        }
                    }
                    else
                    {
                        result[i][0] = start;
                        result[i][1] = end;
                        break;
                    }
                }

                return true;
            }
        }

        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);
            if (root.left == null && root.right == null && root.val == 0)
            {
                return null;
            }
            return root;
        }

        public bool Check(int[] nums)
        {
            // A[i] == B[(i + x) % A.length]

            int n = nums.Length;
            bool isCount = nums[0] >= nums[n - 1];  // 第一个数 不小于最后一个
            for (int i = 1; i < n; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    if (isCount)
                    {
                        isCount = false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 735. 行星碰撞
        /// </summary>
        /// <param name="asteroids"></param>
        /// <returns></returns>
        public int[] AsteroidCollision(int[] asteroids)
        {
            // 5, -5, 12, 11, -1, -22, 30, 123, 43, -90 
            // [-22,30,123]
            Stack<int> stack = new Stack<int>();
            stack.Push(asteroids[0]);
            int i = 1;

            while (i < asteroids.Length)
            {

                while (stack.Count > 0 && (asteroids[i] > 0 && stack.Peek() < 0 || stack.Peek() > 0 && asteroids[i] < 0)) // 栈里面有值，并且 栈顶的数和新的数移动方向相反
                {
                    if (stack.Peek() > 0 && asteroids[i] < 0)
                    {


                        // 栈顶的数的绝对值 比当前的数的绝对值大
                        if (MathF.Abs(stack.Peek()) > MathF.Abs(asteroids[i]))
                        {

                            // 不用动，直接进行下一个
                            i++;
                        }
                        else if (MathF.Abs(stack.Peek()) == MathF.Abs(asteroids[i]))
                        {
                            // 两个数相等
                            stack.Pop();
                            i++;
                        }
                        else
                        {
                            // 栈顶的数比当前的数小
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(asteroids[i]);
                        i++;

                    }
                    if (i >= asteroids.Length)
                    {
                        break;
                    }
                }
                if (i >= asteroids.Length)
                {
                    break;
                }
                stack.Push(asteroids[i]);
                i++;
            }
            return stack.Reverse().ToArray();
        }
        /// <summary>
        /// 1252. 奇数值单元格的数目
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public int OddCells(int m, int n, int[][] indices)
        {

            return 0;
        }

        public void TestMagicDictionary()
        {
            MagicDictionary magic = new MagicDictionary();
            magic.BuildDict(new string[] { "hello", "hallo", "leetcode" });
            Console.WriteLine(magic.Search("hello"));
            Console.WriteLine(magic.Search("hhllo"));
            Console.WriteLine(magic.Search("hell"));
            Console.WriteLine(magic.Search("leetcoded"));
        }
        /// <summary>
        /// 676. 实现一个魔法字典
        /// </summary>
        public class MagicDictionary
        {
            List<string> list = new List<string>();
            public MagicDictionary()
            {

            }

            public void BuildDict(string[] dictionary)
            {
                list.AddRange(dictionary);
            }

            public bool Search(string searchWord)
            {
                foreach (var item in list)
                {
                    if (item.Length == searchWord.Length)
                    {
                        int count = 0;
                        for (int i = 0; i < item.Length; i++)
                        {
                            if (searchWord[i] != item[i])
                            {
                                count++;
                            }
                        }
                        if (count == 1)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                        //  return count == 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// 1217. 玩筹码
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int MinCostToMoveChips(int[] position)
        {
            int jiCount = 0;
            int oCount = 0;
            // 思路，计算所有奇数，的数量，和所有偶数的数量， 返回最小的
            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] % 2 == 0)
                {
                    oCount++;
                }
                else
                {
                    jiCount++;
                }
            }
            return jiCount > oCount ? oCount : jiCount;//       (jiCount, oCount);
        }

        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var item in dictionary)
            {
                set.Add(item);
            }

            var arr = sentence.Split(' ');
            string[] result_arr = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    var str = arr[i].Substring(0, j + 1);

                    if (set.Contains(str))
                    {
                        result_arr[i] = str;
                        break;
                    }
                    if (j == arr[i].Length - 1)
                    {
                        result_arr[i] = arr[i];
                    }
                }

            }
            var result = string.Join(" ", result_arr);
            return result;
        }
        public int NextGreaterElement(int n)
        {
            int aa = int.MaxValue;
            string str = n.ToString();
            int maxValue = str[0] - 48;
            int maxIndex = 0;
            int[] arr = new int[str.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = str[i] - 48;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (maxValue <= arr[i])
                {
                    maxValue = arr[i];
                    maxIndex = i;
                }
            }
            if (maxIndex == 0)
            {
                return -1;
            }
            int index = arr.Length - 1;
            while (maxValue == arr[index] && index > 0)
            {
                index--;
            }
            if (index == 0 && maxValue == arr[0])
            {
                return -1;
            }
            int temp = arr[index];
            arr[index] = maxValue;
            arr[maxIndex] = temp;

            if (int.TryParse(string.Join("", arr), out int result))
            {
                return result;
            }
            return -1;
        }
        /// <summary>
        /// 729我的日程安排表 I
        /// </summary>
        public class MyCalendar
        {
            int[][] result = new int[1000][];
            public MyCalendar()
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = new int[] { -1, -1 };
                }
            }

            public bool Book(int start, int end)
            {
                // 10,20
                // 15,25
                // 20,30
                for (int i = 0; i < result.Length; i++)
                {
                    int oldStart = result[i][0];
                    int oldEnd = result[i][1];
                    if (oldStart != -1)
                    {
                        if (start >= oldEnd || end < oldStart)
                        {

                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        result[i][0] = start;
                        result[i][1] = end;
                        break;
                    }
                }

                return true;
            }
        }
        public void TestMyCalendar()
        {
            MyCalendar myCalendar = new MyCalendar();
            Console.WriteLine(myCalendar.Book(10, 20));
            Console.WriteLine(myCalendar.Book(9, 21));
            Console.WriteLine(myCalendar.Book(20, 30));
        }
        /// <summary>
        /// 1200. 最小绝对差
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);
            int[] result_arr = new int[arr.Length - 1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                result_arr[i] = (Math.Abs(arr[i] - arr[i + 1]));
            }
            int minValue = result_arr[0];

            for (int i = 0; i < result_arr.Length; i++)
            {
                if (result_arr[i] < minValue)
                {
                    minValue = result_arr[i];

                }
            }
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < result_arr.Length; i++)
            {
                if (result_arr[i] == minValue)
                {
                    result.Add(new int[2] { arr[i], arr[i + 1] });
                }
            }
            return result;
        }
        public IList<int> LargestValues(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null)
            {
                return list;
            }

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 1));
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                var temp_treeNode = item.Key;

                if (dict.ContainsKey(item.Value))
                {
                    dict[item.Value].Add(item.Key.val);
                }
                else
                {
                    dict.Add(item.Value, new List<int> { item.Key.val });
                }
                if (temp_treeNode.left != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(temp_treeNode.left, item.Value + 1));
                }
                if (temp_treeNode.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(temp_treeNode.right, item.Value + 1));
                }
            }
            foreach (var item in dict)
            {
                list.Add(item.Value.Max());
            }
            return list;
        }
        /// <summary>
        /// 215. 数组中的第K个最大元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            int index = 0;


            while (k > index)
            {
                int max = nums[0];
                int maxIndex = 0;
                for (int i = 0; i < nums.Length - index; i++)
                {
                    if (nums[i] > max)
                    {
                        max = nums[i];
                        maxIndex = i;
                    }
                }
                int temp = nums[nums.Length - index - 1];//最后一个数
                nums[nums.Length - index - 1] = nums[maxIndex];
                nums[maxIndex] = temp;
                index++;
            }
            return nums[nums.Length - k];
        }

        /// <summary>
        /// 1037. 有效的回旋镖
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool IsBoomerang(int[][] points)
        {
            //points = [[1,1],[2,3],[3,2]]
            // 直线定义 y= kx+b;
            // k 斜率 = (points[0][0]-points[1][0])/(points[0][1]-points[1][1])

            int x1 = points[0][0], y1 = points[0][1];
            int x2 = points[1][0], y2 = points[1][1];
            int x3 = points[2][0], y3 = points[2][1];
            return (y2 - y1) * (x3 - x2) != (y3 - y2) * (x2 - x1);
        }
        int res = 0;
        /// <summary>
        /// 1022. 从根到叶的二进制数之和
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumRootToLeaf(TreeNode root)
        {
            DFS(root, 0);
            return res;
        }
        void DFS(TreeNode root, int preSum)
        {
            if (root == null)
            {
                return;
            }
            preSum = preSum * 2 + root.val;
            if (root.left == null && root.right == null)
            {
                res += preSum;
            }
            DFS(root.left, preSum);
            DFS(root.right, preSum);
        }
        /// <summary>
        /// 剑指 Offer II 045. 二叉树最底层最左边的值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return 0;
            }
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            KeyValuePair<TreeNode, int> keyValuePair = new KeyValuePair<TreeNode, int>(root, 1);
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            queue.Enqueue(keyValuePair);
            //  dict.Add(1, new List<int> { root.val });
            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                var temp_tree = temp.Key;
                var level = temp.Value;
                Console.WriteLine("value=" + temp_tree.val + ",level=" + level);
                if (dict.ContainsKey(level))
                {
                    dict[level].Add(temp_tree.val);
                }
                else
                {
                    dict.Add(level, new List<int> { temp_tree.val });
                }
                if (temp_tree.left != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(temp_tree.left, level + 1));
                }
                if (temp_tree.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(temp_tree.right, level + 1));
                }
            }
            foreach (var item in dict)
            {
                result.Add(item.Value);
            }
            return result[result.Count - 1][0];

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int FindClosest(string[] words, string word1, string word2)
        {
            if (words.Length <= 0)
            {
                return 0;
            }
            int index1 = -1;
            int index2 = -1;
            int min = words.Length;
            int[] table = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                {
                    table[i] = 1;
                    index1 = i;
                }
                else if (words[i] == word2)
                {
                    table[i] = -1;
                    index2 = i;
                }
                else
                {
                    table[i] = 0;
                }

            }
            int curr_value = 0;
            int curr_index = 0;
            int min_value = int.MaxValue;

            // List<int> result = new List<int>();
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != 0)
                {
                    if (curr_value + table[i] == 0)// 证明碰见了异性了
                    {
                        var val = i - curr_index;
                        if (val == 1)
                        {
                            return 1;
                        }
                        if (val < min_value)
                        {
                            min_value = val;
                        }
                    }
                    else // 证明同性
                    {
                        curr_value = table[i];
                    }
                    curr_value = table[i];
                    curr_index = i;
                }
            }
            return min_value;
        }
        /// <summary>
        /// 699. 掉落的方块
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public IList<int> FallingSquares(int[][] positions)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                var item = positions[i];
                //item[0] 等于左边界
                //item[1] 边长
            }
            return null;
        }
        /// <summary>
        /// 28 实现 strStr()
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (haystack == needle)
            {
                return 0;
            }
            int leftIndex = 0;
            int hayIndex = 0;
            int needIndex = 0;
            if (needle.Length <= 0)
            {
                return 0;
            }
            while (leftIndex <= haystack.Length - needle.Length)
            {
                hayIndex = leftIndex;
                while (haystack[hayIndex] == needle[needIndex])
                {
                    hayIndex++;
                    needIndex++;
                    if (needIndex >= needle.Length)
                    {
                        return leftIndex;
                    }
                }
                leftIndex++;
                needIndex = 0;

            }
            return -1;
        }
        public Node1 Connect(Node1 root)
        {

            if (root == null)
            {
                return null;
            }
            Queue<KeyValuePair<Node1, int>> queue = new Queue<KeyValuePair<Node1, int>>();
            KeyValuePair<Node1, int> keyValuePair = new KeyValuePair<Node1, int>(root, 1);
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            queue.Enqueue(keyValuePair);
            //  dict.Add(1, new List<int> { root.val });
            KeyValuePair<Node1, int> preKVP = keyValuePair;
            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                if (temp.Value != 1)
                {
                    if (temp.Value == preKVP.Value)
                    {
                        preKVP.Key.next = temp.Key;
                    }
                    preKVP = temp;
                }
                var temp_tree = temp.Key;
                var level = temp.Value;
                Console.WriteLine("value=" + temp_tree.val + ",level=" + level);
                if (dict.ContainsKey(level))
                {
                    dict[level].Add(temp_tree.val);
                }
                else
                {
                    dict.Add(level, new List<int> { temp_tree.val });
                }
                if (temp_tree.left != null)
                {
                    queue.Enqueue(new KeyValuePair<Node1, int>(temp_tree.left, level + 1));
                }
                if (temp_tree.right != null)
                {
                    queue.Enqueue(new KeyValuePair<Node1, int>(temp_tree.right, level + 1));
                }
            }

            // return result;

            return root;
        }
        /// <summary>
        /// 广度优先搜索BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {

            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return null;
            }
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            KeyValuePair<TreeNode, int> keyValuePair = new KeyValuePair<TreeNode, int>(root, 1);
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            queue.Enqueue(keyValuePair);
            //  dict.Add(1, new List<int> { root.val });
            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                var temp_tree = temp.Key;
                var level = temp.Value;
                Console.WriteLine("value=" + temp_tree.val + ",level=" + level);
                if (dict.ContainsKey(level))
                {
                    dict[level].Add(temp_tree.val);
                }
                else
                {
                    dict.Add(level, new List<int> { temp_tree.val });
                }
                if (temp_tree.left != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(temp_tree.left, level + 1));
                }
                if (temp_tree.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(temp_tree.right, level + 1));
                }
            }
            foreach (var item in dict)
            {
                result.Add(item.Value);
            }
            return result;
        }
        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            if (root.left != null)
            {
                if (root.val != root.left.val || !IsUnivalTree(root.left))
                {
                    return false;
                }
            }
            if (root.right != null)
            {
                if (root.val != root.right.val || !IsUnivalTree(root.right))
                {
                    return false;
                }
            }
            return true;
            ;
        }
        public int MinMoves2(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return 0;
            }
            if (nums.Length == 2)
            {
                return Math.Abs(nums[0] - nums[1]);
            }

            var targetValue = nums[2];
            int index = 2;
            while (targetValue == 0 && index < nums.Length)
            {
                targetValue = nums[index];
                index++;
            }
            var max = MathF.Max(nums[0], nums[1]);
            var min = MathF.Min(nums[0], nums[1]);
            if (targetValue > min && targetValue < max)
            {

            }
            if (targetValue < min)
            {
                targetValue = (int)min;
            }
            if (targetValue > max)
            {
                targetValue = (int)max;
            }

            var count = Math.Abs(nums[0] - nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                count += (int)MathF.Abs(nums[i] - targetValue);
            }
            return count;
        }
        /// <summary>
        /// 462. 最少移动次数使数组元素相等 II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMoves21(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return 0;
            }
            int[] infos_arr = new int[2];

            int[][] dp = new int[nums.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[2];
            }
            dp[1][0] = 0;// 表示 nums的长度是1 的时候， index=0，表示需要移动的次数
            dp[1][1] = nums[0];// index=1 表示目标值

            //    var targetValue = (int)Math.Ceiling((nums[0] + nums[1]) / 2.0);


            //dp[2][0] = Math.Abs(nums[0] - targetValue) + Math.Abs(nums[1] - targetValue);
            //dp[2][1] = (nums[0] + nums[1]) / 2; ;


            for (int i = 1; i < nums.Length; i++)
            {
                int mid = (int)Math.Ceiling((dp[i][1] + nums[i]) / 2.0);
                int a = (int)Math.Abs(dp[i][1] - mid) * i + (int)MathF.Abs(mid - nums[i]);
                int b = Math.Abs(dp[i][1] - nums[i]);
                dp[i + 1][0] = dp[i][0] + Math.Min(a, b);
                dp[i + 1][1] = a > b ? dp[i][1] : mid;
            }
            return dp[nums.Length][0];
        }

        public string Trans(int num)
        {
            string[] strArr = new string[] { "", "十", "百", "千", "万" };
            string[] numStrArr = new string[] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            string str = num.ToString();
            int index = str.Length - 1;
            string result = "";
            while (index >= 0)
            {
                int curNum = str[str.Length - index - 1] - 48;
                var numStr = numStrArr[curNum];
                if (curNum == 0)
                {
                    result += numStr;
                }
                else
                {
                    result += (numStr + strArr[index]);
                }
                index--;
            }
            //while (result.EndsWith("零"))
            //{
            //    if (result.Length==1)
            //    {
            //        return result;
            //    }
            //    result = result.Substring(0, result.Length - 2);
            //}
            return result;
        }
        /// <summary>
        /// 面试题 04.06. 后继者
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            TreeNode result_treeNode = p;

            Inorder(root, p);
            return null;
        }
        static bool flag = false;
        private void Inorder(TreeNode root, TreeNode p)
        {

            if (root == null)
            {

            }
            Inorder(root.left, p);
            if (!flag)
            {
                if (root.val == p.val)
                {
                    flag = true;
                }
            }
            else
            {

            }

            Inorder(root.right, p);

        }

        /// <summary>
        /// 面试题 01.05. 一次编辑
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool OneEditAway(string first, string second)
        {
            var len = Math.Abs(first.Length - second.Length);

            if (len > 1)
            {
                return false;
            }
            int num = 0;
            if (len == 0)// 一样长
            {

                for (int i = 0; i < first.Length; i++)
                {
                    char c = first[i];
                    char c_1 = second[i];
                    if (c != c_1)
                    {
                        num++;
                        if (num > 1)
                        {
                            return false;
                        }
                    }
                }
                return num <= 1;
            }

            string long_str = "";
            string short_str = "";

            if (first.Length > second.Length)
            {
                long_str = first;
                short_str = second;
            }
            else
            {
                long_str = second;
                short_str = first;
            }

            int long_index = 0;
            int short_index = 0;


            while (num <= 1 && short_index < short_str.Length)
            {
                char c = long_str[long_index];
                char c_1 = short_str[short_index];
                if (c != c_1)
                {
                    num++;
                    long_index++;
                    continue;
                }
                long_index++;
                short_index++;
                if (num > 1)
                {
                    return false;
                }
            }

            return num <= 1;
        }
        /// <summary>
        /// 942. 增减字符串匹配
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] DiStringMatch(string s)
        {

            int[] arr = new int[s.Length + 1];

            for (int i = 0; i <= s.Length; i++)
            {
                arr[i] = i;
            }

            int lowIndex = 0;
            int fastIndex = arr.Length - 1;
            int[] result = new int[s.Length + 1];
            int index = 0;
            while (lowIndex < fastIndex)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'D')
                    {
                        result[index] = arr[fastIndex];
                        fastIndex--;

                    }
                    else
                    {
                        result[index] = arr[lowIndex];
                        lowIndex++;

                    }
                    index++;
                }
            }
            result[result.Length - 1] = arr[lowIndex];
            return result;
        }
        /// <summary>
        /// 442. 数组中重复的数据
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDuplicates(int[] nums)
        {
            //4,3,2,7,8,2,3,1
            //7,3,2,4,8,2,3,1
            //3,3,2,4,8,2,7,1
            //2,3,3,4,8,2,7,1
            //3,2,3,4,8,2,7,1

            //->3 往 索引=2 的位置放 发现 重复了  放到列表里面
            //3,2,3,4,1,2,7,8
            //1,2,3,4,3,2,7,8
            // 发现3已经填充过列表里面了  index++;到2了，发现索引1的位置刚好是2 发现重复了，放到结果列表里面

            HashSet<int> set = new HashSet<int>();
            int lowIndex = 0;
            int len = nums.Length;
            while (lowIndex < len)
            {

                while (nums[lowIndex] != lowIndex + 1)
                {
                    int temp = nums[nums[lowIndex] - 1];
                    if (temp == nums[lowIndex])
                    {

                        set.Add(temp);


                        //  lowIndex++;
                        break;
                    }
                    else
                    {
                        nums[nums[lowIndex] - 1] = nums[lowIndex];
                        nums[lowIndex] = temp;

                    }
                }
                lowIndex++;
            }
            int[] arrs = new int[set.Count];
            int index = 0;
            foreach (var item in set)
            {
                arrs[index] = item;
                index++;
            }


            return arrs;
        }
        /// <summary>
        /// 148.排序链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {

            // 4-2-1-3;
            //
            ListNode newHead;

            while (head != null)
            {
                if (head.next == null)
                {
                    continue;
                }
                if (head.val > head.next.val)
                {

                    ListNode tempNext = head.next;
                    head.next = head.next.next;
                    tempNext.next = head;
                    head = tempNext;
                }
                else
                {
                    newHead = head;
                    head = head.next;
                }
            }
            return head;
        }
        /// <summary>
        /// 350.两个数组的交集2
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> list = new List<int>();
            if (nums1.Length <= 0 || nums2.Length <= 0)
            {
                return list.ToArray();
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (dict.ContainsKey(nums1[i]))
                {
                    dict[nums1[i]]++;
                }
                else
                {
                    dict.Add(nums1[i], 1);
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (dict.ContainsKey(nums2[i]))
                {
                    if (dict[nums2[i]] > 0)
                    {
                        dict[nums2[i]]--;
                        list.Add(nums2[i]);
                    }
                    else
                    {
                        dict.Remove(nums2[i]);
                    }
                }
            }
            return list.ToArray();
        }
        /// <summary>
        /// 386. 字典序排数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> LexicalOrder(int n)
        {

            return null;
        }
        /// <summary>
        /// 6.Z字形变换
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert1(string s, int numRows)
        {
            var length = s.Length / 2 + 1;
            Console.WriteLine("length=" + length);

            string[][] result = new string[numRows][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new string[length];
            }
            int index = 0;
            int index_1 = 0;
            int cursor = 0;
            bool flag = false;
            while (index < numRows)
            {
                index++;
                if (index == numRows)
                {
                    if (index_1 <= s.Length)
                    {
                        index = 0;
                    }
                    flag = true;
                }
                if (index == 0)
                {
                    flag = false;
                }
                if (flag)
                {
                    cursor++;
                }
            }

            return null;
        }
        /// <summary>
        /// 796.旋转字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public bool RotateString(string s, string goal)
        {


            if (s.Length != goal.Length)
            {
                return false;
            }
            Stack<char> stack = new Stack<char>();
            int index = goal.Length - 1;
            int s_index = 0;
            while (index >= 0 && s_index <= s.Length - 1)
            {
                stack.Push(goal[index]);
                index--;
                while (stack.Count > 0 && stack.Peek() == s[s_index])
                {
                    stack.Pop();
                    s_index++;
                }
            }
            return stack.Count <= 0;
        }
        public int CountPrimeSetBits(int left, int right)
        {
            for (int i = left; i <= right; i++)
            {
                byte b = Convert.ToByte(i);
            }
            return 0;
        }
        /// <summary>
        /// 判定是否为质数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsNo(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        ///  图片模糊
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[][] ImageSmoother(int[][] img)
        {
            int m = img.Length;
            int n = img[0].Length;
            int[][] ret = new int[m][];
            for (int i = 0; i < img.Length; i++)
            {
                ret[i] = new int[n];
            }
            for (int i = 0; i < img.Length; i++)
            {
                for (int j = 0; j < img[i].Length; j++)
                {
                    int num = 0;
                    int sum = 0;
                    for (int x = i - 1; x <= i + 1; x++)
                    {
                        for (int y = j - 1; y <= j + 1; y++)
                        {
                            if (x >= 0 && y >= 0 && x < m && y < n)
                            {
                                num++;
                                sum += img[x][y];
                            }
                        }
                    }
                    ret[i][j] = sum / num;
                }
            }
            return ret;
        }
        /// <summary>
        /// 599.两个列表的最小索引总和
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            int[] result1 = new int[list2.Length];
            List<string> list = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < list1.Length; i++)
            {
                dict.Add(list1[i], i);
            }
            List<string> result = new List<string>();
            for (int i = 0; i < list2.Length; i++)
            {
                if (dict.ContainsKey(list2[i]))
                {
                    result1[i] = i + dict[list2[i]];
                    if (result1[i] == 0)
                    {
                        list.Add(list2[i]);
                        return list.ToArray();
                    }
                }
            }
            int minValue = int.MaxValue;

            for (int i = 0; i < result1.Length; i++)
            {
                if (result1[i] == 0)
                {
                    continue;
                }
                if (result1[i] < minValue)
                {
                    minValue = result1[i];
                }
            }
            for (int i = 0; i < result1.Length; i++)
            {
                if (minValue == result1[i])
                {
                    list.Add(list2[i]);
                }
            }
            return list.ToArray();
        }
        double rad, xc, yc;
        /// <summary>
        /// 478.在圆内随机生成点
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="x_center"></param>
        /// <param name="y_center"></param>
        public LeetCode(double radius, double x_center, double y_center)
        {
            rad = radius;
            xc = x_center;
            yc = y_center;
        }
        public LeetCode()
        {

        }
        public double[] RandPoint()
        {
            double x0 = xc - rad;
            double y0 = yc - rad;

            while (true)
            {
                //double xg = x0 + Math.Round() * rad * 2;
                //double
            }
        }
        /// <summary>
        /// N叉树的前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            // 根左右
            List<int> result = new List<int>();
            Preorder(root, result);
            return result;
        }
        public void Preorder(Node root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            result.Add(root.val);
            foreach (var item in root.children)
            {
                Preorder(item, result);
            }

        }
        /// <summary>
        /// 94.二叉树的中序遍历
        /// 为什么叫前序、后序、中序
        /// 根据 根说的，根在前 根左右 前序
        /// 根在中 左中右 中序
        /// 根在后 左右中 后序
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            // 左 中 右
            List<int> result = new List<int>();
            Inorder(root, result);
            return result;
        }
        public void Inorder(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left, result);
            result.Add(root.val);
            Inorder(root.right, result);
        }
        public int FindCenter(int[][] edges)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < edges.Length; i++)
            {
                var items = edges[i];
                if (!dict.ContainsKey(items[0]))
                {
                    dict.Add(items[0], 1);
                }
                else
                {
                    dict[items[0]]++;
                }
                if (!dict.ContainsKey(items[1]))
                {
                    dict.Add(items[1], 1);
                }
                else
                {
                    dict[items[1]]++;
                }
            }


            foreach (var item in dict)
            {
                if (item.Value == edges.Length - 1)
                {
                    return item.Key;
                }
            }
            return 0;
        }
        /// <summary>
        /// 1024.视频拼接
        /// 你将会获得一系列视频片段，这些片段来自于一项持续时长为 time 秒的体育赛事。这些片段可能有所重叠，也可能长度不一。

        ///  使用数组 clips 描述所有的视频片段，其中 clips[i] = [starti, endi] 表示：某个视频片段开始于 starti 并于 endi 结束。
        ///  甚至可以对这些片段自由地再剪辑：

        ///例如，片段[0, 7] 可以剪切成[0, 1] + [1, 3] + [3, 7] 三部分。
        ///我们需要将这些片段进行再剪辑，并将剪辑后的内容拼接成覆盖整个运动过程的片段（[0, time]）。
        ///返回所需片段的最小数目，如果无法完成该任务，则返回 -1 

        ///输入：clips = [[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]], time = 10
        ///输出：3
        ///解释：
        ///选中[0, 2], [8,10], [1,9] 这三个片段。
        ///然后，按下面的方案重制比赛片段：
        ///将[1, 9] 再剪辑为[1, 2] + [2,8] + [8,9] 。
        ///现在手上的片段为[0, 2] + [2,8] + [8,10]，而这些覆盖了整场比赛[0, 10]。
        /// 思路：动态规划，背包问题，而且是 01 背包，这个片段要么取 ，要么不取。
        /// 
        /// </summary>
        /// <param name="clips"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int VideoStitching(int[][] clips, int time)
        {
            // 状态转移方程
            // 当 次数 =i时，最小的片段数量
            int[] dp = new int[time + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue - 1;
            }
            dp[0] = 0;
            for (int i = 1; i <= time; i++)
            {
                foreach (int[] clip in clips)
                {
                    if (clip[0] < i && i <= clip[1])
                    {
                        dp[i] = Math.Min(dp[i], dp[clip[0]] + 1);
                    }
                }
            }
            return dp[time] == int.MaxValue - 1 ? -1 : dp[time];
        }
        /// <summary>
        /// 1380.矩阵中的幸运数字
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            List<int> res = new List<int>();
            // 遍历行
            for (int i = 0; i < matrix.Length; i++)
            {

                // 遍历列
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int[] arr = new int[matrix.Length];
                    if (IsLuckyUnmber(matrix, i, j, arr))
                    {
                        res.Add((matrix[i][j]));
                    }
                }
            }
            return res;
        }

        private bool IsLuckyUnmber(int[][] matrix, int i, int j, int[] arr)
        {

            for (int k = 0; k < matrix.Length; k++)
            {
                var col = matrix[k][j];
                arr[k] = col;
            }

            return IsMin(matrix[i], j) && IsMax(arr, i);
        }

        public bool IsMin(int[] arr, int index)
        {
            int min = arr[0];
            int minIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }

            return index == minIndex;
        }
        public bool IsMax(int[] arr, int index)
        {
            int max = arr[0];
            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }

            return index == maxIndex;
        }
        /// <summary>
        /// 1447.最简分数(用到了辗转相除法）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> SimplifiedFractions(int n)
        {
            HashSet<string> set = new HashSet<string>();
            IList<string> list = new List<string>();
            if (n == 0 || n == 1)
            {
                return list;
            }
            if (n == 2)
            {
                list.Add("1/2");
                return list;
            }

            // 分母
            for (int j = 1; j <= n; j++)
            {  // 分子
                for (int i = 1; i < j; i++)
                {
                    Console.WriteLine($"{i}/{j},{getMinValue(i, j)}");

                    var value = getMinValue(i, j);
                    if (!set.Contains(value))
                    {
                        set.Add(value);
                    }
                }
            }
            return set.ToArray();
        }
        public string getMinValue(int a, int b)
        {
            //6/4=1 yu 2
            //4/2=2 yu 0
            //至此，最大公约数为2
            // 返回 2/3


            int temp_a = a;
            int temp_b = b;
            while (temp_b % temp_a != 0)
            {
                var yushu = temp_b % temp_a;
                var shang = temp_b / temp_a;
                temp_b = temp_a;
                temp_a = yushu;
            }
            // Console.WriteLine("最大公约数="+ temp_a);
            if (temp_a == 1)
            {
                return a + "/" + b;
            }
            else
            {
                return (a / temp_a) + "/" + (b / temp_a);
            }

        }
        public int CountKDifference(int[] nums, int k)
        {

            int fastIndex = nums.Length - 1;
            int lowIndex = 0;
            int result = 0;
            while (lowIndex < fastIndex)
            {
                if (Math.Abs(nums[lowIndex] - nums[fastIndex]) == k)
                {
                    result++;
                }
                if (fastIndex > lowIndex)
                {
                    fastIndex--;
                    if (fastIndex <= lowIndex)
                    {
                        lowIndex++;
                        fastIndex = nums.Length - 1;
                    }
                }
                else
                {
                    lowIndex++;
                    fastIndex = nums.Length - 1;
                }
            }
            return result;
        }
        /// <summary>
        /// 643.子数组最大平均数1
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAverage(int[] nums, int k)
        {
            int[] preSum = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                preSum[i + 1] = preSum[i] + nums[i];
            }

            int max = int.MinValue;
            for (int i = k - 1; i < preSum.Length; i++)
            {
                // Math.Max();
            }
            return 0;
        }



        public int[] MaxSlidingWindow(int[] nums, int k)
        {

            return null;
        }
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            while (headA != null)
            {
                stack1.Push(headA.val);
                headA = headA.next;
            }
            while (headB != null)
            {
                stack2.Push(headA.val);
                headB = headB.next;
            }
            return null;

        }
        /// <summary>
        /// 59.螺旋矩阵II
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[n];
            }
            int x = 0;
            int y = 0;
            int z = 0;
            for (int i = 0; i < n * n; i++)
            {

                matrix[y][x] = i + 1;
                if (x < n - z - 1 && y == z)// 上边
                {
                    x++;
                }
                else if (y < n - z - 1 && x == n - z - 1)// 右边
                {
                    y++;
                }
                else if (y == n - z - 1 && x > z)// 下边
                {
                    x--;
                }
                else if (y > z + 1 && x == z)// 左边
                {
                    y--;
                }
                else
                {
                    z++;
                    x++;
                }
            }
            return matrix;
        }
        public int FindTargetSumWays(int[] nums, int target)
        {
            //dp[i][j] 表示：从数组 nums中 0-i的元素进行加减可以得到j的方法数量
            //dp[i][j] = dp[i-1][j-nums[i]]+dp[i-1][j+nums[i]]
            return 0;
        }
        /// <summary>
        /// 1049.最后一块石头的重量2
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int LastStoneWeightII(int[] stones)
        {
            //stones = [2,7,4,1,8,1]

            //w[i]=stones[i];// 物品的重量（体积）
            //v[i]=stones[i];// 物品的价值
            // dp[j] = max(dp[j],dp[j-w[i]]+v[i]);
            var sum = stones.Sum();
            var bagSize = sum / 2;
            int[] dp = new int[bagSize + 1];
            dp[0] = 0;

            for (int i = 0; i < stones.Length; i++)
            {
                for (int j = bagSize; j >= stones[i]; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - stones[i]] + stones[i]);
                }
            }
            return 0;
        }
        /// <summary>
        /// 416.分隔等和子集
        /// 给你一个 只包含正整数 的 非空 数组 nums 。请你判断是否可以将这个数组分割成两个子集，使得两个子集的元素和相等
        /// 输入：nums = [1,5,11,5]
        /// 输出：true
        /// 解释：数组可以分割成[1, 5, 5] 和[11] 。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            var sum = nums.Sum();
            if (sum % 2 == 1)
            {
                return false;
            }
            int bagSize = sum / 2;
            //w[i]=nums[i]
            //v[i]=nums[i]
            int[][] dp = new int[nums.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[bagSize + 1];
                dp[i][0] = 0;
            }

            for (int i = 1; i <= nums.Length; i++)
            {
                for (int j = 1; j <= bagSize; j++)
                {
                    if (j < nums[i - 1])
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 1][j - nums[i - 1]] + nums[i - 1]);
                    }
                }
            }
            //for (int i = 0; i < dp.Length; i++)
            //{
            //    for (int j = 0; j < dp[i].Length; j++)
            //    {
            //        Console.Write(dp[i][j] + "\t");
            //    }
            //    Console.WriteLine();
            //}
            return dp[nums.Length][bagSize] == bagSize;
        }
        /// <summary>
        /// 01背包
        /// </summary>
        /// <param name="weight">物品的重量</param>
        /// <param name="value">物品的价值</param>
        /// <param name="bagSize">背包的重量</param>
        public static void TestWeightBagProblem(int[] w, int[] v, int bagSize)
        {
            // 定义变量：Vi = 第i个物品的价值
            //           Wi = 第i个物品的体积
            //           V(i,j)=当前背包的容量j,前i个物品最佳组合对应的价值，
            //抽象化：（X1,X2,...,Xn) 其中Xi去0或1，表示第i个物品选或不选

            //1.建立模型，即求max(V1X1+V2X2+...+VnXn);
            //2.寻找约束条件，W1X1+W2X2+...+WnXn<bogSize;
            //3.寻找递推关系公式，面对当前商品有两种可能性：
            //1).包的容量比该商品体积小，装不下，此时的价值与前一个价值是一样的，V(i,j)=V(i-1,j);
            //2).还有足够的容量可以装下该商品，但是装了也不一定达到当前最优的价值，所以要在装与不装之间选择最优的一个V(i,j)=max{v(i-1,j),V(i-1,j-w(i))+v(i)}
            //其中V(i-1,j)表示不装，V(i-1,j-w(i))+v(i)表示装了第i个商品，背包容量减少w(i),但是价值增加了v(i)
            /*
             为啥能装的情况这样求：
                可以这么理解：如果要达到V(i,j)这个状态有两种方式：
                1.第i件商品没有装进去 v(i-1,j)
                2.第i件商品装进去了,问：装进去之前是什么状态？装进去之前肯定是V(i-1,j-w(i))
             */


            int[][] dp = new int[w.Length + 1][];
            for (int i = 0; i <= w.Length; i++)
            {
                dp[i] = new int[bagSize + 1];
                dp[i][0] = 0;
            }

            for (int i = 1; i <= w.Length; i++)
            {
                for (int j = 1; j <= bagSize; j++)
                {
                    if (j < w[i - 1])
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 1][j - w[i - 1]] + v[i - 1]);
                    }
                }
            }
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    Console.Write(dp[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 139.单词拆分(动态规划）
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak1(string s, IList<string> wordDict)
        {
            // s中以i-1结尾的字符串是否可被wordDict 拆分
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            HashSet<string> hashSet = new HashSet<string>(wordDict);

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var str = s.Substring(i, j);
                    if (dp[j] && wordDict.Contains(str))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[dp.Length - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < wordDict.Count; i++)
            {
                set.Add(wordDict[i]);
            }
            int endIndex = s.Length - 1;
            int startIndex = 0;
            while (endIndex > 0)
            {

                string startStr = s.Substring(startIndex, endIndex - startIndex + 1);
                if (set.Contains(startStr))
                {
                    startIndex = startStr.Length - 1;
                    endIndex = s.Length - 1;
                    continue;
                }
                endIndex--;

            }

            return false;
        }
        /// <summary>
        /// 螺旋矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> order = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return order;
            }
            // 定义 行和列
            int rows = matrix.Length, columns = matrix[0].Length;
            // 定义 上下左右
            int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
            while (left <= right && top <= bottom)
            {
                for (int column = left; column <= right; column++)
                {
                    order.Add(matrix[top][column]);
                }
                for (int row = top + 1; row <= bottom; row++)
                {
                    order.Add(matrix[row][right]);
                }
                if (left < right && top < bottom)
                {
                    for (int column = right - 1; column > left; column--)
                    {
                        order.Add(matrix[bottom][column]);
                    }
                    for (int row = bottom; row > top; row--)
                    {
                        order.Add(matrix[row][left]);
                    }
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            return order;
        }
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
            int len = 0;
            while (len < strs[0].Length)
            {
                for (int i = 0; i < strs.Length - 1; i++)
                {
                    if (strs[i].Length <= len || strs[i + 1].Length <= len)
                    {
                        // Console.WriteLine("长度不够跳出了");
                        return strs[0].Substring(0, len);
                    }
                    char qian = strs[i][len]; // 前一个数的 第j为字母
                    char hou = strs[i + 1][len]; // 后一位数的 第j 为字母
                    if (qian != hou)
                    {
                        // 有一个不等的就可以跳出来了
                        return strs[0].Substring(0, len);
                    }
                }
                len++;
            }
            return strs[0].Substring(0, len);
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

            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        Console.WriteLine($"i={i},j={j}");
                        list.Add(new int[] { i, j }.ToList());
                    }
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                var arr = list[i];

                int colIndex = 0;
                while (colIndex < matrix[0].Length)
                {
                    matrix[arr[0]][colIndex] = 0;
                    colIndex++;
                }
                int rowIndex = 0;
                while (rowIndex < matrix.Length)
                {
                    matrix[rowIndex][arr[1]] = 0;
                    rowIndex++;
                }
            }

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
            Array.Sort(nums);
            int fastIndex = nums.Length - 1;
            int lowIndex = 1;
            if (nums.Length == 3)
            {
                if (nums[0] + nums[1] + nums[2] == 0)
                {
                    result.Add(nums);
                    return result;
                }
            }
            for (int i = 0; i < nums.Length - 2; i++)
            {
                lowIndex = i + 1;
                while (lowIndex < fastIndex)
                {
                    int curVal = nums[i];
                    int lowVal = nums[lowIndex];
                    int fastVal = nums[fastIndex];

                    if (curVal + lowVal + fastVal == 0)
                    {
                        result.Add(new List<int> { curVal, lowVal, fastVal });
                    }
                    lowIndex++;
                };

            }

            return null;
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
        public int FindTargetSumWays1(int[] nums, int target)
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
