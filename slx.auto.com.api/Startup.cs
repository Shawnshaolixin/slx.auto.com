using Consul;
using Grpc.Core;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace slx.auto.com.api
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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            string ip = Configuration["ip"];
            int port = Convert.ToInt32(Configuration["port"]);

            string serviceName = "MsgService";
            string serviceId = serviceName + Guid.NewGuid();



            using (var client = new ConsulClient(ConsulConfig))
            {
                client.Agent.ServiceRegister(new AgentServiceRegistration
                {
                    Address = this.Configuration["Service:LocalIPAddress"],
                    Port = Convert.ToInt32(this.Configuration["Service:Port"]),
                    ID = serviceId,
                    Name = serviceName,
                    Check = new AgentServiceCheck
                    {
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务停止多久 后反注册(注销)    
                        Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳 间隔    
                        HTTP = $"http://127.0.0.1:5000/api/health",//健康检查地址   
                        Timeout = TimeSpan.FromSeconds(5)
                    }
                }).Wait();

            }
            //程序正常退出的时候从 Consul 注销服务  
            //要通过方法参数注入 IApplicationLifetime
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                using (var client = new ConsulClient(ConsulConfig))
                { client.Agent.ServiceDeregister(serviceId).Wait(); }
            });
            // 通过反射去拿
            var assemblies = new Assembly[] {
                 Assembly.Load("slx.auto.com.iservice")
             };

            var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);

            Server server = new Server
            {
                Services = { service },
                Ports = { new ServerPort(this.Configuration["Service:LocalIPAddress"], Convert.ToInt32(this.Configuration["Service:Port"]), ServerCredentials.Insecure) }
            };


            // launch gRPC Server.
            server.Start();

        }
        private void ConsulConfig(ConsulClientConfiguration c)
        {
            c.Address = new Uri("http://127.0.0.1:8500");
            c.Datacenter = "dc1";
        }

    }
}
