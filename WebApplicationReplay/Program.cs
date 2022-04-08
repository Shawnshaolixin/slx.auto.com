using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationReplay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            string host = "https://kaoshiapi.jxedt.com/robot/listRobotTrack";
            var url = host + "?beginTime=2022-03-182016:01:03.8036&endTime=2022-03-17%2016:01:03.804&deviceId=28a01e64562b3205";
            var s = httpClient.GetAsync(new Uri(url)).GetAwaiter().GetResult();
            var reuslt = s.Content.ReadAsStringAsync();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
