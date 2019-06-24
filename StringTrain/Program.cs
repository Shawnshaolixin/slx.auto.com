using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTrain
{
    class Program
    {
        public class ComparerTest : IComparer<String>
        {
            public int Compare(String x, String y)
            {
                return string.CompareOrdinal(x, y);
            }
        }
        static void Gen(string item, int n, List<string> result)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine($"n={n}" + item);
            n--;
            Gen(item + "(", n, result);
            Gen(item + ")", n, result);
        }

        static void ForeachTree(TreeNode treeNode)
        {
            if (treeNode == null) return;


            ForeachTree(treeNode.left);
            Console.WriteLine(treeNode.val);
            ForeachTree(treeNode.right);
        }

        public class Solution
        {


            /// <summary>
            /// 给定一个二叉树和一个目标和，判断该树中是否存在根节点到叶子节点的路径，这条路径上所有节点值相加等于目标和
            /// </summary>
            /// <param name="root"></param>
            /// <param name="sum"></param>
            /// <returns></returns>
            public bool HasPathSum(TreeNode root, int sum)
            {
                  List<int[]> stackList = new List<int[]>();
                Stack<int> item = new Stack<int>();
                Get(root, stackList, item);
                var count = stackList.Count();
                return false;
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
                    var list = item.ToArray();
                    stackList.Add(list);
                }
                Get(root.left,stackList, item);
                Get(root.right, stackList, item);
                item.Pop();
            }

            IList<int> resultList = new List<int>();
            public IList<int> InorderTraversal(TreeNode root)
            {
                if (root == null) return resultList;
                InorderTraversal(root.left);
                resultList.Add(root.val);
                InorderTraversal(root.right);
                return resultList;
            }
            /// <summary>
            /// 总路径条数
            /// </summary>
            List<Stack<int>> result = new List<Stack<int>>();


            /// <summary>
            /// 最大深度
            /// </summary>
            /// <param name="root"></param>
            /// <returns></returns>
            public int MaxDepth(TreeNode root)
            {
                FindPath(root);
                return length;
            }
            int length = 0;
            List<int> lengthList = new List<int>();
            Stack<int> item = new Stack<int>();

            public int MinDepth(TreeNode root)
            {
                FindPath(root);
                return lengthList.Count > 0 ? lengthList.Min() : 0;
            }

            public void FindPath(TreeNode root)
            {
                if (root == null)//叶子节点
                {
                    return;
                };
                item.Push(root.val);
                if (root.left == null && root.right == null)
                {
                    lengthList.Add(item.Count);
                }
                FindPath(root.left);
                FindPath(root.right);
                item.Pop();
            }





            bool b = true;
            public bool IsSameTree(TreeNode p, TreeNode q)
            {
                if (q != null && p != null)
                {
                    if (p.val != q.val)
                    {
                        b = false;
                        return false;
                    }
                    else
                    {
                        IsSameTree(p.left, q.left);
                        IsSameTree(p.right, q.right);
                    }

                }
                else
                {
                    if (p == null && q == null)
                    {
                        return b;
                    }
                    else
                    {
                        b = false;
                        return false;
                    }

                }
                return b;
            }

        }
        static void Main(string[] args)
        {

            #region 二叉树的遍历
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(8);
            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node5.left = node7;
            node5.right = node8;
            node3.right = node6;


            //TreeNode q = new TreeNode(0);
            //TreeNode q1 = new TreeNode(-5);
            //q.left = q1;

            //TreeNode p = new TreeNode(0);
            //TreeNode p1 = new TreeNode(-8);
            //p.left = p1;
            Solution s = new Solution();

            var b = s.HasPathSum(node1, 10);
            //  s.InorderTraversal(node1);
            //var b = s.IsSameTree(p, q);
      //      var d = s.MinDepth(node1);
            // Console.WriteLine(d);
            //   ForeachTree(node1);
            Console.ReadKey();















            #endregion










            Solution18 solution18 = new Solution18();
            ListNode listNode1 = new ListNode(2);
            ListNode listNode2 = new ListNode(4);
            ListNode listNode3 = new ListNode(3);

            listNode2.next = listNode3;
            listNode1.next = listNode2;

            ListNode lide1 = new ListNode(5);
            ListNode lide2 = new ListNode(6);
            ListNode lide3 = new ListNode(4);

            lide2.next = lide3;
            lide1.next = lide2;
            solution18.AddTwoNumbers(listNode1, lide1);

            Console.ReadKey();
            Gen("", 4, new List<string>());
            Console.ReadKey();
            Solution solution = new Solution();
            // solution.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });



            //string path = "/home/";
            ////    var arr = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            //Solution solution = new Solution();
            //var s = solution.SimplifyPath(path);
            //Console.WriteLine(s);
            //Console.ReadKey();

            //Console.WriteLine(3&5);
            //Console.WriteLine(3|5);
            //Console.WriteLine(3^5);
            //Console.WriteLine(~3);
            //Console.WriteLine(3<<2);
            //Console.WriteLine(5>>2);
            //Console.ReadKey();
            //  Solution solution = new Solution();
            //  int[] nums = new int[] { 1, 2, 3 };


            //  String[] source = new String[] { "bV", "bv", "aB", "ab" };




            //  Array.Sort(source, (a, c) => string.CompareOrdinal(a, c));



            ////  var result1 = solution.Subsets(nums);
            //  var list = new Dictionary<string, int>();



            //list.Add("bV", 2);
            //list.Add("bv", 2);
            //list.Add("aB", 2);
            //list.Add("ab", 2);
            //var list3 = (from entry in list
            //             orderby entry.Key ascending
            //             select entry).ToList();

            //Array.Sort(list.ToArray(), (a, c) => string.CompareOrdinal(a.Key, c.Key));
            //var list2 = list;
            //var list1 = list.OrderBy(x => x.Key, new ComparerTest()).ToList();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //   Solution solution = new Solution();
            //    var arrs = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
            //string str = @"accountId=1&appKey=pro-dQmBP11k8rwo4KUw&branchCode=a9e5fe89-3a65-43b9-9a6c-12cdbad69985&carInfo={"engineNo":"JDDIDJNDKJSIDNDN","standardName":"丰田CA64604TME5多用途乘用车","carTypeJson":{"yy":false,"zbzl":"0","hdzzl":"0","cllx":"K33","pl":"2494","hdzk":"5","syxz":"A"},"ownerName":"马云","vehicleFrameNo":"LFMJ34AF6G3098040","idCard":"362543652754845275","carTypeCode":"02","vehicleId":"FTAASD0068","boughtTime":1559606400}&forceInsuranceStartTime=1559606400&insuranceCompany=24&insuranceStartTime=1559606400&insurancesList=[{"insurances":[{"isToubao":1,"amountStr":"100万","price":"1000000","insuranceId":2,"insuranceName":"第三者责任险","compensation":true},{"isToubao":1,"amountStr":"1万","price":"10000","insuranceId":4,"insuranceName":"司机座位责任险","compensation":true},{"isToubao":1,"amountStr":"1万","price":"10000","insuranceId":5,"insuranceName":"乘客座位责任险","compensation":true},{"isToubao":1,"amountStr":"国产","price":"1","insuranceId":6,"insuranceName":"玻璃单独破碎险","compensation":false},{"isToubao":1,"amountStr":"5000","price":"5000","insuranceId":7,"insuranceName":"车身划痕损失险","compensation":true}],"schemeName":"方案9","forcePremium":{"isToubao":1}}]&requestHeader=02c735ba-3e35-48ba-94b9-210897aed896&ts=1560753487&secret=3TT9tvwnb8rBNa3CYv5NRmMisZj3Ltgt";

            //   var a = solution.TwoSum(arrs, 542);
            //   int b = 0;
            //     Console.WriteLine(solution.IsPalindrome(-123454321));

            Console.ReadKey();

            //Solution solution = new Solution();
            //string[] arr = new string[] { "5", "2", "C", "D", "+" };
            //var count = solution.CalPoints(arr);
            //Console.WriteLine(count);
            #region MyQueue

            //MyQueue myQueue = new MyQueue();
            //myQueue.Push(1);
            //myQueue.Push(2);
            //myQueue.Push(3);
            //myQueue.Push(4);
            //myQueue.Push(5);
            //Console.WriteLine(myQueue.Peek());
            //while (!myQueue.Empty())
            //{
            //    Console.WriteLine(myQueue.Pop());
            //} 
            #endregion
            #region MyStack
            //MyStack myStack = new MyStack();
            //myStack.Push(1);
            //myStack.Push(2);

            //myStack.Push(3);
            //myStack.Push(4);
            //while (!myStack.Empty())
            //{
            //    Console.WriteLine(myStack.Pop());
            //}
            //Console.WriteLine(myStack.Top());
            //Console.WriteLine(myStack.Empty()); 
            #endregion

            #region 验证符号
            //Solution solution = new Solution();
            //var b = solution.IsValid("[{[]}{[]}][]{}()");
            //Console.WriteLine(b); 
            #endregion
            #region 验证栈序列
            //Solution solution = new Solution();
            //int[] pushed = new int[] { 1, 2, 3, 4, 5 };
            //int[] popped = new int[] { 4, 3, 5, 1, 2 };
            //var b = solution.ValidateStackSequences(pushed, popped); 
            #endregion

            #region 最小栈
            //MinStack minStack = new MinStack();
            //minStack.Push(1);
            //minStack.Push(2);
            //minStack.Push(3);
            //minStack.Push(-9);
            //minStack.Push(6);
            //Console.WriteLine(minStack.Top());
            //Console.WriteLine(minStack.Top());
            //Console.WriteLine(minStack.GetMin()); 
            #endregion
            Console.Read();
        }
        static Boolean IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var arr = s.ToCharArray();

            return false;
        }
    }

    //public class Solution
    //{
    //    public bool ValidateStackSequences(int[] pushed, int[] popped)
    //    {

    //        Queue q = new Queue();
    //        Stack s = new Stack();
    //        for (int i = 0; i < popped.Length; i++)
    //        {
    //            q.Enqueue(popped[i]);
    //        }
    //        for (int i = 0; i < pushed.Length; i++)
    //        {
    //            s.Push(pushed[i]);
    //            while (s.Count > 0 && ((int)s.Peek() == (int)q.Peek()))
    //            {
    //                q.Dequeue();
    //                s.Pop();
    //            }
    //        }
    //        return s.Count <= 0;
    //    }
    //}
    public class MinStack
    {
        Stack stack = new Stack();
        Stack minStack = new Stack();
        /** initialize your data structure here. */
        public MinStack()
        {


        }

        public void Push(int x)
        {
            stack.Push(x);
            if (minStack.Count <= 0)
            {
                minStack.Push(x);
            }
            else
            {
                if (x < (int)minStack.Peek())
                {
                    minStack.Push(x);
                }
                else
                {
                    minStack.Push((int)minStack.Peek());
                }
            }

        }
        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }
        public int Top()
        {
            return (int)stack.Peek();
        }
        public int GetMin()
        {
            return (int)minStack.Peek();
        }
    }
    #region 验证括号
    //public class Solution1
    //{
    //    public bool IsValid(string s)
    //    {
    //        if (string.IsNullOrEmpty(s))
    //            return true;
    //        Queue q = new Queue();
    //        Stack stack = new Stack();
    //        char a = '(';
    //        char b = ')';
    //        char c = '{';
    //        char d = '}';
    //        char e = '[';
    //        char f = ']';

    //        for (int i = 0; i < s.Length; i++)
    //        {
    //            if (s[i] == a)
    //            {
    //                q.Enqueue(1);
    //            }
    //            if (s[i] == b)
    //            {
    //                q.Enqueue(-1);
    //            }
    //            if (s[i] == c)
    //            {
    //                q.Enqueue(2);
    //            }
    //            if (s[i] == d)
    //            {
    //                q.Enqueue(-2);
    //            }
    //            if (s[i] == e)
    //            {
    //                q.Enqueue(3);
    //            }
    //            if (s[i] == f)
    //            {
    //                q.Enqueue(-3);
    //            }
    //        }
    //        while(q.Count>0)
    //        {
    //            if (stack.Count > 0 && ((int)stack.Peek() + (int)q.Peek() == 0))
    //            {
    //                stack.Pop();
    //                q.Dequeue();
    //            }
    //            else
    //            {
    //                stack.Push(q.Dequeue());
    //            }

    //        }



    //        return stack.Count <= 0;
    //    }
    //} 
    #endregion
    public class Solution1
    {
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c.IsLeft())
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    else
                    {
                        var top = stack.Pop();
                        if (!top.Match(c)) return false;
                    }
                }
            }

            return stack.Count == 0;
        }




    }
    public static class CharExtension
    {
        public static bool IsLeft(this char ch)
        {
            return ch == '[' || ch == '{' || ch == '(';
        }
        public static bool Match(this char lhs, char rhs)
        {
            return (lhs == '(' && rhs == ')') || (lhs == '[' && rhs == ']') || (lhs == '{' && rhs == '}');
        }
    }
    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
    public class MyStack
    {
        Queue<int> queue = new Queue<int>();
        Queue<int> temp_queue = new Queue<int>();
        /** Initialize your data structure here. */
        public MyStack()
        {

        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            temp_queue.Enqueue(x);
            while (queue.Count > 0)
            {
                temp_queue.Enqueue(queue.Dequeue());
            }
            while (temp_queue.Count > 0)
            {
                queue.Enqueue(temp_queue.Dequeue());
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return queue.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            if (queue.Count <= 0)
            {
                throw new InvalidOperationException("mystack empty");
            }
            return queue.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return queue.Count <= 0;
        }
    }

    /**
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
    public class MyQueue
    {
        private Stack<int> stack;
        private Stack<int> temp_stack;
        /** Initialize your data structure here. */
        public MyQueue()
        {
            stack = new Stack<int>();
            temp_stack = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            while (stack.Count > 0)
            {
                temp_stack.Push(stack.Pop());
            }
            temp_stack.Push(x);
            while (temp_stack.Count > 0)
            {
                stack.Push(temp_stack.Pop());
            }
        }
        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if (Empty())
            {
                throw new InvalidOperationException("myqueue empty");
            }
            return stack.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            if (Empty())
            {
                throw new InvalidOperationException("myqueue empty");
            }
            return stack.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return stack.Count <= 0;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */

    //public class Solution
    //{
    //    public int CalPoints(string[] arr)
    //    {
    //        Stack<int> stack = new Stack<int>();//有效分数
    //        Stack<int> score_stack = new Stack<int>();//记录总分数

    //        for (int i = 0; i < arr.Length; i++)
    //        {
    //            int num = 0;

    //            if (int.TryParse(arr[i], out num))
    //            {
    //                stack.Push(num);
    //                if (score_stack.Count > 0)
    //                {
    //                    score_stack.Push(num + score_stack.Peek());
    //                }
    //                else
    //                {
    //                    score_stack.Push(num);
    //                }
    //            }
    //            else
    //            {

    //                if (arr[i] == "C")
    //                {
    //                    num = (score_stack.Peek() - stack.Pop()) + stack.Peek();
    //                    score_stack.Push(num);
    //                }
    //                if (arr[i] == "D")
    //                {
    //                    num = score_stack.Peek() + 2 * Convert.ToInt32(stack.Peek());
    //                    score_stack.Push(num);
    //                    stack.Push(2 * Convert.ToInt32(stack.Peek()));
    //                }
    //                if (arr[i] == "+")
    //                {
    //                    var qian1 = stack.Pop();
    //                    var qian2 = stack.Pop();
    //                    num = score_stack.Peek() + qian2 + qian1;
    //                    score_stack.Push(num);

    //                    stack.Push(qian2 + qian1);
    //                }

    //            }
    //        }
    //        return score_stack.Peek();
    //    }
    //}
    public class Solution13
    {
        public void Generate(int i, int[] nums, Stack<int> item, List<int[]> result)
        {
            if (i >= nums.Length)
            {
                return;
            }
            item.Push(nums[i]);
            result.Add(item.ToArray());
            Generate(i + 1, nums, item, result);
            item.Pop();
            Generate(i + 1, nums, item, result);
        }
    }
    public class Solution12
    {

        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());//加一个空的
            foreach (var item in nums)
            {
                int length = result.Count;
                for (int i = 0; i < length; i++)
                {
                    List<int> subset = new List<int>(result[i]);
                    subset.Add(item);
                    result.Add(subset);
                }
            }
            return result;

        }
    }
    public class Solution14
    {
        public bool IsPalindrome(int x)
        {
            string s = Convert.ToString(x);
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                queue.Enqueue(s[i]);
                stack.Push(s[i]);
            }
            while (queue.Count > 0 && stack.Count > 0)
            {
                if (queue.Dequeue() == stack.Pop())
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return queue.Count == 0 && 0 == stack.Count;
        }
    }
    public class Solution15
    {
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
                dict.Add(nums[i], i);
            }
            throw new ArgumentException("No two sum solution");
        }
    }

    public class Solution16
    {
        public string SimplifyPath(string path)
        {
            //  string path = "/a/../../b/../c//.//";
            if (string.IsNullOrEmpty(path)) return "/";
            var arr = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            Stack stack = new Stack();
            stack.Push("/");
            foreach (var item in arr)
            {

                if (item == "..")
                {
                    if (stack.Count > 1)
                    {
                        stack.Pop();
                    }
                }
                else if (item == ".")
                {

                }
                else
                {
                    stack.Push(item);
                }
            }
            List<string> list = new List<string>();
            while (stack.Count > 0)
            {
                list.Add(stack.Pop().ToString());
                if (stack.Count > 0 && stack.Peek().ToString() != "/")
                {
                    list.Add("/");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Insert(0, item);
            }
            return sb.ToString();
        }
    }

    public class Solution
    {
        public int Trap(int[] height)
        {
            height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            bool flag = true;
            List<int> list = new List<int>();
            Stack<int> stack = new Stack<int>();
            int sum = 0;
            int step = 0;
            int total = 0;
            for (int i = 0; i < height.Length; i++)
            {

                if (i < height.Length - 1)
                {

                    if (height[i] > height[i + 1])//如果后比前一个小
                    {

                        if (flag)
                        {
                            if (stack.Count > 0)
                            {
                                var area = (step * (stack.Peek() < height[i] ? stack.Peek() : height[i])) - sum;
                                step = 0;
                                sum = 0;
                            }

                            stack.Push(height[i]);
                        }
                        else
                        {
                            sum += height[i];
                            Console.WriteLine("下坡元素=" + height[i] + " step=" + step);
                        }

                        flag = false;
                    }
                    else//状态转换点 第一次进来的时候 计算
                    {
                        if (stack.Count > 0)
                        {
                            ++step;
                            sum += height[i];
                            Console.WriteLine("上坡元素=" + height[i] + " step =" + step);
                        }
                        flag = true;

                    }

                }
                else
                {
                    Console.WriteLine("到最后一个了=" + height[i]);
                    if (height[i] > stack.Peek())
                    {
                        ++step;
                        Console.WriteLine("最后一个元素也得算一下step=" + step);
                        stack.Push(height[i]);
                    }
                }


            }
            return 0;
        }
    }

    /// <summary>
    /// 生成括号
    /// </summary>
    public class Solution17
    {
        public IList<string> GenerateParenthesis(int n)
        {

            IList<string> list = new List<string>();
            Generate("", n, n, list);

            foreach (var item in list)
            {

            }
            return list;
        }
        void Generate(string item, int left, int right, IList<string> result)
        {
            Stack<char> stack = new Stack<char>();
            if (left == 0 && right == 0)
            {

                result.Add(item);
                return;
            }
            if (left > 0)
            {
                Generate(item + "(", left - 1, right, result);
            }
            if (left < right)
            {
                Generate(item + ")", left, right - 1, result);
            }

        }
    }
    /**
 * Definition for singly-linked list.
 * 
 */
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class Solution18
    {
        public ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }

        public ListNode AddTwoNumbers(ListNode listNode, ListNode listNode1)
        {
            ListNode resultList = new ListNode(0);
            ListNode curr = resultList;
            int temp = 0;
            while ((listNode) != null || (listNode1) != null)
            {



                int sum1 = listNode != null ? listNode.val : 0;
                int sum2 = listNode1 != null ? listNode1.val : 0;
                if (listNode != null) listNode = listNode.next;
                if (listNode1 != null) listNode1 = listNode1.next;
                if (sum1 + sum2 + temp >= 10)
                {
                    curr.next = new ListNode(sum1 + sum2 + temp - 10);
                    curr = curr.next;
                    temp = 1;
                }
                else
                {
                    curr.next = new ListNode(sum1 + sum2 + temp);
                    curr = curr.next;
                    temp = 0;
                }
            };
            if (temp > 0)
            {
                curr.next = new ListNode(1);

                curr = curr.next;
            }
            return resultList.next;
        }


    }
    /// <summary>
    /// 二叉树
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// 根节点
        /// </summary>
        public int val { get; set; }
        /// <summary>
        /// 左子树
        /// </summary>
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int node)
        {
            this.val = node;
        }
    }
}


