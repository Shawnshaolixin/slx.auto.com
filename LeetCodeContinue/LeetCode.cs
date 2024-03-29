﻿using System;
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


        public void Rotate(int[] nums, int k)
        {
            // 当前索引
            int i = 0;
            int temp = nums[0];
            int lastTemp = nums[0];
            while (i < nums.Length)
            {

                // 新位置索引
                int index = (i + k) % nums.Length;
                temp = nums[index];
                nums[index] = lastTemp;

                lastTemp = temp;
                i = index;
                if (i==0)
                {
                    break;
                }
            }
            // 新位置索引



        }
        /// <summary>
        /// 加油站
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int[] arr = new int[gas.Length];
            for (int i = 0; i < gas.Length; i++)
            {
                arr[i] = gas[i] - cost[i];
            }

            int[] pre_arr = new int[gas.Length];
            pre_arr[0] = arr[0];
            for (int i = 1; i < gas.Length; i++)
            {
                pre_arr[i] = pre_arr[i - 1] + arr[i];
            }

            if (pre_arr[pre_arr.Length - 1] >= 0)
            {
                int minValue = pre_arr[0];
                int minIndex = 0;
                for (int i = 0; i < pre_arr.Length; i++)
                {
                    if (pre_arr[i] <= minValue)
                    {
                        minValue = pre_arr[i];
                        minIndex = i;
                    }
                }
                if (minIndex == pre_arr.Length - 1)
                {
                    return 0;
                }
                return minIndex + 1;
            }
            return -1;
        }
        /// <summary>
        /// 2682. 找出转圈游戏输家
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] CircularGameLosers(int n, int k)
        {

            int[] arr = new int[n];
            arr[0] = 1;
            int currIndex = 0;
            int i = 1;
            int lastIndex = 1;
            int index = 0;
            while (arr[index] < 2)
            {
                currIndex = (lastIndex + i * k);
                lastIndex = currIndex;
                index = (currIndex - 1) % n;

                arr[index]++;
                i++;
            }
            int count = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == 0)
                {
                    count++;
                }
            }
            index = 0;
            var result = new int[count];
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == 0)
                {
                    result[index] = j + 1;
                    index++;
                }
            }
            return result;
        }
        public void GetStopCarPositionOfMidLine2()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        var v = GetStopCarPositionOfMidLine2(i, j, k);
                        if (v == 0)
                        {

                            Console.WriteLine($"最下面虚线={ GetDesc(i)},中间实线={GetDesc(j)},最上面虚线={GetDesc(k)},result={v}");
                        }
                        if (v == 3)
                        {
                            Console.WriteLine($"最下面虚线={ GetDesc(i)},中间实线={GetDesc(j)},最上面虚线={GetDesc(k)},result={v}");

                        }
                    }
                }
            }
        }
        string GetDesc(int n)
        {
            if (n == 0)
            {
                return "未碰到";
            }
            if (n == 1)
            {
                return "进入";
            }
            if (n == 2)
            {
                return "离开";
            }
            return "";
        }
        public int GetStopCarPositionOfMidLine2(int ROBOT_XPQB_0, int ROBOT_XPQB_2, int ROBOT_XPQB_Mid)
        {


            // 如果没碰到 最下边的虚线，或者离开最上边的虚线返回 0 
            if (ROBOT_XPQB_0 == 0 || ROBOT_XPQB_Mid == 2)
            {
                return 3;
            }
            // 如果 碰到了最下边的虚线，并且没碰到中间的实现，返回 1
            if (ROBOT_XPQB_0 > 0 && ROBOT_XPQB_2 == 0)
            {
                return 1;
            }
            // 如果 离开了第一根虚线，并且进入了中间的实现 返回 2
            if (ROBOT_XPQB_0 == 2 && ROBOT_XPQB_2 == 1)
            {
                return 2;
            }
            // 如果 离开了最下边的虚线，并且没离开上面的虚线 返回 1
            if (ROBOT_XPQB_0 == 2 && ROBOT_XPQB_Mid < 2)
            {
                return 1;
            }
            // 其他情况 返回0
            return 0;
        }
        /// <summary>
        /// 722. 删除注释

        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IList<string> RemoveComments(string[] source)
        {

            int startRemoveIndex = 0;
            int endRemoveIndex = 0;
            bool isStartDel = false;
            List<string> result = new List<string>();
            for (int i = 0; i < source.Length; i++)
            {
                string resStr = "";
                var row = source[i];
                NewMethod(ref startRemoveIndex, ref endRemoveIndex, ref isStartDel, result, ref resStr, row);
            }
            return result;
        }

        private static void NewMethod(ref int startRemoveIndex, ref int endRemoveIndex, ref bool isStartDel, List<string> result, ref string resStr, string row)
        {
            if (isStartDel)
            {
                if (row.Contains("*/"))
                {
                    endRemoveIndex = row.IndexOf("*/");
                    var sEnd = row.Substring(endRemoveIndex + 2, row.Length - endRemoveIndex - 2);
                    NewMethod(ref startRemoveIndex, ref endRemoveIndex, ref isStartDel, result, ref resStr, sEnd);
                    //  resStr = sEnd;
                    if (!string.IsNullOrEmpty(sEnd))
                    {
                        result.Last();
                        sEnd = result[result.Count - 1] + sEnd;
                        result.RemoveAt(result.Count - 1);
                        result.Add(sEnd);
                    }
                    isStartDel = false;
                }
                else
                {

                }
            }
            else if (row.Contains("//") || row.Contains("/*"))
            {
                var index = row.IndexOf("//");
                var index1 = row.IndexOf("/*");
                if (index == -1)
                {
                    isStartDel = true;

                    startRemoveIndex = index1;
                    if (row.Contains("*/")) // 有结束删除符
                    {
                        endRemoveIndex = row.LastIndexOf("*/");
                        var sHead = row.Substring(0, startRemoveIndex);
                        var sEnd = row.Substring(endRemoveIndex + 2, row.Length - endRemoveIndex - 2);


                        resStr = sHead + sEnd;
                        isStartDel = false;
                    }
                    else // 没有结束删除符，后面的全部删除
                    {
                        var sHead = row.Substring(0, startRemoveIndex);
                        resStr = sHead;
                    }

                }
                else if (index1 == -1)
                {
                    var sHead = row.Substring(0, index);
                    resStr = sHead;
                }
                else
                 if (index < index1)
                {

                    var sHead = row.Substring(0, index);
                    resStr = sHead;
                }
                else
                {
                    isStartDel = true;

                    startRemoveIndex = index1;
                    if (row.Contains("*/")) // 有结束删除符
                    {
                        endRemoveIndex = row.LastIndexOf("*/");
                        if (endRemoveIndex > startRemoveIndex + 1)
                        {
                            var sHead = row.Substring(0, startRemoveIndex);
                            var sEnd = row.Substring(endRemoveIndex + 2, row.Length - endRemoveIndex - 2);
                            resStr = sHead + sEnd;
                            isStartDel = false;
                        }
                        else
                        {
                            var sHead = row.Substring(0, startRemoveIndex);
                            resStr = sHead;
                        }

                    }
                    else // 没有结束删除符，后面的全部删除
                    {
                        var sHead = row.Substring(0, startRemoveIndex);
                        resStr = sHead;
                    }
                }

            }
            else
            {
                resStr = row;
            }
            if (!string.IsNullOrEmpty(resStr))
            {
                result.Add(resStr);
            }
        }

        public int SumOfPower(int[] nums)
        {

            var list = Subsets(nums);
            int sum = 0;
            foreach (var item in list)
            {
                if (item.Count <= 0)
                {
                    continue;
                }
                sum += item.Min() * item.Max() * item.Max();
            }
            //sum = sum % (10 ^ 9 + 7);
            return sum;
        }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {

            ListNode newHead = head;
            int count = 0;
            while (newHead != null)
            {
                count++;
                newHead = newHead.next;
            }
            newHead = head;
            int newCount = 0;
            while (newHead != null)
            {
                newCount++;
                newHead = newHead.next;
                if (count / 2 == newCount)
                {
                    break;
                }
            }

            var reNode = ReverseList2(newHead);

        }
        ListNode ReverseList2(ListNode head)
        {
            ListNode preHead = null;
            ListNode bacHead = head;

            while (bacHead != null)
            {
                var temp = bacHead.next;// 下一个先存起来
                bacHead.next = preHead;// 下一个的指向上一个
                preHead = bacHead;// 上一个挪动到下一个的位置
                bacHead = temp; // 下一个挪动到 存起来的位置
            }
            return preHead;
        }
        public void SortTemp()
        {
            int[] arr = new int[] { 4, 5, 2, 1 };
            Sort(0, arr.Length - 1, arr);
            return;
        }

        public void Sort(int startIndex, int endIndex, int[] arr)
        {
            if (startIndex == endIndex - 1)
            {
                if (arr[startIndex] > arr[endIndex])
                {
                    var temp = arr[startIndex];
                    arr[startIndex] = arr[endIndex];
                    arr[endIndex] = temp;
                }

                return;
            }
            //left 
            int leftIndex = (endIndex - startIndex) / 2;
            if (startIndex < leftIndex)
            {

                Sort(startIndex, leftIndex, arr);
            }
            if (leftIndex < endIndex)
            {

                Sort(leftIndex + 1, endIndex, arr);
            }
        }
        /// <summary>
        /// 2500. 删除每行中的最大值

        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int DeleteGreatestValue(int[][] grid)
        {
            int[][] temp = new int[grid.Length][];

            for (int k = 0; k < temp.Length; k++)
            {
                temp[k] = new int[grid[k].Length];
            }
            int value = int.MinValue;
            int i = 0;
            int count = 0;
            int sum = 0;
            while (i < grid.Length && count < grid[0].Length)
            {
                var arr = grid[i];
                int max = int.MinValue;
                int maxIndex = 0;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] > max && temp[i][j] == 0)
                    {
                        max = arr[j];
                        maxIndex = j;
                    }
                }

                temp[i][maxIndex] = 1;
                if (max > value)
                {
                    value = max;
                }
                max = int.MinValue;

                i++;
                if (i == grid.Length && count < grid[0].Length)
                {
                    i = 0;
                    count++;
                    sum += value;
                    value = int.MinValue;
                }

            }
            return sum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public long[] HandleQuery(int[] nums1, int[] nums2, int[][] queries)
        {





            return null;
        }
        /// <summary>
        /// 23. 合并 K 个升序链表
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            var head = new ListNode(0);
            var temp = head;
            if (lists.Length <= 0)
            {
                return temp.next;
            }
            if (lists.Length == 1)
            {
                return lists[0];
            }
            int index = 0;
            int minValue = int.MaxValue;
            int minIndex = 0;
            bool isExist = true;
            int nuIndex = 0;
            while (isExist)
            {
                while (index < lists.Length)
                {
                    var listNode = lists[index];
                    if (listNode == null)
                    {
                        index++;
                        nuIndex++;
                        if (nuIndex == lists.Length)
                        {
                            isExist = false;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        nuIndex = 0;
                    }
                    if (minValue > listNode.val)
                    {
                        minValue = listNode.val;
                        minIndex = index;
                    }
                    index++;
                }

                if (lists[minIndex] != null)
                {
                    head.next = lists[minIndex];
                    lists[minIndex] = lists[minIndex].next;
                }

                index = 0;
                minValue = int.MaxValue;
                minIndex = 0;
                if (head != null)
                {
                    head = head.next;
                }

            }
            return temp.next;
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<List<string>> result = new List<List<string>>();

            Dictionary<char, int>[] arr = new Dictionary<char, int>[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                var str = strs[i];
                arr[i] = new Dictionary<char, int>();
                for (int j = 0; j < str.Length; j++)
                {
                    char c = str[j];
                    if (arr[i].ContainsKey(c))
                    {
                        arr[i][c]++;
                    }
                    else
                    {
                        arr[i].Add(c, 1);
                    }
                }

            }
            return null;
        }
        public int MinSubArrayLen1(int target, int[] nums)
        {
            int[] pre_sum_arr = new int[nums.Length];
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                pre_sum_arr[i] = sum;
            }
            int minLength = int.MaxValue;
            if (target > pre_sum_arr[nums.Length - 1])
            {
                return 0;
            }

            //if (target == pre_sum_arr[nums.Length - 1])
            //{
            //    return nums.Length;
            //}
            for (int i = 0; i < nums.Length; i++)
            {
                var lastSum = pre_sum_arr[nums.Length - 1 - i];
                if (lastSum >= target)
                {
                    minLength = nums.Length - i < minLength ? nums.Length - i : minLength;
                }
                else
                {
                    //  break;
                }
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    var lastSum1 = pre_sum_arr[nums.Length - i - 1 - j];
                    if (lastSum - lastSum1 >= target)
                    {
                        var count = (nums.Length - 1 - i) - (nums.Length - i - 1 - j);
                        if (minLength > count)
                        {
                            minLength = count;
                        }
                        break;
                    }
                    if (minLength == 1)
                    {
                        return minLength;
                    }
                }
            }

            return minLength;
        }
        /// <summary>
        /// 209. 长度最小的子数组
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int target, int[] nums)
        {

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jewels"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int NumJewelsInStones(string jewels, string stones)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < jewels.Length; i++)
            {

                set.Add(jewels[i]);

            }
            int count = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                if (set.Contains(stones[i]))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// 24. 两两交换链表中的节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {

            int count = 0;
            var temp = head;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            if (count == 1)
            {
                return head;
            }
            if (count == 0)
            {
                return head;
            }
            var newHead = head.next;

            ListNode currNode = newHead;
            while (head != null)
            {
                ListNode node2 = null;       //node1.next;
                ListNode node3 = null;       //node2.next;
                ListNode node4 = null;       //node3.next;
                ListNode node5 = null;       //node4.next;
                ListNode node6 = null;
                var node1 = head;
                //node5.next;
                if (node1 != null)
                {

                    node2 = node1.next;

                }
                if (node2 != null)
                {

                    node3 = node2.next;
                }
                if (node3 != null)
                {

                    node4 = node3.next;
                }
                if (node4 != null)
                {

                    node5 = node4.next;
                }
                if (node5 != null)
                {

                    node6 = node5.next;
                }
                if (node2 != null)
                {
                    node2.next = node1;
                }
                if (node1 != null)
                {
                    node1.next = node4;
                }
                if (node4 != null)
                {
                    node4.next = node3;
                }
                if (node3 != null)
                {
                    node3.next = node6;
                }

                head = node5;
                if (head == null)
                {
                    if (count % 2 == 0)
                    {
                        return newHead;
                    }
                    while (currNode != null)
                    {
                        if (currNode.next == null)
                        {
                            if (node1 != null)
                            {
                                currNode.next = node1;
                                node1 = null;

                            }
                            if (node2 != null)
                            {
                                currNode.next = node2;
                                node2 = null;

                            }
                            if (node3 != null)
                            {
                                currNode.next = node3;
                                node3 = null;

                            }
                            if (node4 != null)
                            {
                                currNode.next = node4;
                                node4 = null;
                            }
                            if (node5 != null)
                            {
                                currNode.next = node5;
                                node5 = null;
                            }
                        }
                        currNode = currNode.next;
                    }

                }
            }
            return newHead;
        }
        /// <summary>
        /// 55.跳跃游戏
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            //[2,3,1,1,4]


            if (nums.Length == 1)
            {
                return true;
            }

            var dist = GetMaxDist(nums, 0, nums[0]);


            return dist;

        }

        private bool GetMaxDist(int[] nums, int v1, int v2)
        {
            if (v1 + nums[v1] + 1 >= nums.Length)
            {
                return true;
            }

            int tempIndex = v1;
            int maxValueIndex = v1;
            int maxValue = nums[v1];
            while (v1 <= v2)
            {
                if (maxValue <= nums[v1] + v1 + 1)
                {
                    maxValue = nums[v1] + v1 + 1;
                    maxValueIndex = v1;
                }
                v1++;
            }
            var n1 = tempIndex + nums[tempIndex] + 1;
            var n2 = maxValueIndex + nums[maxValueIndex] + 1;
            if (n2 >= nums.Length)
            {
                return true;
            }
            if (n1 < n2)
            {

                return GetMaxDist(nums, maxValueIndex, nums[maxValueIndex] + maxValueIndex);
            }
            return false;
        }

        /// <summary>
        /// 6. N 字形变换
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert123(string s, int numRows)
        {
            int step = 2 * (numRows - 1);
            int hightIndex = step;
            int lowIndex = 0;
            char[] arr = new char[s.Length];
            if (numRows == 1)
            {
                return s;
            }
            int currIndex = 0;
            for (int i = 0; i < numRows; i++)
            {

                int index = i;
                arr[currIndex] = s[index];
                currIndex++;
                if (i == s.Length || currIndex == s.Length)
                {
                    break;
                }
                while (index < s.Length)
                {
                    index += hightIndex;
                    if (hightIndex > 0)
                    {
                        if (index < s.Length)
                        {
                            arr[currIndex] = s[index];
                            currIndex++;
                        }
                    }
                    if (lowIndex > 0)
                    {
                        index += lowIndex;
                        if (index < s.Length)
                        {
                            arr[currIndex] = s[index];
                            currIndex++;
                        }

                    }


                }
                hightIndex -= 2;
                lowIndex += 2;
            }
            var result = new string(arr);
            return result;
        }
        /// <summary>
        /// 874. 模拟行走机器人
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="obstacles"></param>
        /// <returns></returns>
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            int maxDistance = 0;
            int curr_x = 0;
            int curr_y = 0;
            int dir = 4; // 1：东，2：南，3：西，4：北

            Dictionary<int, HashSet<int>> dictX = new Dictionary<int, HashSet<int>>();
            Dictionary<int, HashSet<int>> dictY = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < obstacles.Length; i++)
            {
                var x1 = obstacles[i][0];
                var y1 = obstacles[i][1];
                if (dictX.ContainsKey(x1))
                {
                    dictX[x1].Add(y1);
                }
                else
                {
                    var set = new HashSet<int>();
                    set.Add(y1);
                    dictX.Add(x1, set);
                }
                if (dictY.ContainsKey(y1))
                {
                    dictY[y1].Add(x1);
                }
                else
                {
                    var set = new HashSet<int>();
                    set.Add(x1);
                    dictY.Add(y1, set);
                }
            }




            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] < 0)// -2 向左旋转90度，-1 向右旋转90度
                {
                    dir = GetDir(dir, commands[i]);
                }
                else // 表示向前一动的距离
                {
                    if (dir == 2 || dir == 4) // 南北移动 看x 有没有和我一样的
                    {
                        if (dictX.ContainsKey(curr_x))
                        {
                            // 这条路上有障碍
                            //  commands[i];//向前几步
                            int index = 1;
                            while (index <= commands[i])
                            {
                                if (dir == 4)
                                {
                                    curr_y++;
                                }
                                else
                                {
                                    curr_y--;
                                }
                                if (dictX[curr_x].Contains(curr_y))
                                {
                                    if (dir == 4)
                                    {
                                        curr_y--;
                                    }
                                    else
                                    {
                                        curr_y++;
                                    }
                                    break;
                                }
                                index++;
                            }
                        }
                        else
                        {
                            if (dir == 4)
                            {
                                curr_y += commands[i];
                            }
                            else
                            {
                                curr_y -= commands[i];
                            }
                        }
                    }
                    else // 东西移动    看y 有没有和我一样的
                    {
                        if (dictY.ContainsKey(curr_y))
                        {
                            // 这条路上有障碍
                            //  commands[i];//向前几步
                            int index = 1;
                            while (index <= commands[i])
                            {
                                if (dir == 1)
                                {
                                    curr_x++;
                                }
                                else
                                {
                                    curr_x--;
                                }
                                if (dictY[curr_y].Contains(curr_x))
                                {
                                    if (dir == 1)
                                    {
                                        curr_x--;
                                    }
                                    else
                                    {
                                        curr_x++;
                                    }
                                    break;
                                }
                                index++;
                            }
                        }
                        else
                        {
                            if (dir == 1)
                            {
                                curr_x += commands[i];
                            }
                            else
                            {
                                curr_x -= commands[i];
                            }
                        }
                    }
                    var result = curr_x * curr_x + curr_y * curr_y;
                    if (result > maxDistance)
                    {
                        maxDistance = result;
                    }
                }

            }

            return maxDistance;
        }
        /// <summary>
        /// 计算朝向
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private int GetDir(int dir, int v)
        {
            if (dir == 1)// -2 向左旋转90度，-1 向右旋转90度
            {
                return v == -2 ? 4 : 2;
            }
            if (dir == 2)
            {
                return v == -2 ? 1 : 3;
            }

            if (dir == 3)
            {
                return v == -2 ? 2 : 4;
            }
            if (dir == 4)
            {
                return v == -2 ? 3 : 1;
            }
            return dir;
        }

        /// <summary>
        /// 395. 至少有 K 个重复字符的最长子串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestSubstring(string s, int k)
        {
            // 输入：s = "ababbc", k = 2
            // 输出：5
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] < k)
                {

                }
            }
            return 0;
        }
        /// <summary>
        /// 187. 重复的DNA序列
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            List<string> result = new List<string>();
            if (s.Length <= 10)
            {
                return result;
            }
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i <= s.Length - 10; i++)
            {
                var str = s.Substring(i, 10);
                //  Console.Write(str);
                if (dict.ContainsKey(str))
                {
                    dict[str]++;

                }
                else
                {
                    dict.Add(str, 1);
                }



            }
            foreach (var item in dict)
            {
                if (item.Value > 1)
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }
        /// <summary>
        /// 718. 最长重复子数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int FindLength(int[] nums1, int[] nums2)
        {
            int tempIndex1 = 0;
            int tempIndex2 = 0;
            int count = 0;
            int maxCount = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                if ((nums1.Length - i) < maxCount)
                {
                    return maxCount;
                }

                for (int j = 0; j < nums2.Length; j++)
                {
                    tempIndex1 = i;
                    tempIndex2 = j;
                    while (tempIndex1 < nums1.Length && tempIndex2 < nums2.Length && nums1[tempIndex1] == nums2[tempIndex2])
                    {
                        tempIndex1++;
                        tempIndex2++;
                        count++;
                    }
                    if (count > maxCount)
                    {
                        maxCount = count;

                    }
                    count = 0;
                    if ((nums1.Length - i) < maxCount)
                    {
                        break;
                    }
                }
            }
            return maxCount;
        }

        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < cpdomains.Length; i++)
            {
                var arr = cpdomains[i].Split(' ');
                var count = Convert.ToInt32(arr[0]);
                var areaNames = arr[1].Split('.');
                if (areaNames.Length == 2)
                {
                    if (dict.ContainsKey(arr[1]))
                    {
                        dict[arr[1]] += count;
                    }
                    else
                    {
                        dict.Add(arr[1], count);
                    }
                    if (dict.ContainsKey(areaNames[1]))
                    {
                        dict[areaNames[1]] += count;
                    }
                    else
                    {
                        dict.Add(areaNames[1], count);
                    }
                }
                else
                {
                    if (dict.ContainsKey(arr[1]))
                    {
                        dict[arr[1]] += count;
                    }
                    else
                    {
                        dict.Add(arr[1], count);
                    }
                    if (dict.ContainsKey(areaNames[2]))
                    {
                        dict[areaNames[2]] += count;
                    }
                    else
                    {
                        dict.Add(areaNames[2], count);
                    }
                    var areaName2 = areaNames[1] + "." + areaNames[2];
                    if (dict.ContainsKey(areaName2))
                    {
                        dict[areaName2] += count;
                    }
                    else
                    {
                        dict.Add(areaName2, count);
                    }
                }

            }


            foreach (var item in dict)
            {
                result.Add($"{item.Value} {item.Key}");
            }
            return result;
        }
        /// <summary>
        /// 621. 任务调度器
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval(char[] tasks, int n)
        {
            if (n == 0)
            {
                return tasks.Length;
            }
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < tasks.Length; i++)
            {
                if (dict.ContainsKey(tasks[i]))
                {
                    dict[tasks[i]]++;
                }
                else
                {
                    dict.Add(tasks[i], 1);
                }
            }

            int maxCount = 0;
            foreach (var item in dict)
            {
                if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                }
            }
            int count = 0;

            foreach (var item in dict)
            {
                if (item.Value == maxCount)
                {
                    count++;
                }
            }
            var result = maxCount * (n + 1) - n + count - 1;

            return result > tasks.Length ? result : tasks.Length;
        }
        /// <summary>
        /// 415. 字符串相加
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string AddStrings(string num1, string num2)
        {
            int index = 0;
            int index1 = 0;
            int shang = 0;
            string result = "";
            while (index < num1.Length || index1 < num2.Length)
            {
                int char1 = index < num1.Length ? (int)(num1[num1.Length - 1 - index] - 48) : 0;
                int char2 = index1 < num2.Length ? (int)(num2[num2.Length - 1 - index1] - 48) : 0;
                var char3 = char1 + char2 + shang;
                var yu = char3 % 10;
                result = (result + yu);
                shang = char3 / 10;
                index++;
                index1++;
            }
            if (shang > 0)
            {
                result += shang;
            }
            char[] arr = new char[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                arr[i] = result[result.Length - 1 - i];
            }
            return new string(arr);
        }
        /// <summary>
        /// 451. 根据字符出现频率排序
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FrequencySort(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            char[] arr = new char[dict.Count];
            int[] arr1 = new int[dict.Count];
            int index = 0;
            foreach (var item in dict)
            {

                arr1[index] = item.Value;
                arr[index] = item.Key;
                index++;
            }
            int maxValue = arr1[0];
            index = 0;
            for (int i = 0; i < arr1.Length; i++)
            {

                for (int j = 0; j < arr1.Length - i; j++)
                {
                    if (arr1[j] > maxValue)
                    {
                        maxValue = arr1[j];
                        index = j;
                    }
                }
                int temp = arr1[arr1.Length - i - 1];
                arr1[arr1.Length - i - 1] = arr1[index];
                arr1[index] = temp;

                var temp1 = arr[arr1.Length - i - 1];
                arr[arr1.Length - i - 1] = arr[index];
                arr[index] = temp1;
                maxValue = int.MinValue;
            }

            char[] arr3 = new char[s.Length];
            int arr3Index = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                index = 0;

                while (index < arr1[arr1.Length - 1 - i] && arr3Index < arr3.Length)
                {
                    arr3[arr3Index] = arr[arr1.Length - 1 - i];
                    arr3Index++;
                    index++;
                }
            }
            var result = new string(arr3);
            return result;
        }
        /// <summary>
        /// 387. 字符串中的第一个唯一字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 383. 赎金信
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (dict.ContainsKey(magazine[i]))
                {
                    dict[magazine[i]]++;
                }
                else
                {
                    dict.Add(magazine[i], 1);
                }
            }
            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (dict.ContainsKey(ransomNote[i]) && dict[ransomNote[i]] > 0)
                {
                    dict[ransomNote[i]]--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 979. 在二叉树中分配硬币
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int DistributeCoins(TreeNode root)
        {

            DFSDistributeCoins(root);
            return 1;
        }
        //   int count1 = 0;
        public void DFSDistributeCoins(TreeNode root)
        {
            count1++;
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.val + ",count=" + count1);
            DFSDistributeCoins(root.left);
            count1--;
            Console.WriteLine("左侧完事回溯：" + root.val + ",count=" + count1);
            DFSDistributeCoins(root.right);
            count1--;
            Console.WriteLine("右侧完事回溯：" + root.val + ",count=" + count1);
        }


        /// <summary>
        /// 229. 多数元素 II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MajorityElement(int[] nums)
        {
            List<int> result = new List<int>();
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
            foreach (var item in dict)
            {
                if (item.Value > nums.Length / 3)
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }
        /// <summary>
        /// 90. 子集 II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> temp = new List<int>();
            BackreackingSubsetsWithDup(result, temp, nums, 0);

            return result;
        }
        void BackreackingSubsetsWithDup(IList<IList<int>> result, List<int> temp, int[] nums, int index)
        {
            // 终止条件

            result.Add(temp.ToArray());

            if (nums.Length == index)
            {
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                temp.Add(nums[i]);
                BackreackingSubsetsWithDup(result, temp, nums, i);
                temp.RemoveAt(temp.Count() - 1);

            }
        }
        public IList<IList<int>> CombinationSum10(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> temp = new List<int>();
            BacktrackingCombinationSum10(candidates, result, temp, target, 0);

            return result;
        }
        void BacktrackingCombinationSum10(int[] candidates, IList<IList<int>> result, List<int> temp, int target, int index)
        {
            if (temp.Sum() == target)
            {
                result.Add(temp.ToArray());
                return;
            }
            if (temp.Sum() > target)
            {
                return;
            }
            for (int i = index; i < candidates.Length; i++)
            {
                temp.Add(candidates[i]);
                BacktrackingCombinationSum10(candidates, result, temp, target, index++);
                temp.RemoveAt(temp.Count() - 1);
            }

            // 终止条件
        }
        /// <summary>
        /// 17. 电话号码的字母组合
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();
            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }


            string[] arr = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            BacktrackingLetterCombinations(result, new List<char>(), digits, 0, arr);
            return result;
        }
        public void BacktrackingLetterCombinations(IList<string> result, List<char> temp, string digits, int index, string[] arr)
        {
            // 终止条件

            if (index == digits.Length)
            {


                var str = new string(temp.ToArray());
                result.Add(str);
                return;
            }


            // for循环
            // 执行操作
            // 递归
            // 回溯 删除上面的操作


            var ii = (int)digits[index] - 48;
            for (int j = 0; j < arr[ii].Length; j++)
            {
                temp.Add(arr[ii][j]);
                BacktrackingLetterCombinations(result, temp, digits, index + 1, arr);
                temp.RemoveAt(temp.Count - 1);// 回溯，经典
            }


        }
        /// <summary>
        /// 77. 组合
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> temp = new List<int>();
            BacktrackingCombine1(n, 1, temp, result, k);
            return result;
        }
        public void BacktrackingCombine1(int n, int k1, List<int> temp, IList<IList<int>> result, int k)
        {


            //if (终止条件)k==2
            //{
            //    // 存放结果 result.add(temp)
            //    return;
            //}

            if (temp.Count == k)
            {
                result.Add(temp.ToArray());
                return;
            }
            //for (选择：本层集合中元素（树中节点孩子的数量就是集合的大小)
            //{
            //    // 处理节点
            //    BacktrackingCombine1(k);递归
            //    // 回溯，撤销处理结果
            //}
            for (int i = k1; i <= n; i++)
            {
                temp.Add(i);
                BacktrackingCombine1(n, ++k1, temp, result, k);
                temp.Remove(i);
            }
        }
        /// <summary>
        /// 37. 解数独
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[][] board)
        {

            List<char> col = new List<char>();
            List<char> nine = new List<char>();
            List<IList<char>>[][] temp = new List<IList<char>>[9][];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new List<IList<char>>[9];
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    {
                        temp[i][j] = new List<IList<char>>();
                    }
                }
            }
            #region 处理行
            for (int i = 0; i < board.Length; i++)
            {
                List<char> row = new List<char>(9);
                for (int m = 1; m <= 9; m++)
                {
                    row.Add((char)(48 + m)); //1 = 49
                }
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        row.Remove(board[i][j]);
                    }
                }
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        temp[i][j].Add(row);
                    }
                }

            }
            #endregion

            #region 处理列
            for (int i = 0; i < board.Length; i++)
            {
                List<char> row = new List<char>(9);
                for (int m = 1; m <= 9; m++)
                {
                    row.Add((char)(48 + m)); //1 = 49
                }
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[j][i] != '.')
                    {
                        row.Remove(board[j][i]);
                    }
                }
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[j][i] == '.')
                    {
                        temp[j][i].Add(row);
                    }
                }

            }
            #endregion

            #region 处理九宫格




            int index_row = 0;
            int index_col = 0;
            while (index_col < 3)
            {
                while (index_row < 3)
                {
                    List<char> row = new List<char>(9);
                    for (int m = 1; m <= 9; m++)
                    {
                        row.Add((char)(48 + m)); //1 = 49
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            row.Remove(board[i + index_col * 3][j + index_row * 3]);
                        }

                    }
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i + index_col * 3][j + index_row * 3] == '.')
                            {
                                temp[i + index_col * 3][j + index_row * 3].Add(row);
                            }
                        }
                    }
                    index_row++;

                }

                index_row = 0;
                index_col++;
            }
            #endregion

            #region 获取交集


            Dfs123(board, temp, (char)0, 0, 0);
            #endregion
        }

        bool Dfs123(char[][] board, List<IList<char>>[][] temp, char c, int row, int col)
        {
            if (col == 9)
            {
                col = 0;
                row++;
                if (row == 9)
                {
                    return true;
                }
            }
            if (board[row][col] == '.')
            {
                //Console.WriteLine($"row={i},col={j},交集=" + interList.Count + " value=" + string.Join(',', interList));
                var interList = temp[row][col][0].Intersect(temp[row][col][1]).Intersect(temp[row][col][2]).ToList();

                for (int k = 0; k < interList.Count; k++)
                {
                    temp[row][col][0].Remove(interList[k]);
                    temp[row][col][1].Remove(interList[k]);
                    temp[row][col][2].Remove(interList[k]);
                    board[row][col] = interList[k];
                    if (Dfs123(board, temp, interList[k], row, col + 1))
                    {
                        return true;
                    }
                    // 这里是回溯的精髓，把删除掉的数据加回来
                    board[row][col] = '.';
                    temp[row][col][0].Add(interList[k]);
                    temp[row][col][1].Add(interList[k]);
                    temp[row][col][2].Add(interList[k]);
                }



                //  Console.WriteLine();
            }
            else
            {
                return Dfs123(board, temp, (char)0, row, col + 1);
            }


            return false;
        }
        /// <summary>
        /// 2178. 拆分成最多数目的正偶数之和
        /// </summary>
        /// <param name="finalSum"></param>
        /// <returns></returns>
        public IList<long> MaximumEvenSplit(long finalSum)
        {

            if (finalSum % 2 != 0)
            {
                return new long[] { };
            }


            IList<long> result = new List<long>();

            int num = 2;
            while (finalSum > 0)
            {
                if (finalSum < num)
                {
                    result.Remove(num - 2);

                    result.Add(finalSum + num - 2);
                    break;
                }
                var yushu = finalSum - num;

                finalSum = yushu;
                result.Add(num);

                num += 2;
            }
            return result;
        }
        /// <summary>
        /// 2679. 矩阵中的和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MatrixSum(int[][] nums)
        {
            int[][] tempNums = new int[nums.Length][];
            for (int i = 0; i < tempNums.Length; i++)
            {
                tempNums[i] = new int[nums[0].Length];
            }
            List<int> list = new List<int>();
            int score = 0;
            int lowIndex = 0;
            while (lowIndex < nums[0].Length)
            {
                list.Clear();
                for (int i = 0; i < nums.Length; i++)
                {
                    var rowArr = nums[i];
                    int maxValue = int.MinValue;
                    int index = 0;
                    for (int j = 0; j < rowArr.Length; j++)
                    {
                        if (tempNums[i][j] == 1)
                        {
                            continue;
                        }
                        if (rowArr[j] > maxValue)
                        {
                            maxValue = rowArr[j];
                            index = j;
                        }
                    }

                    tempNums[i][index] = 1;
                    list.Add(maxValue);
                }
                score += list.Max();
                lowIndex++;
            }
            return score;
        }
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dict[nums[i]] = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var num = target - nums[i];
                if (dict.ContainsKey(num) && dict[num] != i)
                {
                    return new int[] { dict[num], i };
                }
            }
            return null;
        }
        /// <summary>
        /// 2490. 回环句
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public bool IsCircularSentence(string sentence)
        {
            var arr = sentence.Split(' ');
            if (arr.Length == 1)
            {
                return arr[0][0] == arr[0][arr[0].Length - 1];
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var str = arr[i];
                var strNext = arr[i + 1];
                if (str[str.Length - 1] != strNext[0])
                {
                    return false;
                }
            }
            var lastStr = arr[arr.Length - 1];
            return arr[0][0] == lastStr[lastStr.Length - 1];
        }
        /// <summary>
        /// 1253. 重构 2 行二进制矩阵
        /// </summary>
        /// <param name="upper"></param>
        /// <param name="lower"></param>
        /// <param name="colsum"></param>
        /// <returns></returns>
        public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
        {
            // upper = 5;
            // lower = 5;
            // colsum = [2,1,2,0,1,0,1,2,0,1]
            IList<IList<int>> res = new List<IList<int>>();
            int[][] arr = new int[2][];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[colsum.Length];
            }
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < colsum.Length; i++)
            {
                if (colsum[i] == 0)
                {
                    arr[0][i] = 0;
                    arr[1][i] = 0;

                }
                if (colsum[i] == 2)
                {
                    arr[0][i] = 1;
                    arr[1][i] = 1;
                    sum1++;
                    sum2++;

                }

            }

            for (int i = 0; i < colsum.Length; i++)
            {

                if (colsum[i] == 1)
                {
                    if (sum1 > upper)
                    {
                        return res;
                    }
                    if (sum2 > lower)
                    {
                        return res;
                    }
                    if (upper > sum1)
                    {
                        arr[0][i] = 1;
                        sum1++;
                        continue;
                    }
                    else if (lower > sum2)
                    {
                        arr[1][i] = 1;
                        sum2++;
                        continue;
                    }
                    if (upper == sum1 && lower == sum2)
                    {
                        return res;
                    }
                }

            }
            if (upper == sum1 && lower == sum2)
            {
                return arr;
            }
            return res;
        }
        /// <summary>
        /// 1186. 删除一次得到子数组最大和
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaximumSum(int[] arr)
        {
            // arr = [1, -2, 0, 3];
            int[][] dp = new int[arr.Length][]; // dp[i][0] 表示没有删除数， dp[i][1] 表示删除了一个数
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[2];
            }
            int res = arr[0];
            dp[0][0] = arr[0];
            dp[0][1] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                dp[i][0] = Math.Max(dp[i - 1][0] + arr[i], arr[i]);// 没有删除的 就看连续子数组的和 加上我自己  比不比我自己大
                dp[i][1] = Math.Max(dp[i - 1][1] + arr[i], dp[i - 1][0]); // 删除了一个数的必然要加上我，和 不删除元素比谁大，如果 不删除的 大 取不删除的 否则取
                res = Math.Max(Math.Max(dp[i][0], dp[i][1]), res);// 每一轮都找出最大值
            }
            return res;
        }
        /// <summary>
        /// 2485. 找出中枢整数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PivotInteger(int n)
        {
            var sum = (1 + n) * n / 2;
            for (int i = 1; i <= n; i++)
            {
                var sum1 = (1 + i) * i / 2;
                if (sum - sum1 + i == sum1)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="xCenter"></param>
        /// <param name="yCenter"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
        {


            return false;
        }
        /// <summary>
        /// 1262. 可被三整除的最大和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSumDivThree(int[] nums)
        {

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int sum = 0;
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
                sum += nums[i];
            }
            var yu = sum % 3;
            if (yu == 0)
            {
                return sum;
            }
            int minValue = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                while (dict[nums[i]] > 0 && nums[i] < 3)
                {
                    for (int j = 1; j <= dict[nums[i]]; j++)
                    {
                        if ((nums[i] * j - yu) % 3 == 0)
                        {
                            if (nums[i] < minValue)
                            {
                                minValue = nums[i] * j;
                            }
                        }
                    }
                    dict[nums[i]]--;

                }
                if ((nums[i] - yu) % 3 == 0)
                {
                    if (nums[i] < minValue)
                    {
                        minValue = nums[i];
                    }
                }
            }
            if (minValue == int.MaxValue)
            {
                return 0;
            }
            return sum - minValue;
        }
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] CountingSort(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            int[] arr_dict = new int[max - min + 1];


            return null;
        }
        /// <summary>
        /// 2734. 执行子串操作后的字典序最小字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SmallestString(string s)
        {
            //   输入：s = "cbabc"
            //  输出："baabc"
            //  输入：s = "acbbc"
            // 输出："abaab"
            return null;
        }
        /// <summary>
        /// 虚拟竞赛
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindNonMinOrMax(int[] nums)
        {
            int minValue = nums[0];
            int maxValue = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < minValue)
                {
                    minValue = nums[i];
                }
                if (nums[i] > maxValue)
                {
                    maxValue = nums[i];
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != minValue && nums[i] != maxValue)
                {
                    return nums[i];
                }
            }
            return -1;
        }
        /// <summary>
        /// 1171. 从链表中删去总和值为零的连续节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            Dictionary<int, ListNode> dict = new Dictionary<int, ListNode>();
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            int sum = 0;
            while (head != null)
            {
                sum += head.val;

                dict[sum] = head;

                head = head.next;
            }
            sum = 0;
            for (ListNode node = dummy; node != null; node = node.next)
            {
                sum += node.val;
                node.next = dict[sum].next;
            }
            return dummy.next;
        }

        /// <summary>
        /// 2611. 老鼠和奶酪
        /// 请你返回第一只老鼠恰好吃掉 k 块奶酪的情况下，最大 得分为多少。
        /// </summary>
        /// <param name="reward1"></param>
        /// <param name="reward2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MiceAndCheese(int[] reward1, int[] reward2, int k)
        {
            //  reward1 = [1, 1, 3, 4], reward2 = [4, 4, 1, 1], k = 2
            // 输出 15 
            // 解释：这个例子中，第一只老鼠吃掉第 2 和 3 块奶酪（下标从 0 开始），第二只老鼠吃掉第 0 和 1 块奶酪。


            // dp 表示什么呢？
            // 当 种类等于 i时，最大得分
            //   当 reward1 的长度 等于 k 时 第一只需要把他自己的 都吃掉
            //   当 reward1 等k+1时,
            //   第一只可以选择吃或者不吃，不吃r1啥也不用动  sum+=r2[k];
            //   吃的话 前面的就需要放弃一个，放弃 reward2 值最大的那个
            //   怎么选择吃或者不吃呢？
            //   简单点 就是 吃他获取的最大值，比不吃他获取的最大值大，就吃

            //    int[] dp = new int[reward1.Length];
            int[][] test = new int[k][];
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = new int[2];
                test[i][0] = reward1[i];
                test[i][1] = reward2[i];
            }
            //dp[0] = reward1[0];
            //for (int i = 1; i < k; i++)
            //{
            //    dp[i] = dp[i - 1] + reward1[i];
            //}

            int index = 0;
            int sum = 0;
            for (int i = k; i < reward1.Length; i++)
            {
                int minValue = int.MaxValue;
                var num1 = reward1[i] - reward2[i];

                for (int j = 0; j < test.Length; j++)
                {
                    var num2 = test[j][0] - test[j][1];
                    if (num2 < minValue)
                    {
                        minValue = num2;
                        index = j;
                    }
                }
                if (num1 > minValue)
                {
                    sum += test[index][1];
                    test[index][0] = reward1[i];
                    test[index][1] = reward2[i];
                }
                else
                {
                    sum += reward2[i];
                }
            }
            for (int i = 0; i < test.Length; i++)
            {
                sum += test[i][0];
            }

            return sum;
        }
        /// <summary>
        /// 2460. 对数组执行操作
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ApplyOperations(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] = 2 * nums[i];
                    nums[i + 1] = 0;
                }
            }
            int lowIndex = 0;
            int lastIndex = nums.Length - 1;
            int tempIndex = 0;
            while (lowIndex < lastIndex)
            {
                if (nums[tempIndex] == 0)
                {
                    while (tempIndex < nums.Length - 1)
                    {
                        nums[tempIndex] = nums[tempIndex + 1];
                        tempIndex++;
                    }
                    nums[tempIndex] = 0;
                    lastIndex--;
                }
                if (nums[lowIndex] != 0)
                    lowIndex++;

                tempIndex = lowIndex;
            }

            return nums;
        }
        /// <summary>
        /// 1090. 受标签影响的最大值
        /// 输入：values = [5,4,3,2,1], labels = [1,1,2,2,3], numWanted = 3, useLimit = 1
        /// 输出：9
        //  解释：选出的子集是第一项，第三项和第五项。
        /// </summary>
        /// <param name="values"></param>
        /// <param name="labels"></param>
        /// <param name="numWanted"></param>
        /// <param name="useLimit"></param>
        /// <returns></returns>
        public int LargestValsFromLabels1(int[] values, int[] labels, int numWanted, int useLimit)
        {
            // 初始化数据
            // 把数据分组放到集合里面去
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            Dictionary<int, Stack<int>> dict_stack = new Dictionary<int, Stack<int>>();
            Dictionary<int, int> dict_takecount = new Dictionary<int, int>();

            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                var groupId = labels[i];
                if (dict.ContainsKey(groupId))
                {
                    dict[groupId].Add(value);
                }
                else
                {
                    dict.Add(groupId, new List<int> { value });
                }
            }
            int key = 0, max_value = 0;
            foreach (var item in dict)
            {
                item.Value.Sort();

                if (item.Value.Last() > max_value)
                {
                    max_value = item.Value.Last();
                    key = item.Key;
                }

                dict_takecount.Add(item.Key, useLimit);
            }

            int max = 0;


            // 每组最多可以 拿 useLimit 个数
            // 一共可以拿多少数 numWanted



            bool flag = false;
            while (numWanted > 0)
            {
                foreach (var item in dict)
                {
                    if (dict_takecount[item.Key] <= 0)
                    {
                        continue;
                    }
                    if (item.Value.Last() > max_value)
                    {
                        max_value = item.Value.Last();
                        key = item.Key;
                    }
                }
                max += max_value;


                dict[key].Remove(max_value);
                if (dict[key].Count > 0)
                {
                    dict_takecount[key]--;
                }
                else
                {
                    dict_takecount[key] = 0;
                }
                foreach (var item in dict_takecount)
                {
                    if (item.Value > 0)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    break;

                }
                max_value = 0;
                key = 0;
                flag = false;
                numWanted--;
            }


            return max;
        }

        public int LargestValsFromLabels2(int[] values, int[] labels, int numWanted, int useLimit)
        {
            // 初始化数据
            // 把数据分组放到集合里面去
            //   Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            Dictionary<int, Stack<int>> dict_stack = new Dictionary<int, Stack<int>>();
            Dictionary<int, int> dict_takecount = new Dictionary<int, int>();

            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                var groupId = labels[i];
                if (dict_stack.ContainsKey(groupId))
                {
                    var peekValue = dict_stack[groupId].Peek();
                    if (value >= peekValue) // 当前值比栈顶的值还要大或者等于，直接往里放
                    {
                        dict_stack[groupId].Push(value);
                    }
                    else // 当前值 比栈顶值小
                    {
                        Stack<int> temp_stack = new Stack<int>();
                        while (dict_stack[groupId].Count > 0 && value < dict_stack[groupId].Peek())
                        {
                            temp_stack.Push(dict_stack[groupId].Pop());

                        }
                        dict_stack[groupId].Push(value);
                        while (temp_stack.Count > 0)
                        {
                            dict_stack[groupId].Push(temp_stack.Pop());
                        }
                    }
                }
                else
                {
                    var stack = new Stack<int>();
                    stack.Push(value);
                    dict_stack.Add(groupId, stack);
                }
            }


            int key = 0, max_value = 0;
            foreach (var item in dict_stack)
            {


                dict_takecount.Add(item.Key, useLimit);
            }

            int max = 0;


            //// 每组最多可以 拿 useLimit 个数
            //// 一共可以拿多少数 numWanted



            bool flag = false;
            while (numWanted > 0)
            {
                foreach (var item in dict_stack)
                {
                    if (dict_takecount[item.Key] <= 0)
                    {
                        continue;
                    }
                    if (item.Value.Count <= 0)
                    {
                        continue;
                    }
                    if (item.Value.Peek() > max_value)
                    {
                        max_value = item.Value.Peek();
                        key = item.Key;
                    }
                }
                max += max_value;


                dict_stack[key].Pop();
                if (dict_stack[key].Count > 0)
                {
                    dict_takecount[key]--;
                }
                else
                {
                    dict_takecount[key] = 0;
                }
                foreach (var item in dict_takecount)
                {
                    if (item.Value > 0)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    break;

                }
                max_value = 0;
                key = 0;
                flag = false;
                numWanted--;
            }


            return max;
        }
        public int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit)
        {
            int max = int.MinValue;
            int maxIndex = 0;
            Dictionary<int, int> dict_takecount = new Dictionary<int, int>();

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values.Length - i; j++)
                {
                    var value = values[j];
                    if (value > max)
                    {
                        max = value;
                        maxIndex = j;
                    }
                }
                var temp = values[values.Length - i - 1];

                values[values.Length - i - 1] = values[maxIndex];
                values[maxIndex] = temp;
                var temp1 = labels[values.Length - i - 1];

                labels[labels.Length - i - 1] = labels[maxIndex];
                labels[maxIndex] = temp1;
                max = int.MinValue;


            }
            for (int i = 0; i < values.Length; i++)
            {
                if (!dict_takecount.ContainsKey(labels[i]))
                {
                    dict_takecount.Add(labels[i], useLimit);
                }
            }
            int index = 0;
            int count = 0;
            max = 0;
            while (index < values.Length)
            {
                var label = labels[values.Length - 1 - index];
                var maxValue = values[values.Length - 1 - index];

                if (dict_takecount[label] > 0)
                {
                    max += maxValue;
                    count++;
                    dict_takecount[label]--;
                    if (count >= numWanted)
                    {
                        break;
                    }
                }

                index++;



            }
            return max;
        }

        /// <summary>
        /// 165. 比较版本号
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public int CompareVersion(string version1, string version2)
        {
            var arr1 = version1.Split('.');
            var arr2 = version2.Split('.');
            for (int i = 0; i < Math.Max(arr1.Length, arr2.Length); i++)
            {
                var num1 = i < arr1.Length ? Convert.ToInt32(arr1[i]) : 0;
                var num2 = i < arr2.Length ? Convert.ToInt32(arr2[i]) : 0;
                if (num1 > num2)
                {
                    return 1;
                }
                if (num1 < num2)
                {
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 80. 删除有序数组中的重复项 II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            int sameCount = 1;

            int low_index = 0;
            int hight_index = nums.Length - 1;
            while (low_index < hight_index)
            {
                var num = nums[low_index];
                var num1 = nums[low_index + 1];
                if (num == num1)
                {
                    sameCount++;
                }
                else
                {
                    if (sameCount > 2)
                    {
                        var len = sameCount - 2;
                        int index = low_index - len + 1;
                        int index1 = low_index + 1;
                        while (index1 <= hight_index)
                        {
                            nums[index] = nums[index1];
                            index++;
                            index1++;
                        }
                        hight_index -= len;
                        low_index = low_index - len;
                    }
                    sameCount = 1;
                }

                low_index++;
            }
            if (sameCount > 2)
            {
                var len = sameCount - 2;
                int index = low_index - len + 1;
                int index1 = low_index + 1;
                while (index1 < hight_index)
                {
                    nums[index] = nums[index1];
                    index++;
                    index1++;
                }
                hight_index -= len;
                sameCount = 1;
                low_index = low_index - len;
            }
            return hight_index + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            var reslut = Traverse(root, limit, 0);
            return reslut;
        }
        public TreeNode Traverse(TreeNode root, int limit, int sum)
        {
            if (root == null)
            {
                return null;
            }
            sum += root.val;

            if (root.left == null && root.right == null)
            {
                if (sum < limit)
                {

                    return null;
                }
                return root;
            }

            root.left = Traverse(root.left, limit, sum);
            root.right = Traverse(root.right, limit, sum);
            return root.left == null && root.right == null ? null : root;
        }
        /// <summary>
        /// 77. 组合
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine1(int n, int k)
        {
            //for (int i = 1; i <= n; i++)
            //{
            //    // cw  1,2,3,4

            //    for (int j = i + 1; j <= n; j++)
            //    {
            //        Console.WriteLine($"i={i},j={j}");
            //    }
            //}
            List<IList<int>> result = new List<IList<int>>();
            List<int> path = new List<int>();
            BackTracking(n, k, 1, result, path);

            return result;


        }

        private void BackTracking(int n, int k, int startIndex, List<IList<int>> result, List<int> path)
        {
            if (path.Count == k)
            {
                result.Add(path.ToArray());
                return;
            }


            for (int i = startIndex; i <= n; i++) // 控制数的横向遍历
            {
                path.Add(i);
                BackTracking(n, k, startIndex + 1, result, path);
                path.RemoveAt(path.Count - 1);
            }

        }
        /// <summary>
        /// 1079. 活字印刷
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int NumTilePossibilities(string tiles)
        {


            return 0;
        }
        private void Backtracking(string str)
        {
            if (true)
            {
                // 存放结果
                return;
            }

        }
        /// <summary>
        /// 1054. 距离相等的条形码
        /// </summary>
        /// <param name="barcodes"></param>
        /// <returns></returns>
        public int[] RearrangeBarcodes(int[] barcodes)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < barcodes.Length; i++)
            {
                if (dict.ContainsKey(barcodes[i]))
                {
                    dict[barcodes[i]]++;
                }
                else
                {
                    dict.Add(barcodes[i], 1);
                }

            }


            int index = 0;
            int currValue = 0;
            while (index < barcodes.Length)
            {
                int maxValue = 0;
                int maxKey = 0;

                foreach (var item in dict)
                {
                    if (item.Key == currValue) continue;
                    if (item.Value > maxValue)
                    {
                        maxValue = item.Value;
                        maxKey = item.Key;
                    }
                }
                dict[maxKey]--;
                barcodes[index] = maxKey;
                currValue = maxKey;
                index++;

            }
            return barcodes;
        }

        /// <summary>
        /// 2446. 判断两个事件是否存在冲突
        /// </summary>
        /// <param name="event1"></param>
        /// <param name="event2"></param>
        /// <returns></returns>
        public bool HaveConflict(string[] event1, string[] event2)
        {
            var dt10 = Convert.ToDateTime(event1[0]);
            var dt11 = Convert.ToDateTime(event1[1]);
            var dt20 = Convert.ToDateTime(event2[0]);
            var dt21 = Convert.ToDateTime(event2[1]);
            return (dt20 <= dt11 && dt21 >= dt11) || (dt10 <= dt21 && dt11 >= dt21);

        }
        public int MaxEqualRowsAfterFlips(int[][] matrix)
        {

            return 0;
        }
        /// <summary>
        /// 36. 有效的数独
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            HashSet<char> set = new HashSet<char>();

            // 验证行
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var c = board[i][j];
                    if (c == '.')
                    {
                        continue;
                    }

                    if (set.Contains(c))
                    {
                        return false;
                    }
                    else
                    {
                        set.Add(c);
                    }
                }
                set.Clear();
            }

            // 验证列
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var c = board[j][i];
                    if (c == '.')
                    {
                        continue;
                    }

                    if (set.Contains(c))
                    {
                        return false;
                    }
                    else
                    {
                        set.Add(c);
                    }
                }
                set.Clear();
            }


            int offset_row = 0;
            int offset_col = 0;

            while (offset_col < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var c = board[i + 3 * offset_row][j + 3 * offset_col];
                        if (c == '.')
                        {
                            continue;
                        }

                        if (set.Contains(c))
                        {
                            return false;
                        }
                        else
                        {
                            set.Add(c);
                        }
                    }

                }
                set.Clear();
                offset_row++;
                if (offset_row > 2)
                {
                    offset_row = 0;
                    offset_col++;
                }

            }

            return true;
        }
        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('c', 0);
            dict.Add('r', 0);
            dict.Add('o', 0);
            dict.Add('a', 0);
            dict.Add('k', 0);


            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            dict1.Add('c', 0);
            dict1.Add('r', 1);
            dict1.Add('o', 2);
            dict1.Add('a', 3);
            dict1.Add('k', 4);
            int[] arr = new int[5];
            int count = 0;
            for (int i = 0; i < croakOfFrogs.Length; i++)
            {
                var c = croakOfFrogs[i];

                if (c == 'c')
                {
                    Console.WriteLine("猫开始叫了");

                }
                dict[c]++;
                arr[dict1[c]]++;
                for (int k = 0; k < dict1[c]; k++)
                {
                    if (arr[k] < arr[k + 1])
                    {
                        return -1;
                    }
                }

                while (dict['c'] > 0 && dict['r'] > 0 && dict['o'] > 0 && dict['a'] > 0 && dict['k'] > 0)
                {
                    Console.WriteLine("猫叫完成了");
                    dict['c']--;
                    dict['r']--;
                    dict['o']--;
                    dict['a']--;
                    dict['k']--;
                    Console.WriteLine("还有几个猫 正在叫？" + dict['c']);
                    if (dict['c'] > count)
                    {
                        count = dict['c'];
                    }
                    if (dict['c'] == 0)
                    {

                    }
                }

            }
            foreach (var item in dict)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine("不完整 返回-1");

                    return -1;
                }
            }
            return count + 1;
        }
        /// <summary>
        /// 1419. 数青蛙
        /// </summary>
        /// <param name="croakOfFrogs"></param>
        /// <returns></returns>
        public int MinNumberOfFrogs1(string croakOfFrogs)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('c', 0);
            dict.Add('r', 1);
            dict.Add('o', 2);
            dict.Add('a', 3);
            dict.Add('k', 4);
            List<int> list = new List<int>(4);

            for (int i = 0; i < croakOfFrogs.Length; i++)
            {
                var c = croakOfFrogs[i];
                if (dict[c] == 0)
                {
                    bool flag = false;
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (list[k] == -1)
                        {
                            list[k] = 1;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        list.Add(1);

                    }
                }
                else
                {
                    if (list.Count <= 0) // 字母顺序不对
                    {
                        return -1;
                    }

                    bool flag1 = false;
                    for (int j = 0; j < list.Count; j++)
                    {
                        var count = list[j];
                        if (count == -1)
                        {
                            continue;
                        }
                        if (count == dict[c])
                        {
                            flag1 = true;
                            list[j]++;
                            if (list[j] > 4)
                            {
                                // 完成一次呱呱叫
                                list[j] = -1;
                            }
                            break;
                        }

                    }
                    if (!flag1)
                    {
                        return -1;// 顺序不对
                    }
                }
            }
            var c1 = list.Count(c => c == -1);
            return c1 == 0 ? -1 : c1;
            //  return list.Count;
        }
        public int MostFrequentEven(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
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
            }
            int ans = -1, mx = 0;
            foreach (var item in dict)
            {
                int x = item.Key;
                int v = item.Value;
                if (mx < v || (mx == v && ans > x))
                {
                    ans = x;
                    mx = v;
                }
            }
            return ans;
        }
        /// <summary>
        /// 2469. 温度转换
        /// </summary>
        /// <param name="celsius"></param>
        /// <returns></returns>
        public double[] ConvertTemperature(double celsius)
        {

            return new double[] { celsius + 273.15, celsius * 1.80 + 32.00 };
        }
        /// <summary>
        /// 2379. 得到 K 个黑块的最少涂色次数
        /// </summary>
        /// <param name="blocks"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumRecolors(string blocks, int k)
        {
            // "WBBWWBBWBW"  7个 
            int lowIndex = 0;
            int hightIndex = k;
            int minValue = int.MaxValue;

            int count = 0;
            while (hightIndex <= blocks.Length)
            {
                for (int i = lowIndex; i < hightIndex; i++)
                {
                    if (blocks[i] == 'W')
                    {
                        count++;
                    }
                }

                if (minValue > count)
                {
                    minValue = count;
                }
                count = 0;
                hightIndex++;
                lowIndex++;
            }
            return minValue;
        }
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




            //if (arr1.Length == arr2.Length)
            //{
            //    return sentence1 == sentence2;
            //}
            //if (arr1.Length == 1)
            //{
            //    return arr1[0] == arr2[0] || arr1[0] == arr2[arr2.Length - 1];
            //}
            int lowIndexArr1 = 0;
            int fastIndexArr1 = arr1.Length - 1;
            int lowIndexArr2 = 0;
            int fastIndexArr2 = arr2.Length - 1;

            while (lowIndexArr1 <= fastIndexArr1 && lowIndexArr2 <= fastIndexArr2)
            {
                if (arr1[lowIndexArr1] != arr2[lowIndexArr2] && arr1[fastIndexArr1] != arr2[fastIndexArr2])
                {
                    return false;
                }
                if (arr1[lowIndexArr1] == arr2[lowIndexArr2])
                {
                    lowIndexArr1++;
                    lowIndexArr2++;
                }
                if (arr1[fastIndexArr1] == arr2[fastIndexArr2])
                {
                    fastIndexArr1--;
                    fastIndexArr2--;
                }

            }
            return true;
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
            //  [1,1,1,1,2,2,2,2]
            //   4
            // 表示有可能分成k份
            // 每份 的均值是 val 
            var avg = sum / k;  // sum =12 k = 2;  avg = 6;
            if (nums.Max() > avg) // 数组中最大的值，比评价值大，不用分组了。 直接return 
            {
                return false;
            }
            List<IList<int>> result = new List<IList<int>>();
            List<int> temp = new List<int>();
            List<int> tempIndex = new List<int>();
            bool[] usedArr = new bool[nums.Length];
            BacktrackingCanPartitionKSubsets(nums, result, temp, avg, 0, usedArr, tempIndex);
            return result.Count == k;
        }
        void BacktrackingCanPartitionKSubsets(int[] candidates, IList<IList<int>> result, List<int> temp, int target, int index, bool[] useArr, List<int> tempIndex)
        {
            if (temp.Sum() == target)
            {

                result.Add(temp.ToArray());

                return;
            }
            if (temp.Sum() > target)
            {
                return;
            }
            for (int i = index; i < candidates.Length; i++)
            {
                if (i > 0 && candidates[i] == candidates[i - 1] && useArr[i - 1] == false)
                {
                    continue;
                }
                temp.Add(candidates[i]);
                tempIndex.Add(i);
                BacktrackingCanPartitionKSubsets(candidates, result, temp, target, ++index, useArr, tempIndex);
                tempIndex.Remove(i);
                temp.RemoveAt(temp.Count() - 1);
            }

            // 终止条件
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




            WordBreak1(s, set, 0);


            return false;
        }
        public bool WordBreak1(string s, HashSet<string> set, int temp)
        {
            int splitLength = 1;


            while (splitLength <= s.Length)
            {

                var str = s.Substring(0, splitLength);
                if (set.Contains(str))
                {

                    s = s.Substring(splitLength, s.Length - splitLength);

                    if (s == "")
                    {
                        return true;
                    }

                    WordBreak1(s, set, temp);

                }
                else
                {
                    splitLength++;
                }
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
            //if (root != null)
            //{

            //    Console.WriteLine(root.val);
            //}
            //LowestCommonAncestor(root.left, null, null);
            //LowestCommonAncestor(root.right, null, null);

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
        int count1 = 0;
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
            //找出所有相加之和为 n 的 k 个数的组合，且满足下列条件：
            //只使用数字1到9
            //每个数字 最多使用一次
            //返回 所有可能的有效组合的列表 。该列表不能包含相同的组合两次，组合可以以任何顺序返回。
            IList<IList<int>> result = new List<IList<int>>();
            List<int> temp = new List<int>();


            BackTrackingCombinationSum3(k, n, result, temp, 1, 0);
            return result;

        }
        public void BackTrackingCombinationSum3(int k, int n, IList<IList<int>> result, List<int> temp, int index, int sum)
        {
            //if (终止条件)
            //{
            //    加入集合
            //    return;
            //}
            if (sum > n)
            {
                return;
            }
            if (temp.Count == k)
            {
                if (temp.Sum() == n)
                {
                    result.Add(temp.ToArray());
                    return;
                }
                return;
            }
            //for (选择本层集合中元素，树中节点孩子的数量就是集合大小)
            //{
            // 处理节点
            // 递归
            // 回溯
            //}
            for (int i = index; i <= 9; i++)
            {
                temp.Add(i);
                sum += i;
                BackTrackingCombinationSum3(k, n, result, temp, ++index, sum);
                sum -= i;
                temp.Remove(i);
            }
        }
        ///// <summary>
        ///// 77.组合
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="k"></param>
        ///// <returns></returns>
        //public IList<IList<int>> Combine(int n, int k)
        //{
        //    IList<IList<int>> res = new List<IList<int>>();
        //    IList<int> path = new List<int>();
        //    BackTrackingCombine(res, path, n, k, 1);
        //    return res;
        //}
        //public void BackTrackingCombine(IList<IList<int>> result, IList<int> path, int n, int k, int startIndex)
        //{
        //    if (path.Count == k)
        //    {
        //        result.Add(path.ToArray());
        //        return;
        //    }
        //    for (int i = startIndex; i <= n - (k - path.Count) + 1; i++)
        //    {
        //        path.Add(i);
        //        BackTrackingCombine(result, path, n, k, i + 1);
        //        path.RemoveAt(path.Count - 1);
        //    }
        //}
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
