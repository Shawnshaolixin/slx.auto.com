using Autofac;
using Surging.Core.Codec.MessagePack;
using Surging.Core.Consul;
using Surging.Core.Consul.Configurations;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.DotNetty;
using Surging.Core.EventBusRabbitMQ;
using Surging.Core.Log4net;
using Surging.Core.ProxyGenerator;
using Surging.Core.ServiceHosting;
using Surging.Core.ServiceHosting.Internal.Implementation;
using System;

namespace slx.auto.com.host
{
    class Program
    {
        private static void Main(string[] args)
        {

            var host = new ServiceHostBuilder()
              .RegisterServices(builder =>
              {
                  builder.AddMicroService(option =>
                  {
                      option.AddServiceRuntime();//
                                                 //option.UseZooKeeperManager(new ConfigInfo("127.0.0.1:2181"));//Use Zookeeper Manage
                      option.UseConsulManager(new ConfigInfo("127.0.0.1:8500"));//Use Consul Manage
                      option.UseDotNettyTransport();//Use DotNetty Transport
                      option.UseRabbitMQTransport();//Use Rabbitmq Transport
                      option.AddRabbitMQAdapt();//Based on rabbitmq consumer service  adapter
                                                //option.UseProtoBufferCodec();//Based on protobuf serialization codec
                      option.UseMessagePackCodec();//Based on messagepack serialization codec
                      builder.Register(p => new CPlatformContainer(ServiceLocator.Current));//Initialize the injection container
                  });
              })
          .SubscribeAt() //News subscription
              .UseServer("127.0.0.1", 98)
          //.UseServer("127.0.0.1", 98，“true”) //Token automatically generated
          //.UseServer("127.0.0.1", 98，“123456789”) //Fixed password token
          .UseLog4net("Configs/log4net.config") //Use log4net to generate the log
              .UseLog4net()  //Use log4net to generate the log
              .UseStartup<Startup>()
              .Build();

            using (host.Run())
            {
                Console.WriteLine($"服务端启动成功，{DateTime.Now}。");
            }
            // Get  a reference to the IUserService with instance ID "user".
            var user = ServiceLocator.GetService<IServiceProxyFactory>().CreateProxy<IUserService>("User");

            // Send request and await the response.
            Console.WriteLine(user.SayHello("fanly").GetAwaiter().GetResult());
            Console.ReadKey();
        }
    }
}
