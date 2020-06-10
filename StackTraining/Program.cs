using System;
using System.Collections.Generic;
using System.Linq;

namespace StackTraining
{
    class Program
    {
        static void QuickSort(int[] arr, int low, int hight)
        {

            if (low < hight)
            {
                var index = GetIndex(arr, low, hight);
                QuickSort(arr, 0, index - 1);
                QuickSort(arr, index + 1, hight);
            }

        }
        static int GetIndex(int[] arr, int low, int hight)
        {
            int temp = arr[low];
            while (low < hight)
            {
                while (low < hight && arr[hight] >= temp)
                {
                    hight--;
                }
                arr[low] = arr[hight];
                while (low < hight && arr[low] <= temp)
                {
                    low++;
                }
                arr[hight] = arr[low];

            }
            arr[low] = temp;

            return low;
        }
        static void RandomTest()
        {
            //这个比如是100个
            int[] arrs = { 1, 4, 5, 7, 8, 2, 10 };//少了3，6，9的
            int[] tempArrs = new int[10];//原来里面应该有10个的。


            for (int i = 0; i < arrs.Length; i++)
            {
                int num = arrs[i];//第一次取出来是1，给他放到应该在的位置。
                tempArrs[num - 1] = num;
            }
            for (int i = 0; i < tempArrs.Length; i++)
            {
                if (tempArrs[i] == 0)
                {
                    Console.WriteLine($"少了{i + 1}");
                }
            }
        }
        static void Test()
        {
            string str = "abccddeeef";
            int[] arrs = new int[str.Length];//这个是一个标记数组
            for (int i = 0; i < str.Length; i++) //循环每个字母
            {
                for (int j = 0; j < str.Length; j++)//循环每个字母，和第一次循环的字母做比较
                {
                    if (j != i)//如果 第一次循环和第二个循环是一个字母，就不计算
                    {
                        if (str[i] == str[j])//如果有重复的，下表就弄成1
                        {
                            arrs[i] = 1;
                        }
                    }
                }
            }
            int index = 1;
            char resultChar = ' ';
            for (int i = 0; i < arrs.Length; i++)//找标记里面的
            {
                if (arrs[i] == 0)//第一个下标是0的，也就是第一个没有重复的数字
                {
                    resultChar = str[i];//他的位置对应的字母就是想要的
                    index = i + 1; //这个是想要的位置
                    break;
                }
            }
            Console.WriteLine($"只出现一次的字母是{resultChar},位置是：{index}");
        }
        static void Main(string[] args)
        {
            #region MyRegion
            //RandomTest();
            //Test();
            //string str = "abaccddeeef";




            //Dictionary<char, int> dict = new Dictionary<char, int>();
            //char resultChar = ' ';
            //int index = 1; //存位置
            //               //这个循环 可以计算出 每个字母出现了几次
            //for (int z = 0; z < str.Length; z++)
            //{
            //    // 包含两个以上的 就不是符合条件的
            //    if (dict.ContainsKey(str[z]))
            //    {
            //        dict[str[z]]++;
            //    }
            //    else//第一次加进来的
            //    {
            //        dict.Add(str[z], 1);
            //    }
            //}
            ////这个循环取出第一个出现一次的
            //foreach (var item in dict)
            //{
            //    if (item.Value == 1)
            //    {
            //        resultChar = item.Key;
            //        break;
            //    }
            //}
            ////这个循环去找这个字母的位置
            //for (int z = 0; z < str.Length; z++)
            //{
            //    if (str[z] == resultChar)
            //    {
            //        index = z + 1;
            //        break;
            //    }
            //}
            //Console.WriteLine($"只出现一次的字母是{resultChar},位置是：{index}");

            //int a = 16 + 32 + 64 + 128;
            //Console.WriteLine(a >> 4);
            //Console.ReadKey();
            #endregion

            //string str = "1222233344555555";

            //int firstIndex = 0;
            //int lastIndex = 1;


            //while (lastIndex < str.Length)
            //{

            //    if (str[firstIndex] == str[lastIndex])
            //    {
            //        if ((lastIndex - firstIndex - 1) % 2 == 0)
            //        {
            //            //  Console.WriteLine($"删除这个元素 索引是{lastIndex}");

            //        }
            //        else
            //        {
            //            Console.Write($"{str[lastIndex]}.");

            //        }
            //        lastIndex++;
            //    }
            //    else
            //    {
            //        Console.Write($"{str[firstIndex]}.");

            //        firstIndex = lastIndex;
            //        lastIndex++;
            //    }
            //}

            //#region 字典法
            //Dictionary<int, int> dict = new Dictionary<int, int>();
            //for (int k = 0; k < str.Length; k++)
            //{
            //    int num = str[k];
            //    if (dict.ContainsKey(num))
            //    {
            //        dict[num]++;
            //    }
            //    else
            //    {
            //        dict.Add(num, 1);
            //    }
            //}
            //for (int k = 0; k < str.Length; k++)
            //{
            //    if (!(dict[str[k]] % 2 == 0))
            //    {
            //        Console.Write(str[k]);
            //    }

            //}
            //#endregion
            //  Console.ReadKey();
            Solution solution = new Solution();
            //  solution.LetterCombinations("234");
            //  var b = solution.IsUnique("iluhwpyk");
            //  var resu = solution.SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            //ListNode headNode = new ListNode(1);
            //var h4 = new ListNode(5);
            //var h3 = new ListNode(4);
            //var h2 = new ListNode(3);
            //var h1 = new ListNode(2);
            //headNode.next = h1;
            //h1.next = h2;
            //h2.next = h3;
            //h3.next = h4;
            //var result = Solution.KthToLast(headNode, 2);
            //Console.WriteLine(result);

            int i = 0;
            //Person zhangsan = new Man("张三", 5);
            //Person xiaofang = new Woman("小芳", 5);
            //zhangsan.GetPartner(xiaofang);
            //xiaofang.GetPartner(zhangsan);
            //Console.ReadKey();
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(8);
            TreeNode node9 = new TreeNode(9);
            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;

            Solution s = new Solution();
            s.PrevTreeNode(node1);

            //   s.Flatten(node1);
            Console.WriteLine("遍历完成");
            Console.ReadKey();
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
            // var arrs = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
            //542

            //  var b = s.IsValidBST(node1);
            //  var ii = s.TwoSum(arrs, 542);
            //[[3,9],[7,12],[3,8],[6,8],[9,10],[2,9],[0,9],[3,9],[0,6],[2,8]]
            //var testData = new int[][] { new int[] { 3,9 }, new int[] { 7, 12}, new int[] { 3, 8 },
            //    new int[] { 6, 8},
            //    new int[] { 9, 10},
            //    new int[] { 2, 9},
            //    new int[] { 0, 9} ,
            //    new int[] { 3, 9},
            //    new int[] { 0, 6},
            //    new int[] { 2, 8}};

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
            s.Rotate(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 }, new int[] { 13, 14, 15, 16 } });
            // var r = s.CanJump(new int[] { 5, 9, 3, 2, 1, 0, 2, 3, 2, 1, 0, 0 });//2,3,1,1,4
            //   var r = s.CanJump(new int[] { 3, 2, 1, 0, 4 });//2,3,1,1,4
            ///  var r = s.NumJewelsInStones("aA", "aAAbbbb");
            //  var r = s.RemoveElement(new int[] { 3, 2, 2, 3 }, 3);
            //  Console.WriteLine(r);
            // Console.WriteLine(s.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));

