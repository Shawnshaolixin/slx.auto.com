using Consul;
using Grpc.Core;
using MagicOnion.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserServiceDefination;

namespace ClientTest
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            //注册的服务介个，这个可以用polly 做负载均衡
            var services = AvaliableServices("UserService", "").Result;

            foreach (var service in services)
            {
                var ip = service.Service.Address;
                var port = service.Service.Port;


                //  然后你就可以根据IP和端口拿到对于的服务
                var channel = new Channel(ip, port, ChannelCredentials.Insecure);

                var client = MagicOnionClient.Create<ICommonService>(channel);
                // 调用
                var result = client.Add(new UserServiceDefination.dto.AddRequestDTO
                {
                    A = 100,
                    B = 300
                }).ResponseAsync.Result;

                Console.WriteLine("Client Received:" + result);


            }
            Console.ReadKey();
        }
        public static async Task<ServiceEntry[]> AvaliableServices(string name, string tags)
        {
            var services = new List<ServiceEntry>();
            using (var client = new ConsulClient())
            {
                foreach (var tag in tags.Split(','))
                {
                    var result = await client.Health.Service(name, !string.IsNullOrEmpty(tag) ? tag : null, true).ConfigureAwait(false);
                    foreach (var item in result.Response)
                    {
                        if (!services.Any(service => service.Node.Address == item.Node.Address
                            && service.Service.Port == item.Service.Port))
                        {
                            services.Add(item);
                        }
                    }
                }
                //交集处理，仅取出完全匹配服务
                foreach (var tag in tags.Split(','))
                {
                    if (string.IsNullOrEmpty(tag))
                    {
                        continue;
                    }
                    var alsorans = services.Where(service => !service.Service.Tags.Contains(tag)).ToList();
                    foreach (var alsoran in alsorans)
                    {
                        services.Remove(alsoran);
                    }
                }
            }
            return services.ToArray();
        }
    }
}
