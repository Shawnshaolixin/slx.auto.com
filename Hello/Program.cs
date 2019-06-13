using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hello
{
    public static class Extensions
    {
        public static string Convert(this string template, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            if (parameters == null) return template;

            foreach (var item in parameters)
            {
                template = template.Replace(item.Key, item.Value);
            }

            template = Regex.Replace(template, "\r\n", "");
            return template;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Guid[] guids = { new Guid("B4621DE3-3F35-4182-8505-1CCF0408DC9E"),
            new Guid("B4621DE3-3F35-4182-8505-1CCF0408DC9E"),
            new Guid("B4621DE3-3F35-4182-8505-1CCF0408DC9E"),
            new Guid("B4621DE3-3F35-4182-8505-1CCF0408DC9E"),
            new Guid("B4621DE3-3F35-4182-8505-1CCF0408DC9E")};

            var where = string.Join("','", guids);
            Console.WriteLine(where);
            Console.ReadKey();

            string text = " 订单{1}本次付款：{2},{3} {3}本单结清,";
            string pat = @"{\d}";
            Regex r = new Regex(pat);
            MatchCollection m = r.Matches(text);
            Console.WriteLine( m.Count);

            Console.ReadKey();
            List<string> phones = new List<string>();
            phones.Add("138999999");
            phones.Add("1212");
            phones.Add("21");
            phones.Add("111111");
            StringBuilder sb = new StringBuilder();
            foreach (var item in phones)
            {
                sb.Append("'").Append(item).Append("',");
            }
            sb.Remove(sb.Length - 1, 1).ToString();
            //   var s = str.Replace("{1}", "13888888888").Replace("{2}", "8988").Replace("{3}", "测试啊");
            //foreach (var item in parameters)
            //{
            //    template = template.Replace($"<#{item.Key}#>", item.Value);
            //}

            //int[] arr = new int[] { 950, 985, 998 };

            //Random random = new Random();
            //int i = 1;
            //int j = 1;
            //int k = 1;
            //int n = 1;
            //int m = 1;
            //while (i < 10000)
            //{
            //    Console.WriteLine($"第{i++}次");
            //    var r = random.Next(1, 1000);


            //    if (r <= arr[0])
            //    {
            //        n++;
            //        Console.WriteLine("正常中奖，抽中1个易车币");
            //    }
            //    if (r > arr[0] && r <= arr[1])
            //    {
            //        m++;
            //        Console.WriteLine("普普通通，抽中2个易车币");
            //    }
            //    if (r > arr[1] && r <= arr[2])
            //    {
            //        k++;
            //        Console.WriteLine("还可以，抽中10个易车币");
            //    }
            //    if (r > arr[2])
            //    {
            //        Console.WriteLine("牛逼了，抽中100个易车币");
            //        j++;
            //    }
            //}
            //Console.WriteLine($"统计：抽了{i}次，1易车币中了{n}次，2易车币中了{m}次，10易车币中了{k}次,100易车币中了{j}次");
            Console.ReadKey();
        }
        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("方法1111111111111111");
                }
            });

        }

        public static async Task Method2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("方法22222222222222");
                }
            });
        }
    }
}
