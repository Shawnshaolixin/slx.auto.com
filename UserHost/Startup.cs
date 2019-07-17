using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Consul;
using Grpc.Core;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UserHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var assemblies = new Assembly[] {
                    Assembly.Load("UserServiceDefination"),
                    Assembly.GetExecutingAssembly()
                };
            // 通过反射去拿
            MagicOnionServiceDefinition service = MagicOnionEngine.BuildServerServiceDefinition(assemblies,new MagicOnionOptions(true)
            {
                MagicOnionLogger = new MagicOnionLogToGrpcLogger()
            });
            Server server = new Server
            {
                Services = { service },
                Ports = { new ServerPort(this.Configuration["Service:LocalIPAddress"], Convert.ToInt32(this.Configuration["Service:Port"]) , ServerCredentials.Insecure) }
            };
            server.Start();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();


            ServiceEntity serviceEntity = new ServiceEntity
            {
                IP = this.Configuration["Service:LocalIPAddress"],
                Port = Convert.ToInt32(this.Configuration["Service:Port"]),
                ServiceName = this.Configuration["Service:Name"],
                ConsulIP = this.Configuration["Consul:IP"],
                ConsulPort = Convert.ToInt32(this.Configuration["Consul:Port"])
            };
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{serviceEntity.ConsulIP}:{serviceEntity.ConsulPort}"));//请求注册的 Consul 地址


            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                HTTP = this.Configuration["Service:Examination"],//健康检查地址
                Timeout = TimeSpan.FromSeconds(5)
            };

            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = serviceEntity.ServiceName,
                Address = serviceEntity.IP,
                Port = serviceEntity.Port,
                Tags = new[] { $"urlprefix-/{serviceEntity.ServiceName}" }//添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };

            consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）


            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册
            });

        }
        public class ServiceEntity
        {
            public string  IP { get; set; }
            public int Port { get; set; }
            public string ServiceName { get; set; }
            public string ConsulIP { get; set; }
            public int ConsulPort { get; set; }
        }
    }
}
