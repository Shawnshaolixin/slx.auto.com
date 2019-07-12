using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatRTest
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

            services.AddMediatR(typeof(Ping));
          //  services.AddMediatR(typeof(SomeEvent));
            //    var builder = new ContainerBuilder();

            //builder.RegisterType<Mediator>()
            //    .As<IMediator>()
            //    .InstancePerLifetimeScope();

            //builder.Register<ServiceFactory>(context =>
            //{
            //    var c = context.Resolve<IComponentContext>();
            //    return t => c.Resolve(t);
            //});
            //builder.RegisterAssemblyTypes(typeof(Ping).GetTypeInfo().Assembly).AsImplementedInterfaces();

            //   services.AddMediatR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }
    }
}
