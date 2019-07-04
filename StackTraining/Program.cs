using System;
using System.Collections.Generic;
using System.Linq;

namespace StackTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person zhangsan = new Man("张三", 5);
            //Person xiaofang = new Woman("小芳", 5);
            //zhangsan.GetPartner(xiaofang);
            //xiaofang.GetPartner(zhangsan);
            //Console.ReadKey();
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(4);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(2);
            TreeNode node5 = new TreeNode(4);
            TreeNode node6 = new TreeNode(7);
            TreeNode node7 = new TreeNode(9);
            TreeNode node8 = new TreeNode(3);
            TreeNode node9 = new TreeNode(5);
            node1.left = node2;
            node1.right = node3;
            node2.left = node4;



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
            //  var count = s.FindMinArrowShots(testData);
            //  Console.WriteLine(count);

            //   s.LongestPalindrome("babad");
            //   s.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
            //Console.WriteLine(s.SearchInsert(new int[] { 1, 3 }, 2));
            //Console.WriteLine(s.SearchInsert(new int[] { 1, 3 }, 0));
            //Console.WriteLine(s.SearchInsert(new int[] { 1, 3, }, 4));
            //Console.WriteLine(s.SearchInsert(new int[] { 1, 3 }, 1));

            //   s.ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
            //  var reslut = s.ReverseWords("Let's take LeetCode contest");


            //   s.LowestCommonAncestor(node1, node1, node2);
            //  s.ZigzagLevelOrder(node1);
            //   Console.WriteLine(reslut);
            //  var result = s.MaxArea(new int[] { 1, 2, 4, 3 });
            //   s.Trap(new int[] { });
            //     Console.Read();
            //  s.Test(new int[] { 1, 1, 2 });
            //  Console.WriteLine(result);
            // s.Rotate(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } });
            // var r = s.CanJump(new int[] { 5, 9, 3, 2, 1, 0, 2, 3, 2, 1, 0, 0 });//2,3,1,1,4
            //   var r = s.CanJump(new int[] { 3, 2, 1, 0, 4 });//2,3,1,1,4
            ///  var r = s.NumJewelsInStones("aA", "aAAbbbb");
            //   var r = s.RemoveElement(new int[] { 3, 2, 2, 3, 2, 3, 1, 2, 3, 4 }, 2);
            //  Console.WriteLine(r);
            //  Console.WriteLine(s.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));
            //  Console.WriteLine(s.RemoveElement(new int[] { 3, 2, 21, 2, 3, 4 }, 4));
            //  Console.WriteLine(s.RemoveElement(new int[] { 3, 2, 2, 3, 2, 3, 4 }, 3));
            //  Console.WriteLine(s.RemoveElement(new int[] { 2, 2, 2, 2, 2, 2, }, 2));
            //  Console.WriteLine(s.RemoveElement(new int[] { 3, 3 }, 3));

            //   var result = s.Merge(new int[][] { new int[] { 1, 4 }, new int[] { 0, 4 }, new int[] { 8, 10 }, new int[] { 15, 18 }, });

            //  s.SortColors(new int[] { 0, 0, 2, 0, 2, 1, 1, 2, 1, 2, 2, 1, 0, 0, 0, 0, 1, 2, 2, 1, 1, 1, 1, 2, 2, 0, 0, 2, 0, 2, 1, 1, 2, 1, 2, 2, 0, 0, 2, 0, 2, });
            ListNode l1 = new ListNode(1);
            ListNode l2 = new ListNode(2);
            ListNode l3 = new ListNode(3);
            ListNode l4 = new ListNode(4);
            l1.next = l2;
            l2.next = l3;
            l3.next = l4;
            //  var ll = s.ReverseList(l1);
            //     ListNode result = s.MergeTwoLists(l1, l4);

            //  var r1 = s.BuildTree(new int[] { 1, 2, 4, 7, 3, 5, 6, 8 }, new int[] { 4, 7, 2, 1, 5, 3, 8, 6 });
            //     var res = s.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
            //  var res1 = s.PreorderTraversal(node1);
            //foreach (var item in res1)
            //{
            //    Console.WriteLine(item);
            //}
            //  Console.WriteLine(res);

            //Console.WriteLine(s.RomanToInt("III"));
            //Console.WriteLine(s.RomanToInt("IV"));
            //Console.WriteLine(s.RomanToInt("IX"));
            //Console.WriteLine(s.RomanToInt("LVIII"));
            //   Console.WriteLine(s.RomanToInt("MCMXCIV"));

            //Console.WriteLine(s.StrStr("abcdefiasdfsafda", "ias"));
            //// Console.WriteLine(s.StrStr("abcdefiasdfsafda", "fias"));
            ////  Console.WriteLine(s.StrStr("abcdefiasdfsafda", "faias"));
            //Console.WriteLine(s.StrStr("abcdefiasdfsafda", "iasa"));
            //Console.ReadKey();

            s.PrevTreeNode(node1);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public void PrevTreeNode(TreeNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.val);
            PrevTreeNode(root.left);
            PrevTreeNode(root.right);
        }

        public int F(int n)
        {
            Console.WriteLine(n);
            if (n == 0)
                return 1;
            int i = n * F(n - 1);
            return i;
        }
        public int StrStr(string haystack, string needle)
        {

            if (string.IsNullOrEmpty(needle)) return 0;
            int res = -1;
            for (int i = 0; i < haystack.Length; i++)
            {
                if ((i + needle.Length) > haystack.Length) return -1;
                if (haystack[i] == needle[0])
                {
                    for (int j = 0; j < needle.Length; j++)
                    {
                        if (haystack[i + j] == needle[j])
                        {

                        }
                        else
                        {
                            res = -1;
                            break;
                        }
                    }
                    res = i;
                }
            }
            return res;
        }
        public int RomanToInt(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            int res = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == 'I' && (s[i + 1] == 'V' || s[i + 1] == 'X'))
                {
                    res = res - dict[s[i]];
                }
                else
                if (s[i] == 'X' && (s[i + 1] == 'L' || s[i + 1] == 'C'))
                {
                    res = res - dict[s[i]];
                }
                else
                if (s[i] == 'C' && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                {
                    res = res - dict[s[i]];
                }
                else
                {
                    res = res + dict[s[i]];
                }


            }
            res += dict[s[s.Length - 1]];
            return res;
        }
        /// <summary>
        /// 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            ListNode next;
            ListNode prev = null;
            while (head != null)
            {
                next = head.next;//先保存 免丢失
                head.next = prev;//当前结点的next指向上一个节点
                prev = head;
                head = next;
            }
            return prev;
        }


        public IList<int> PreorderTraversal(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            IList<int> res = new List<int>();

            if (root == null) return res;
            stack.Push(root);
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                res.Add(item.val);

                if (item.right != null)
                {
                    stack.Push(item.right);
                }
                if (item.left != null)
                {
                    stack.Push(item.left);
                }
            }
            return res;
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
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

            return dict.OrderByDescending(i => i.Value).Take(k).Select(i =>
               {
                   return i.Key;
               }).ToArray();
        }


        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums2.Length == 0 || nums1.Length == 0) return new int[] { };
            List<int> list = new List<int>();
            List<int> res = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                list.Add(nums1[i]);
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (list.Contains(nums2[i]) && !res.Contains(nums2[i]))
                {
                    res.Add(nums2[i]);
                }
            }
            return res.ToArray();
        }


        public int RepeatedNTimes(int[] A)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (list.Contains(A[i]))
                {
                    return A[i];
                }
                else
                {
                    list.Add(A[i]);
                }
            }
            return 0;
        }
        /// <summary>
        /// 买股票最佳时机
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 0) return 0;
            int res = 0;
            bool isMairu = false;
            var mairuprice = 0;
            var maichuprice = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {

                if (prices[i] < prices[i + 1])
                {
                    //涨了得买了
                    if (!isMairu)
                    {
                        mairuprice = prices[i];
                        isMairu = true;
                    }

                }
                else
                {
                    if (isMairu)
                    {
                        maichuprice = prices[i];
                        isMairu = false;
                    }
                    //降了 得买了 买完了计算下  赚了多少

                }
                if (!isMairu)
                {
                    res += (maichuprice - mairuprice);
                    maichuprice = 0;
                    mairuprice = 0;
                }


            }
            if (isMairu)
            {
                res += prices[prices.Length - 1] - mairuprice;
            }
            return res;
        }
        public int MissingNumber(int[] nums)
        {
            int res = nums.Length;
            if (nums.Length <= 0) return 0;
            for (int i = 0; i < nums.Length; i++)
            {
                res ^= nums[i];
                res ^= i;

            }
            return res;
        }

        public ListNode ReverseList1(ListNode head)
        {
            ListNode preNode = null;//前一个节点
            ListNode currNode = head;
            while (currNode != null)
            {
                ListNode currNext = currNode.next;//当前的下一个节点
                currNode.next = preNode;
                preNode = currNode;
                currNode = currNext;


            }

            return currNode;

        }
        public void BuildTree(int[] preorder, int[] inorder, TreeNode treeNode)
        {
            if (preorder.Length <= 0 || inorder.Length <= 0) return;
            if (preorder.Length != inorder.Length)
            {
                throw new Exception("参数异常");
            };
            int preorderIndex = 0;
            var rootVal = preorder[preorderIndex];
            int inorderIndex = 0;
            int leftLen = 0;//左子树数量
            int rightLen = 0;//右子树数量
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == rootVal)
                {
                    inorderIndex = i;
                }
            }
            leftLen = inorderIndex - preorderIndex;
            if (leftLen > 0)
            {
                var preleftorder = preorder.Skip(preorderIndex + 1).Take(leftLen).ToArray();
                var inleftorder = inorder.Skip(0).Take(leftLen).ToArray();
                BuildTree(preleftorder, inleftorder, treeNode);

            }
            rightLen = inorder.Length - inorderIndex - 1;

            if (rightLen > 0)
            {
                //生成右子树
                var prerightorder = preorder.Skip(leftLen + preorderIndex + 1).Take(rightLen).ToArray();
                var inrightorder = inorder.Skip(inorderIndex + 1).ToArray();
                BuildTree(prerightorder, inrightorder, treeNode);
            }


        }
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length <= 0 || inorder.Length <= 0) return null;
            if (preorder.Length != inorder.Length)
            {
                throw new Exception("参数异常");
            };
            int preorderIndex = 0;
            var rootVal = preorder[preorderIndex];

            TreeNode treeNode = new TreeNode(rootVal);

            int inorderIndex = 0;
            int leftLen = 0;//左子树数量
            int rightLen = 0;//右子树数量
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == rootVal)
                {
                    inorderIndex = i;
                }
            }
            leftLen = inorderIndex - preorderIndex;
            if (leftLen > 0)
            {
                var preleftorder = preorder.Skip(preorderIndex + 1).Take(leftLen).ToArray();
                var inleftorder = inorder.Skip(0).Take(leftLen).ToArray();
                BuildTree(preleftorder, inleftorder, treeNode);

            }
            rightLen = inorder.Length - inorderIndex - 1;

            if (rightLen > 0)
            {
                //生成右子树
                var prerightorder = preorder.Skip(leftLen + preorderIndex + 1).Take(rightLen).ToArray();
                var inrightorder = inorder.Skip(inorderIndex + 1).ToArray();
                BuildTree(prerightorder, inrightorder, treeNode);
            }
            return treeNode;

        }

        /// <summary>
        /// 杨辉三角
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (numRows <= 0) return result;
            List<int> item = new List<int>();

            for (int i = 1; i <= numRows; i++)
            {
                if (result.Count == 0)
                {
                    item.Add(1);
                    result.Add(item.ToArray());
                }
                else
                {
                    var last = result[i - 2];

                    for (int j = 0; j < last.Count; j++)
                    {
                        if (j < last.Count - 1)
                        {
                            item.Add(last[j] + last[j + 1]);
                        }
                    }

                    result.Add(item.ToArray());
                }
            }
            return result;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            bool flag = false;
            while (l1 != null)
            {
                head.next = l1;
                head = head.next;

                l1 = l1.next;
            }


            return head;
        }
        /// <summary>
        /// 颜色分类
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            if (nums.Length <= 0) return;

            int end = nums.Length - 1;
            int start = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > nums.Length - 1 - count)
                {
                    break;
                }
                if (nums[i] == 2)
                {
                    while (nums[end] == 2 && end > i)
                    {
                        end--;
                    }
                    if (end > i)
                    {
                        var temp = nums[i];
                        nums[i] = nums[end];
                        nums[end] = temp;
                        end--;
                        count++;
                    }
                }
                if (nums[i] == 0)
                {
                    while (nums[start] == 0 && i > start)
                    {
                        start++;
                    }
                    var temp = nums[start];
                    nums[start] = nums[i];
                    nums[i] = temp;
                    start++;
                }

            }
        }
        /// <summary>
        /// 合并区间
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 0) return new int[][] { };
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            List<int[]> result = new List<int[]>();
            Stack<int[]> stack = new Stack<int[]>();
            int[] item = new int[2];
            stack.Push(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (stack.Count > 0)
                {
                    item = stack.Peek();

                    if (item[1] >= intervals[i][0])//有重复
                    {
                        item[1] = intervals[i][1] > item[1] ? intervals[i][1] : item[1];
                        stack.Pop();
                        stack.Push(item);
                    }
                    else
                    {
                        //没有重复
                        stack.Push(intervals[i]);
                    }
                }
            }
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result.ToArray();
        }

        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length <= 0) return 0;
            if (nums.Length == 1) return nums[0] == val ? 0 : 1;
            int end = nums.Length - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    while (nums[end] == val && end > i)
                    {
                        end--;
                    }
                    nums[i] = nums[end];
                    nums[end] = val;
                }
            }
            return end;
        }
        public string LicenseKeyFormatting(string S, int K)
        {
            if (string.IsNullOrEmpty(S)) return "";
            var str = S.Replace("-", "").ToUpper().Reverse();
            for (int i = 0; i < str.Count(); i++)
            {
                Console.WriteLine(i / K);
            }
            var a = 0;


            return "";

        }
        public void MoveZeroes(int[] nums)
        {


        }
        public int[] SortArrayByParityII(int[] A)
        {
            if (A.Length <= 0) return new int[] { };
            int[] arr = new int[A.Length];
            int z = 0;
            int j = 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    arr[z] = A[i];
                    z += 2;
                }
                else
                {
                    arr[j] = A[i];
                    j += 2;
                }

            }
            return arr;
        }


        public int PeakIndexInMountainArray(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < A[i + 1])
                {

                }
                else
                {
                    return i;
                }
            }

            return 0;
        }

        public int[] SortArrayByParity(int[] A)
        {
            if (A.Length <= 0) return new int[] { };
            int[] arr = new int[A.Length];
            int z = 0;
            int j = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    arr[z] = A[i];
                    z++;
                }
                else
                {
                    arr[A.Length - 1 - j] = A[i];
                    j++;
                }

            }
            return arr;
        }
        public int HammingDistance(int x, int y)
        {

            var n = x ^ y;
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= n - 1;
            }
            return count;
        }
        public string ToLowerCase(string str)
        {
            string result = "";
            foreach (var item in str)
            {
                if (item >= 'A' && item <= 'Z')
                {
                    result += (char)(item + 32);
                }
                else
                {
                    result += item;
                }
            }
            return result;
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return null;
            }
            TreeNode t3 = new TreeNode((t1 == null ? 0 : t1.val) + (t2 == null ? 0 : t2.val));
            t3.left = MergeTrees(t1?.left, t2?.left);
            t3.right = MergeTrees(t1?.right, t2?.right);
            return t3;
        }
        public int NumJewelsInStones(string J, string S)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var item in J)
            {
                dict.Add(item, 1);
            }
            int count = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (dict.ContainsKey(S[i]))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// 跳跃游戏
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            if (nums.Length <= 0) return false;
            if (nums.Length == 1) return true;
            int temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (temp < i) return false;
                temp = Math.Max(temp, i + nums[i]);
                if (temp > nums.Length - 1) return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {

            return 0;

        }
        /// <summary>
        /// 打家劫舍
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums.Length <= 0) return 0;
            if (nums.Length == 1) return nums[1];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            int[] dp = new int[nums.Length];
            for (int i = 3; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i - 1] + nums[i + 1], nums[i]);

            }
            return 0;
        }
        /// <summary>
        /// 爬楼梯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            int[] dp = new int[n];
            dp[0] = 1;
            dp[1] = 2;
            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n - 1];

        }

        public void Rotate(int[][] matrix)
        {
            var temp = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    temp = matrix[i][j];

                    matrix[i][j] = matrix[matrix[i].Length - 1 - j][i];
                    matrix[matrix[i].Length - 1 - j][i] = temp;
                }
            }
        }
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] = digits[i] % 10;
                if (digits[i] != 0) return digits;
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }
        public int MaxArea(int[] height)
        {
            int maxarea = 0;
            int l = 0;
            int r = height.Length - 1;

            while (l < r)
            {
                var min = height[l] < height[r] ? height[l] : height[r];
                maxarea = maxarea < min * (r - l) ? min * (r - l) : maxarea;
                if (height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return maxarea;
        }

        public int Test(int[] nums)
        {
            nums[0] = 1;
            nums[1] = 2;
            var n = nums;
            return 0;
        }
        public int RemoveDuplicates(int[] nums)
        {
            int start = 0;
            int end = 1;
            int result = 0;
            if (nums.Length <= 0) return result;
            for (int i = 0; i < nums.Length; i++)
            {
                while (end < nums.Length && nums[start] == nums[end])
                {
                    end++;
                }
                if (end > nums.Length - 1)
                {
                    break;
                }
                start++;
                result++;
                nums[start] = nums[end];
                i = start;
            }
            return result + 1;

        }
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            List<int> item = new List<int>();
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();

            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
            int d = 0;
            while (queue.Count > 0)
            {
                var kv = queue.Dequeue();
                var preious = kv.Key;
                var depth = kv.Value;
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

                Console.WriteLine(preious.val + "==" + depth);
                if (preious.left != null)
                {

                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.left, depth + 1));

                }
                if (preious.right != null)
                {

                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.right, depth + 1));
                }

            }
            result.Add(item.ToArray());
            return result.Reverse().ToList();
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            List<int> item = new List<int>();
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();

            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
            int d = 0;
            while (queue.Count > 0)
            {
                var kv = queue.Dequeue();
                var preious = kv.Key;
                var depth = kv.Value;
                if (depth == result.Count)
                {
                    item.Add(preious.val);
                }
                else
                {
                    if (result.Count % 2 == 0)
                    {
                        result.Add(item.ToArray());
                    }
                    else
                    {
                        result.Add(item.ToArray().Reverse().ToArray());
                    }
                    item.Clear();
                    item.Add(preious.val);
                }

                Console.WriteLine(preious.val + "==" + depth);
                if (preious.left != null)
                {

                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.left, depth + 1));

                }
                if (preious.right != null)
                {

                    queue.Enqueue(new KeyValuePair<TreeNode, int>(preious.right, depth + 1));
                }

            }
            if (result.Count % 2 == 0)
            {
                result.Add(item.ToArray());
            }
            else
            {
                result.Add(item.ToArray().Reverse().ToArray());
            }
            return result;
        }
        int count = 0;
        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            count++;
            CountNodes(root.left);
            CountNodes(root.right);
            return count;
        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            List<Stack<TreeNode>> result = new List<Stack<TreeNode>>();
            Stack<TreeNode> item = new Stack<TreeNode>();
            Generator(root, result, item, q, p);
            TreeNode tn = new TreeNode(root.val);
            if (result.Count == 1)
            {

            }
            var qr = result[0].Pop();
            var pr = result[1].Pop();
            while (qr == pr)
            {
                tn = qr;
                qr = result[0].Pop();
                pr = result[1].Pop();
            }

            return tn;
        }

        public void Generator(TreeNode root, List<Stack<TreeNode>> result, Stack<TreeNode> item, TreeNode p, TreeNode q)
        {
            if (root == null) return;
            item.Push(root);
            if (root.left == null)
            {
                if (IsExist(new Stack<TreeNode>(item), q, p))
                {
                    result.Add(new Stack<TreeNode>(item));
                }
            }
            Generator(root.left, result, item, q, p);
            Generator(root.right, result, item, q, p);
            item.Pop();
        }
        public bool IsExist(Stack<TreeNode> item, TreeNode q, TreeNode p)
        {
            while (item.Count > 0)
            {
                var curr = item.Pop();
                if (curr == p || curr == q)
                {
                    return true;
                }
            }
            return false;
        }
        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict.Remove(nums[i]);
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            return dict.Keys.FirstOrDefault();
        }




        public string ReverseWords(string s)
        {
            string result = "";
            if (string.IsNullOrEmpty(s)) return result;

            var arr = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    result += ReverseString(arr[i]);
                }
                else
                {
                    result += ReverseString(arr[i]) + " ";
                }

            }
            return result;
        }
        public string ReverseString(string s)
        {
            var result = "";
            for (int i = 0; i < s.Length; i++)
            {
                var temp = s[s.Length - 1 - i];
                result += temp;
            }
            return result;
        }
        public void ReverseString1(char[] s)
        {

            for (int i = 0; i < s.Length / 2; i++)
            {
                var temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }

        }
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> item = new List<int>();
            Find(candidates, target, result, item);
            return result;
        }
        public void Find(int[] candidates, int target, IList<IList<int>> result, IList<int> item)
        {
            if (target == item.Sum())
            {
                result.Add(item.ToArray());
                item.Clear();
                return;
            }
            for (int i = 0; i < candidates.Length; i++)
            {
                if (target % candidates[i] == 0)
                {
                    //item.Add(candidates[i]);
                    //for (int j = 0; j < target / candidates[i]; j++)
                    //{
                    //    item.Add(candidates[i]);
                    //    result.Add(item.ToArray());
                    //}

                    Console.WriteLine("没有余数 算一个");
                    return;
                }
                if (candidates[i] > target)
                {
                    Console.WriteLine("比目标值大了，不用继续了");
                    return;
                }
                Console.WriteLine($"放当前值{candidates[i]}");
                item.Add(candidates[i]);
                Find(candidates, target, result, item);
                item.Remove(candidates[i]);
                Console.WriteLine($"除去当前值{candidates[i]}");
                Find(candidates, target, result, item);
            }

        }
        /// <summary>
        /// 给定一个二叉树，原地将它展开为链表。
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.val);
            TreeNode result = new TreeNode(root.val);
            if (root.left != null)
            {
                Flatten(root.left);
            }
            if (root.right != null)
            {
                Flatten(root.right);
            }
        }
        /// <summary>
        /// 寻找两个有序数组的中位数
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {



            return 0;
        }
        /// <summary>
        ///  最长回文子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length == 1) return s;
            int start = 0;
            int index = 1;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                string str = s[i].ToString();
                while (index < s.Length)
                {
                    if (s[start] == s[index])
                    {
                        var r = s.Substring(start, index - start);
                        for (int j = 0; j < r.Length; j++)
                        {
                            if (s[j] == s[r.Length - 1 - j])
                            {

                            }
                        }
                    }
                }
            }
            while (start <= index)
            {
                string str = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[start] != s[index])
                    {
                        str += s[index];
                        Console.WriteLine(str);
                        index++;
                    }
                    else
                    {
                        Console.WriteLine("碰到相等的了" + str);
                    }
                }
            }
            return null;
        }

        public int Search(int[] nums, int target)
        {
            if (nums.Length <= 0) return 0;
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            if (target < nums[0]) return -1;
            if (target > nums[nums.Length - 1]) return -1;

            while (end >= start)
            {
                int mid = (end + start) / 2;
                if (target == nums[mid])
                {
                    return index = mid;
                }
                else if (target < nums[mid])
                {
                    if (target > nums[mid - 1])
                    {
                        return index = -1;
                    }
                    end = mid - 1;

                }
                else if (target > nums[mid])
                {
                    if (target < nums[mid + 1])
                    {
                        return index = -1;
                    }
                    start = mid + 1;
                }
            }
            return index;
        }
        /// <summary>
        ///  搜索插入位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length <= 0) return 0;
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            if (target < nums[0]) return 0;
            if (target > nums[nums.Length - 1]) return nums.Length;

            while (end >= start)
            {
                int mid = (end + start) / 2;
                if (target == nums[mid])
                {
                    return index = mid;
                }
                else if (target < nums[mid])
                {
                    if (target > nums[mid - 1])
                    {
                        return index = mid;
                    }
                    end = mid - 1;
                }
                else if (target > nums[mid])
                {
                    if (target < nums[mid + 1])
                    {
                        return index = mid + 1;
                    }
                    start = mid + 1;
                }
            }
            return index;
        }
        /// <summary>
        /// 所有可能的全排列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();


            return result;
        }
        public void GetResult(IList<IList<int>> result, int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                GetResult(result, nums);
            }
        }
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
            height = new int[] { 4, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 5 };
            bool flag = true;
            List<int> list = new List<int>();
            Stack<int> stack = new Stack<int>();
            Stack<int> stepStack = new Stack<int>();

            int temp = 0;
            int step = 0;
            int totalWater = 0;
            for (int i = 0; i < height.Length - 1; i++)
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
                                Console.WriteLine($"栈顶{stack.Peek()} 小于要入栈的{height[i]}这个时候要注意了。。。");
                                var tempStackTop = stack.Pop();
                                //   var t = stack.Peek() * height[i] - (list.Sum() + tempStackTop);
                                //  Console.WriteLine($"总水量{t}");
                            }
                        }
                        Console.WriteLine($"入栈元素={height[i]},,当前水量{totalWater}");
                        stepStack.Push(step);
                        stack.Push(height[i]);
                        step = 0;
                        temp = 0;
                    }
                    else
                    {
                        step++;
                        temp = height[i] + temp;
                        list.Add(height[i]);
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
                        list.Add(height[i]);
                    }
                    flag = true;
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
