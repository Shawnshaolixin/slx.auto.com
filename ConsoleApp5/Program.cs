using System;
using System.Net.Http;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var html = client.GetStringAsync("https://zh.wikipedia.org/wiki/%E6%9C%9D%E9%B2%9C%E6%B0%91%E4%B8%BB%E4%B8%BB%E4%B9%89%E4%BA%BA%E6%B0%91%E5%85%B1%E5%92%8C%E5%9B%BD").GetAwaiter().GetResult();
         

            Console.WriteLine("Hello World!");
        }
    }
}
