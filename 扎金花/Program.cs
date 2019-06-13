using System;
using System.Collections.Generic;
using System.Linq;

namespace 扎金花
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 1; i++)
            {
                Gen();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gen()
        {
            string[] pais = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            //随机 0-53，
            //甲乙分别随机 3次

            bool[] arr = new bool[51];
            for (int k = 0; k < arr.Length; k++)
            {
                arr[k] = true;
            }
            int renCount = 6;
            Random random = new Random();
            int i = 0;

            List<PaiModel> jia = new List<PaiModel>();
            List<PaiModel> yi = new List<PaiModel>();
            List<PaiModel> bing = new List<PaiModel>();
            List<PaiModel> ding = new List<PaiModel>();
            List<PaiModel> wu = new List<PaiModel>();
            List<PaiModel> ji = new List<PaiModel>();
            while (i < 3 * renCount)
            {

                var r = random.Next(0, 51);
                if (!arr[r])
                {
                    continue;
                }
                arr[r] = false;
                var yu = r % 13;

                var name = "";
                var color = "";
                if (r / 13 == 0)
                {
                    color = "黑桃♠";
                    name = $"{pais[yu]}";
                }
                else if (r / 13 == 1)
                {
                    color = "红桃♥";
                    name = $"{pais[yu]}";
                }
                else if (r / 13 == 2)
                {
                    color = "花子♣";
                    name = $"{pais[yu]}";
                }
                else if (r / 13 == 3)
                {
                    color = "片子♦";
                    name = $"{pais[yu]}";
                }
                i++;
                if (i % renCount == 0)//偶数
                {
                    jia.Add(new PaiModel
                    {
                        Index = yu,
                        Num = r,
                        Color = color,
                        Desc = name
                    });
                }
                else if (i % renCount == 1)
                {
                    yi.Add(new PaiModel
                    {
                        Index = yu,
                        Num = r,
                        Color = color,
                        Desc = name
                    });
                }
                else if (i % renCount == 2)
                {
                    bing.Add(new PaiModel
                    {
                        Index = yu,
                        Num = r,
                        Color = color,
                        Desc = name
                    });
                }
                else if (i % renCount == 3)
                {
                    ding.Add(new PaiModel
                    {
                        Index = yu,
                        Num = r,
                        Color = color,
                        Desc = name
                    });
                }
                else if (i % renCount == 4)
                {
                    wu.Add(new PaiModel
                    {
                        Index = yu,
                        Num = r,
                        Color = color,
                        Desc = name
                    });
                }
                else if (i % renCount == 5)
                {
                    ji.Add(new PaiModel
                    {
                        Index = yu,
                        Num = r,
                        Color = color,
                        Desc = name
                    });
                }
            }

            Console.WriteLine("甲的牌是：");
            foreach (var item in jia.OrderBy(j => j.Index))
            {
                Console.Write($"{item.Color}{item.Desc} ");

            }
            Console.WriteLine();
            Console.WriteLine("乙的牌是：");
            foreach (var item in yi.OrderBy(j => j.Index))
            {
                Console.Write($"{item.Color}{item.Desc} ");
            }
            Console.WriteLine();
            Console.WriteLine("丙的牌是：");
            foreach (var item in bing.OrderBy(j => j.Index))
            {
                Console.Write($"{item.Color}{item.Desc} ");
            }
            Console.WriteLine();
            Console.WriteLine("丁的牌是：");
            foreach (var item in ding.OrderBy(j => j.Index))
            {
                Console.Write($"{item.Color}{item.Desc} ");
            }
            Console.WriteLine();
            Console.WriteLine("戊的牌是：");
            foreach (var item in wu.OrderBy(j => j.Index))
            {
                Console.Write($"{item.Color}{item.Desc} ");
            }
            Console.WriteLine();
            Console.WriteLine("己的牌是：");
            foreach (var item in ji.OrderBy(j => j.Index))
            {
                Console.Write($"{item.Color}{item.Desc} ");
            }
        }
    }
    public class PaiModel
    {
        public int Num { get; set; }
        public string Color { get; set; }
        public string Desc { get; set; }
        public int Index { get; set; }
    }
}

