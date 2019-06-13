using System;
using System.Net.Http;

namespace Rose
{
    class Program
    {
        static void Main(string[] args)
        {
             string url = "https://wenzi.zhibo8.cc/zhibo/nba/2019/0430265859.htm";
            // string url = "https://www.baidu.com/";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(httpClientHandler);
          var result = httpClient.GetStringAsync(new Uri(url)).GetAwaiter().GetResult();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
