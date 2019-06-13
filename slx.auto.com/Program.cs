using Consul;
using Grpc.Core;
using MagicOnion.Client;
using System;
using System.Linq;

namespace slx.auto.com
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var consulClient = new ConsulClient(c => c.Address = new Uri("http://127.0.0.1:8500")))
            {
                var services = consulClient.Agent.Services().GetAwaiter().GetResult().Response
                    .Values.Where(s => s.Service.Equals("MsgService", StringComparison.OrdinalIgnoreCase));
                if (!services.Any())
                {
                    Console.WriteLine("找不到服务的实例");
                }
                else
                {
                    //客户端负载均衡的一种策略 
                    var service = services.ElementAt(Environment.TickCount % services.Count());

                    Console.WriteLine($"服务名字={service.Service},IP={service.Address},Port={service.Port}");

                    var channel = new Channel(service.Address, service.Port, ChannelCredentials.Insecure);

                    // get MagicOnion dynamic client proxy
                    var client = MagicOnionClient.Create<IMyFirstService>(channel);

                    // call method.
                    var result = client.SumAsync(100, 200).GetAwaiter().GetResult();
                    Console.WriteLine("Client Received:" + result);
                }
                //foreach (var service in services.Values)
                //{
                //    Console.WriteLine($"服务名字={service.Service},IP={service.Address},Port={service.Port}");
                //}

            }
            // standard gRPC channel





            Console.ReadKey();
        }
    }
}