            //    var res = s.ShipWithinDays(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5);
            var res = s.DetectCapitalUse("AbcdF");

            Console.WriteLine("----------------结果是" + res);
            Console.ReadKey();
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

            //  var res = s.LongestCommonPrefix(new string[] { "flower", "flow", "flight" });

            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 2));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 5));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 7));
            //Console.WriteLine(s.Search1(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 8));

            //  var res = s.TwoSum1(new int[] { -1, 0, 1, 2, -1, -4 },4);

            //var res = s.SearchRange(new int[] { 1 }, 1);
            //for (int i = 0; i < res.Length; i++)
            //{
            //    Console.WriteLine(res[i]);
            //}
            //   var res = s.FindMin(new int[] { 1 });
            //   Console.WriteLine(res);

            //  Console.WriteLine(s.Search21(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0));

            //for (int i = 1; i <= 100; i++)
            //{
            //    Console.WriteLine($"{i}=" + s.IntToRoman(i));
            //}
            //var res = s.FindWords(new string[] { "Hello", "Alaska", "Dad", "Peace" });

            //for (int i = 0; i < res.Length; i++)
            //{
            //    Console.WriteLine(res[i]);
            //}
            //    var res = s.MergeSort(new int[] { 6, 5, 7, 8, 3, 2, 4, 1 });
            //  s.MoveZeroes(new int[] { 0, 0 });
            //var res = s.DiameterOfBinaryTree(node1);
            //Console.WriteLine(res);
            //  Console.WriteLine(s.MajorityElement(new int[] { 3, 2, 3 }));
            Console.ReadKey();
        }
    }

    public class Solution
    {

        public bool DetectCapitalUse(string word)
        {
            if (word.Length <= 1)
            {
                return true;
            }

            // 如果首字母是小写
            if (word[0] >= 'a' && word[0] <= 'z')
            {

                for (int i = 1; i < word.Length; i++)
                {
                    if (!(word[i] >= 'a' && word[i] <= 'z')) return false;
                }
            }
            else
            {
                if (word[1] >= 'a' && word[1] <= 'z')
                {
                    for (int i = 1; i < word.Length; i++)
                    {
                        if (!(word[i] >= 'a' && word[i] <= 'z')) return false;
                    }
                }
                else
                {
                    for (int i = 1; i < word.Length; i++)
                    {
                        if (!(word[i] >= 'A' && word[i] <= 'Z')) return false;
                    }
                }

            }

            return true;
        }
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            bool[] bs = new bool[candies.Length];
            int max = candies.Max();
            for (int i = 0; i < candies.Length; i++)
            {
                if (max <= candies[i] + extraCandies)
                {
                    bs[i] = true;
                }
            }
            return bs;
        }

        public string GenerateTheString(int n)
        {
            if (n % 2 == 0)
            {
                return (new string('a', n - 1)) + "b";
            }
            return new string('a', n);
        }
        public int[] SortedSquares(int[] A)
        {
            int[] B = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                B[i] = A[i] * A[i];
            }
            Array.Sort(B);
            return B;
        }
        /// <summary>
        /// 在 D 天内送达包裹的能力
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="D"></param>
        /// <returns></returns>
        public int ShipWithinDays(int[] weights, int D)
        {
            int lo = weights.Max();
            int hi = weights.Sum() + 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (canShip(weights, D, mid))
                {
                    hi = mid;

                }
                else
                {
                    lo = mid + 1;
                }

            }
            return lo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="D">表示运输天数</param>
        /// <param name="K">这艘船的承载量</param>
        /// <returns></returns>
        private bool canShip(int[] weights, int D, int K)
        {
            int curr = K;// cur 表示当前船可用承载量
            foreach (var weight in weights)
            {
                if (weight > K) return false;
                if (curr < weight)
                {
                    curr = K;
                    D--;
                }
                curr -= weight;
            }
            return D > 0;
        }
        /// <summary>
        /// 电话号码的字母组合
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> output = new List<string>();
            Dictionary<char, string> dict = new Dictionary<char, string>();
            dict.Add('2', "abc");
            dict.Add('3', "def");
            dict.Add('4', "ghi");
            dict.Add('5', "jkl");
            dict.Add('6', "mno");
            dict.Add('7', "pqrs");
            dict.Add('8', "tuv");
            dict.Add('9', "wxyz");
            // abc, def,jhi
            if (digits.Length != 0)
            {
                Backtrack(output, dict, "", digits);
            }
            return output;

        }
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="output"></param>
        /// <param name="phone"></param>
        /// <param name="combination">组合</param>
        /// <param name="next_digits">下一个数字</param>
        public void Backtrack(IList<string> output, Dictionary<char, string> phone, string combination, string next_digits)
        {
            if (next_digits.Length == 0)
            {
                output.Add(combination);
            }
            else
            {
                char digit = Convert.ToChar(next_digits.Substring(0, 1));
                string letters = phone[digit];
                for (int i = 0; i < letters.Length; i++)
                {
                    Backtrack(output, phone, combination + letters[i], next_digits.Substring(1));
                }
            }

        }
        public string FindLongestWord(string s, IList<string> d)
        {
            foreach (var item in d)
            {
                int first = 0;
                int last = 0;
                while (last <= item.Length - 1)
                {
                    if (s[first] == item[last])
                    {
                        first++;
                        last++;
                    }
                    else
                    {

                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 面试题 08.11. 硬币
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int WaysToChange(int n)
        {
            if (n > 25)
            {
                WaysToChange(n - 25);
            }
            else if (n > 10)
            {

            }
            else if (n > 5)
            {

            }
            else if (n > 1)
            {

            }
            return 0;
        }

        /// <summary>
        /// 面试题 01.02. 判定是否互为字符重排
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckPermutation(string s1, string s2)
        {
            int[] arr1 = new int[100];
            int[] arr2 = new int[100];
            for (int i = 0; i < s1.Length; i++)
            {
                arr1[s1[i] - 65]++;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                arr2[s2[i] - 65]++;
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 面试题 01.01. 判定字符是否唯一
        /// </summary>
        /// <param name="astr"></param>
        /// <returns></returns>
        public bool IsUnique(string astr)
        {
            int[] arr = new int[100];
            for (int i = 0; i < astr.Length; i++)
            {
                char c = astr[i];
                if (arr[c - 65] >= 1)
                {
                    return false;
                }
                else
                {
                    arr[c - 65]++;
                }
            }
            return true;
        }
        /// <summary>
        /// 面试题 04.02. 最小高度树
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;
            TreeNode node = new TreeNode(nums[nums.Length / 2]);
            var leftNums = new int[nums.Length / 2];
            var rightNums = new int[nums.Length - nums.Length / 2 - 1];
            for (int i = 0; i < leftNums.Length; i++)
            {
                leftNums[i] = nums[i];
            }
            for (int i = 0; i < rightNums.Length; i++)
            {
                rightNums[i] = nums[nums.Length / 2 + i + 1];
            }
            node.left = SortedArrayToBST(leftNums);
            node.right = SortedArrayToBST(rightNums);
            return node;
        }
        /// <summary>
        /// 面试题 02.02. 返回倒数第 k 个节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int KthToLast(ListNode head, int k)
        {

            Stack<ListNode> stack = new Stack<ListNode>();
            while (head != null)
            {
                Console.WriteLine(head.val);
                stack.Push(head);
                head = head.next;
            }
            ListNode node = null;
            while (k > 0)
            {
                node = stack.Pop();
                k--;
            }
            return node.val;
        }
        /// <summary>
        /// 面试题 02.03. 删除中间节点
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        /// <summary>
        /// 众数
        /// </summary>
        Dictionary<int, int> dict = new Dictionary<int, int>();
        public int MajorityElement(int[] nums)
        {
            foreach (var item in nums)
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
            foreach (var item in dict)
            {
                if (item.Value > nums.Length / 2) return item.Key;
            }
            return 0;
        }
        /// <summary>
        /// 丑数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsUgly(int num)
        {
            if (num == 0) return false;
            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                }
                else if (num % 3 == 0)
                {
                    num = num / 3;
                }
                else if (num % 5 == 0)
                {
                    num = num / 5;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 二叉树的直径
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + TreeMaxDepth(root.left) + TreeMaxDepth(root.right);
        }
        public int TreeMaxDepth(TreeNode root)
        {
            List<int> result = new List<int>();
            result.Add(0);
            Stack<int> stack = new Stack<int>();
            DepthSearch(root, stack, result);
            return result.Max();
        }
        public void DepthSearch(TreeNode root, Stack<int> stack, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            stack.Push(root.val);
            if (root.left == null && root.right == null)
            {
                result.Add(stack.ToArray().Length);
            }
            DepthSearch(root.left, stack, result);
            DepthSearch(root.right, stack, result);

            stack.Pop();
        }
        /// <summary>
        /// 移动0
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            if (nums.Length <= 0) return;
            int i = 0;
            int begin = 0;
            int end = nums.Length - 1;
            while (begin < end)
            {
                if (nums[begin] == 0)
                {
                    i = begin;
                    while (i < nums.Length - 1)
                    {
                        nums[i] = nums[i + 1];
                        i++;
                    }
                    while (nums[end] == 0 && end > begin)
                    {
                        end--;
                    }
                    nums[nums.Length - 1] = 0;
                }
                else
                {
                    begin++;
                }
            }
        }
        /// <summary>
        /// 翻转二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            InvertTree1(root);
            return root;
        }
        private void InvertTree1(TreeNode root)
        {
            if (root == null) return;
            var temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTree1(root.left);
            InvertTree1(root.right);
        }
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] MergeSort(int[] array)
        {
            if (array.Length < 2) return array;
            int mid = array.Length / 2;
            int[] left = array.Take(mid).ToArray();
            int[] right = array.Skip(mid).Take(array.Length - mid).ToArray();
            var l = MergeSort(left);
            var r = MergeSort(right);
            var result = Merge(l, r);
            return result;
        }
        public static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0;
            int j = 0;
            for (int index = 0; index < result.Length; index++)
            {
                if (i >= left.Length)
                {
                    result[index] = right[j++];
                }
                else if (j >= right.Length)
                {
                    result[index] = left[i++];
                }
                else if (left[i] > right[j])
                {
                    result[index] = right[j++];
                }
                else
                {
                    result[index] = left[i++];
                }
            }
            return result;
        }
        public string[] FindWords(string[] words)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("q", 1);
            dict.Add("w", 1);
            dict.Add("e", 1);
            dict.Add("r", 1);
            dict.Add("t", 1);
            dict.Add("y", 1);
            dict.Add("u", 1);
            dict.Add("i", 1);
            dict.Add("o", 1);
            dict.Add("p", 1);
            dict.Add("a", 2);
            dict.Add("s", 2);
            dict.Add("d", 2);
            dict.Add("f", 2);
            dict.Add("g", 2);
            dict.Add("h", 2);
            dict.Add("j", 2);
            dict.Add("k", 2);
            dict.Add("l", 2);


            dict.Add("z", 3);
            dict.Add("x", 3);
            dict.Add("c", 3);
            dict.Add("v", 3);
            dict.Add("b", 3);
            dict.Add("n", 3);
            dict.Add("m", 3);
            List<string> res = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                int j = 0;
                int temp = dict[words[i][j].ToString().ToLower()];


                while (temp == dict[words[i][j].ToString().ToLower()])
                {
                    temp = dict[words[i][j].ToString().ToLower()];
                    j++;
                }
                res.Add(words[i]);
            }
            return res.ToArray();
        }
        //public IList<string> LetterCombinations(string digits)
        //{
        //    Dictionary<int, string> dict = new Dictionary<int, string>();
        //    List<int> temp = new List<int>();
        //    dict.Add(2, "abc");
        //    dict.Add(3, "def");
        //    dict.Add(4, "ghi");
        //    dict.Add(5, "jkl");
        //    dict.Add(6, "mno");
        //    dict.Add(7, "pqrs");
        //    dict.Add(8, "tuv");
        //    dict.Add(9, "wxyz");
        //    for (int i = 0; i < digits.Length; i++)
        //    {
        //        if (!temp.Contains(digits[i]))
        //        {
        //            temp.Add(digits[i]);
        //        }
        //    }

        //    return null;
        //}
        public string IntToRoman(int num)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "I");
            dict.Add(4, "IV");
            dict.Add(5, "V");
            dict.Add(9, "IX");
            dict.Add(10, "X");
            dict.Add(40, "XL");
            dict.Add(50, "L");
            dict.Add(90, "XC");
            dict.Add(100, "C");
            dict.Add(400, "CD");
            dict.Add(500, "D");
            dict.Add(900, "CM");
            dict.Add(1000, "M");

            if (dict.ContainsKey(num)) return dict[num];
            string str = "";
            var a = dict.Where(i => i.Key <= num).Max(b => b.Key);
            str += dict[a];
            var temp = num - a;
            while (temp > 0)
            {
                a = dict.Where(i => i.Key <= temp).Max(b => b.Key);
                temp = temp - a;
                str += dict[a];
            }
            return str;
        }
        public bool Search21(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target) return true;
                if (nums[mid] < nums[end])//右侧递增
                {
                    if (nums[mid] > target)
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else//左侧递增
                {
                    if (nums[mid] > target)
                    {
                        end = mid - 1;

                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return false;
        }
        public int[] FindErrorNums(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] res = new int[2];
            int sum = 0;
            //1,2,4,4,5
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 1);
                    sum += nums[i];
                }
                else
                {
                    res[0] = nums[i];
                }
            }
            var num = ((1 + nums.Length) * nums.Length / 2) - sum;
            res[1] = num;
            return res;
        }
        /// <summary>
        /// 寻找旋转排序数组中的最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums.Length == 0) return -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                if (nums[start] > nums[end])
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            return nums[start];
        }

        /// <summary>
        /// 在排序数组中查找元素的第一个和最后一个位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            /*
             * 思路，双指针。
             * 
             * 
             * 
             */
            if (nums.Length == 0) return new int[] { -1, -1 };
            int start = 0;
            int end = nums.Length - 1;
            int nums1 = -1;
            int nums2 = -1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    nums1 = mid;
                    nums2 = mid;
                    while (nums1 > start && nums[nums1 - 1] == target)
                    {
                        nums1 = nums1 - 1;
                    }
                    Console.WriteLine("index1=" + nums1);
                    while (nums2 < end && nums[nums2 + 1] == target)
                    {
                        nums2 = nums2 + 1;
                    }
                    Console.WriteLine("index2=" + nums2);
                    return new int[] { nums1, nums2 };
                }
                if (target < nums[mid])
                {
                    end = mid - 1;
                }
                if (target > nums[mid])
                {
                    start = mid + 1;
                }
            }
            return new int[] { nums1, nums2 };
        }
        /// <summary>
        /// 三数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> list = new List<int>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            list.Add(nums[i]);
                            list.Add(nums[j]);
                            list.Add(nums[k]);
                            result.Add(list.ToArray());
                            list.Clear();
                        }
                    }
                }
            }


            return result;
        }
        /// <summary>
        /// 搜索旋转排序数组 II
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search2(int[] nums, int target)
        {

            return false;
        }
        /// <summary>
        /// 搜索旋转排序数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search1(int[] nums, int target)
        {
            /*
             思路：1.根据中间位置的数字和最后一个位置的数字判断哪边是单调递增的
                    2.判断target在不在单调递增区间里面
             */
            if (nums.Length == 0) return -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target) return mid;
                if (nums[mid] < nums[end])
                {
                    //右侧是单调递增的
                    if (target > nums[mid] && target <= nums[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
                else
                {
                    //左侧是单调递增的
                    if (target >= nums[start] && target < nums[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// 二叉树的堂兄弟节点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCousins(TreeNode root, int x, int y)
        {
            /*
             1.声明一个元祖列表 存放 当前节点，当前层数，当前的父级节点
             */
            Queue<Tuple<TreeNode, int, TreeNode>> queue = new Queue<Tuple<TreeNode, int, TreeNode>>();
            List<Tuple<TreeNode, int, TreeNode>> result = new List<Tuple<TreeNode, int, TreeNode>>();
            queue.Enqueue(new Tuple<TreeNode, int, TreeNode>(root, 0, null));
            while (queue.Count > 0)
            {
                var tuple = queue.Dequeue();

                var node = tuple.Item1;
                var count = tuple.Item2;
                var parentNode = tuple.Item3;
                result.Add(new Tuple<TreeNode, int, TreeNode>(node, count, parentNode));
                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int, TreeNode>(node.left, count + 1, node));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int, TreeNode>(node.right, count + 1, node));
                }
            }
            var t1 = result.Where(t => t.Item1.val == x).FirstOrDefault();
            var t2 = result.Where(t => t.Item1.val == y).FirstOrDefault();
            return t1.Item3 != t2.Item3 && t1.Item2 == t2.Item2;
        }
        /// <summary>
        /// 给定一个二叉树，在树的最后一行找到最左边的值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            /*
             思路：
             1.层次遍历
             2.记录遍历层数
             3.如果是每层的第一个元素，放到stack里面
             end.最后一个放的就是最后一层的第一个元素
             */
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            Stack<KeyValuePair<int, TreeNode>> stack = new Stack<KeyValuePair<int, TreeNode>>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
            stack.Push(new KeyValuePair<int, TreeNode>(0, root));
            while (queue.Count > 0)
            {
                var keyValuePair = queue.Dequeue();

                var node = keyValuePair.Key;
                var count = keyValuePair.Value;
                if (stack.Peek().Key != count)
                {
                    stack.Push(new KeyValuePair<int, TreeNode>(count, node));
                }
                Console.WriteLine($"val = {node.val},count={count}");
                if (node.left != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(node.left, count + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(node.right, count + 1));
                }
            }

            return stack.Peek().Value.val;
        }
        public string LongestCommonPrefix(string[] strs)
        {
            Dictionary<int, char> dict = new Dictionary<int, char>();

            int i = 0;
            int j = 0;
            char temp = strs[0][0];
            var s = strs[i][j];


            while (temp == s && i < strs.Length)
            {
                i++;
            }


            return "";
        }
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            var arr = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return arr[arr.Length - 1].Length;
        }

        public int TitleToNumber(string s)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("A", 1);
            dict.Add("B", 2);
            dict.Add("C", 3);
            dict.Add("D", 4);
            dict.Add("E", 5);
            dict.Add("F", 6);
            dict.Add("G", 7);
            dict.Add("H", 8);
            dict.Add("I", 9);
            dict.Add("J", 10);
            dict.Add("K", 11);
            dict.Add("L", 12);
            dict.Add("M", 13);
            dict.Add("N", 14);
            dict.Add("O", 15);
            dict.Add("P", 16);
            dict.Add("Q", 17);
            dict.Add("R", 18);
            dict.Add("S", 19);
            dict.Add("T", 20);
            dict.Add("U", 21);
            dict.Add("V", 22);
            dict.Add("W", 23);
            dict.Add("X", 24);
            dict.Add("Y", 25);
            dict.Add("Z", 26);
            double res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                res += (Math.Pow(26, s.Length - i - 1)) * dict[s[i].ToString()];
            }
            return (int)res;
        }
        /// <summary>
        /// 排序两个 列表，理解的不深入
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
        public void PrevTreeNode(TreeNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.val); //在这里输出就是后序遍历（左右根）
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
            int start = 0;
            while (start <= end)
            {
                if (nums[start] == val)
                {
                    int temp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = temp;
                    end--;
                }
                else
                {
                    start++;
                }
            }
            return end + 1;
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


            //var temp = matrix[0][0];//第一个位置 的1，先保存
            //var temp1 = matrix[0][1];//第二个位置的2，先保存
            //var temp2 = matrix[0][2];//第三个位置的3.先保存

            //matrix[0][0] = matrix[2][0];//7放到第一个位置
            //matrix[0][1] = matrix[1][0];//4放到第二个位置，

            //matrix[1][0] = matrix[2][1];//
            //matrix[1][1] = matrix[1][1];

            //matrix[2][0] = matrix[2][2];
            //matrix[2][1] = matrix[1][2];


            //matrix[0][2] = temp;//1放到第三个位置
            //matrix[1][2] = temp1;
            //matrix[2][2] = temp2;




            var temp = matrix[0][0];
            matrix[0][0] = matrix[3][0];
            var temp1 = matrix[0][1];
            matrix[0][1] = matrix[2][0];



            int first = 0;
            int last = matrix.Length;
            while (first <= last)
            {
                int[] arrs = new int[last - first];
                //把第一排 先临时存起来
                for (int i = 0; i < arrs.Length; i++)
                {
                    arrs[i] = matrix[first][i];
                }
                for (int i = 0; i < last - first; i++)
                {
                    var t = 0;
                    var num = matrix[i][0];
                    matrix[i][last - first] = num;


                }
                for (int i = 0; i < arrs.Length; i++)
                {
                    matrix[i][last - first - 1] = arrs[i];
                }
                first++;
                last--;
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
            if (root == null)
            {
                return;
            }
            Flatten(root.left);
            Flatten(root.right);
            TreeNode temp = root.right;
            root.right = root.left;
            root.left = null;
            while (root.right != null)
            {
                root = root.right;
            }
            root.right = temp;

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
            // 结果集
            IList<int> result = new List<int>();
            // 二叉树为空
            if (node == null) return result;

            int i = 0; // 层
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();

            // 根节点入队 第一层
            queue.Enqueue(new KeyValuePair<TreeNode, int>(node, i));
            int temp = 0;
            while (queue.Count > 0)
            {
                //如果队列有值
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
