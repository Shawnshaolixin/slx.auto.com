using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace slx.auto.com.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
       
            return WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
              // .UseUrls($"http://{ip}:{port}")
               ;
        }
    }
}
