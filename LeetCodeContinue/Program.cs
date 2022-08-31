using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodeContinue
{
    public class XunFeiClass
    {
        public void TTSTask(string speekText)
        {
            Task ttsTask = new Task(() =>
            {
                Offline_TTS(speekText);
            });
            ttsTask.Start();
            ttsTask.ContinueWith((ttsCallback) =>
            {
                Console.WriteLine("语音合成完成回调");
            });
        }

        public void Offline_TTS(string speekText)
        {
            Console.WriteLine("开始合成语音");
            Thread.Sleep(2000);
            Console.WriteLine("语音合成完成");
        }
    }
    class Program
    {




        static void Main(string[] args)
        {
          
            // 计算一下 年前 还有（ 8 9 10 11 12=） 5个月 
            // 每个月4w = 20w


            LeetCode code = new LeetCode();
            code.ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3, 5, 1, 2 });
            TreeNode root = new TreeNode(new TreeNode(2), 1, new TreeNode(3));
            code.DeepestLeavesSum(root);
            var r = code.GenerateTheString(50);
            Console.WriteLine(r);
            // code.TestMyCalendarTwo();
            // code.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4});
            //   code.WordBreak("goalspecial", new string[] { "go","goal","goals","special" });
            //  code.AsteroidCollision(new int[] { 11, -90 }); //, 5, -10, 100
            //  var check1 = code.Check(new int[] {9, 1, 3, 4 });
            //  Console.WriteLine("-------" + check1);
            // var check2 = code.Check(new int[] { 2, 1, 3, 4 });
            // Console.WriteLine("-------" + check2);
            // code.TestMagicDictionary();
            // code.SetZeroes(new int[3][] { new int [] {1,0,3 }, new int[] { 4,0,6}, new int[] { 7,8,9} });
            Console.ReadKey();
            //  code.NextGreaterElement(12);
            // code.ReplaceWords(new string[] { "cat", "bat", "rat" }, "the cattle was rattled by the battery");
            // code.TestMyCalendar();
            // var resultMinCostToMoveChips = code.MinCostToMoveChips(new int[] { 2, 2, 2, 3, 3 });
            Console.WriteLine(code.MinCostToMoveChips(new int[] { 2, 2, 2, 3, 3 }));
            Console.WriteLine(code.MinCostToMoveChips(new int[] { 1, 10000000 }));
            // var res_MinimumAbsDifference = code.MinimumAbsDifference(new int[] { 3, 8, -10, 23, 19, -4, -14, 27 });

            //var bbb = code.IsBoomerang(new int[3][] { new int[2] { 0, 2 }, new int[2] { 0, 1 }, new int[2] { 0, 1 } });
            Console.WriteLine("max=" + code.FindKthLargest(new int[] { -1, 2, 0 }, 3));
            Console.WriteLine("max=" + code.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
            Console.WriteLine("max=" + code.FindKthLargest(new int[] { 3 }, 1));
            Console.WriteLine("max=" + code.FindKthLargest(new int[] { 3, 3, 3, 1 }, 2));
            Console.WriteLine("max=" + code.FindKthLargest(new int[] { 3, 0 }, 2));
            // code.StrStr("abc", "c");
            //  code.FindClosest(new string[] { "a", "b", "a", "b", "a", "b", "a" }, "a", "b");
            // code.Connect(new Node1(1, new Node1(2, new Node1(4), new Node1(5), null), new Node1(3, new Node1(6), new Node1(7), null), null));
            //code.LevelOrder2(new TreeNode(new TreeNode(new TreeNode(18),9,new TreeNode(77)), 3, new TreeNode(new TreeNode(15), 20, new TreeNode(7))));
            //  Console.ReadKey();
            //code.MinMoves2(new int[] { 1, 0, 0, 8, 6 });
            //  code.IsUnivalTree(new TreeNode(new TreeNode(1), 1, new TreeNode(1)));
            code.LargestValues(new TreeNode(new TreeNode(1), 1, new TreeNode(1)));
            //  var list_result = code.Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            ListNode head = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
            // code.SortList(head);
            //RecentCounter recent = new RecentCounter();
            //Console.WriteLine(recent.Ping(1));"teacher"

            //Console.WriteLine(recent.Ping(100));
            //Console.WriteLine(recent.Ping(3001));
            //Console.WriteLine(recent.Ping(3002));
            //Console.WriteLine(code.OneEditAway("abdc", "abc"));
            //Console.WriteLine(code.OneEditAway("abdc", "abdc"));
            //Console.WriteLine(code.OneEditAway("abdc", "ab"));
            Console.WriteLine(code.OneEditAway("", "b"));
            //Console.WriteLine(code.OneEditAway("abdc", "abdcaa"));
            //Console.WriteLine(code.OneEditAway("", "abdcaa"));
            //Console.WriteLine(code.OneEditAway("abcde", "abdde"));
            Console.WriteLine(code.Trans(101));
            Console.WriteLine(code.Trans(100));
            Console.WriteLine(code.Trans(10));
            Console.WriteLine(code.Trans(99151));
            Console.WriteLine(code.Trans(001));
            Console.ReadKey();
            //TreeNode root = new TreeNode(2);
            //var right = new TreeNode(3);
            //root.left = new TreeNode(1);
            //root.right = right;
            //code.InorderSuccessor(root, new TreeNode(1));
            Console.ReadKey();
            var ss = code.LongestCommonPrefix(new string[] { "fl" });
            var resultDiStringMatch = code.DiStringMatch("DDI");
            code.FindDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            Console.WriteLine(ss);
            code.Convert1("PAYPALISHIRING", 6);
            code.Convert1("PAYPALISHIRING", 5);
            code.Convert1("PAYPALISHIRING", 4);
            code.Convert1("PAYPALISHIRING", 3);
            code.Convert1("PAYPALISHIRING", 2);
            Console.WriteLine(7 / 2); // 商
            Console.WriteLine(7 % 2); // 余
            Console.ReadKey();
            int[][] images = new int[3][];
            images[0] = new int[] { 100 };
            images[1] = new int[] { 200 };
            images[2] = new int[] { 100 };
            code.ImageSmoother(images);

            var result3 = code.FindRestaurant(new string[] { "KFC", "K" }, new string[] { "KFC", "K" });
            Console.WriteLine(result3);

            code.InorderTraversal(root);
            int[][] VideoStitchingParam = new int[6][];
            VideoStitchingParam[0] = new int[] { 0, 2 };
            VideoStitchingParam[1] = new int[] { 4, 6 };
            VideoStitchingParam[2] = new int[] { 8, 10 };
            VideoStitchingParam[3] = new int[] { 1, 9 };
            VideoStitchingParam[4] = new int[] { 1, 5 };
            VideoStitchingParam[5] = new int[] { 5, 9 };
            var re = code.VideoStitching(VideoStitchingParam, 10);
            int[][] matrix1 = new int[3][];
            matrix1[0] = new int[] { 1, 10 };
            matrix1[1] = new int[] { 9, 1 };
            matrix1[2] = new int[] { 8, 1 };
            code.FindCenter(matrix1);
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 10, 4, 2 };
            matrix[1] = new int[] { 9, 3, 8, 7 };
            matrix[2] = new int[] { 15, 16, 17, 12 };
            code.LuckyNumbers(matrix);
            Console.ReadKey();
            var max = code.FindMaxAverage(new[] { 1, 12, -5, -6, 50, 3 }, 4);
            //  LeetCode.TestWeightBagProblem(new int[] { 1, 3, 4,4 }, new int[] { 15, 20, 30,57 }, 4);
            //  var res=  code.LastStoneWeightII(new int[] { 2, 7, 4, 1, 8, 1 });
            var res = code.GenerateMatrix(5);
            var result = code.CountKDifference(new int[] { 1 }, 1);
            code.SimplifiedFractions(6);
            Console.WriteLine("res===>" + result);
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    Console.Write(res[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.WriteLine(res);
            //int[][] matrix = new int[4][];
            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    matrix[i] = new int[4];
            //}

            //matrix[0] = new int[] { 1, 2, 3, 4 };
            //matrix[1] = new int[] { 5, 6, 7, 8 };
            //matrix[2] = new int[] { 9, 10, 11, 12 };
            //matrix[3] = new int[] { 13, 14, 15, 16 };
            ////var result = code.SpiralOrder(matrix);
            //List<string> list = new List<string>();
            ////  HashSet<string> hashSet = new HashSet<string>();
            //list.Add("leet");
            //list.Add("code");

            //   var result = code.WordBreak("leetcode", list);
            //   Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
