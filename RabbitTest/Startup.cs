using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitTest.Model;

namespace RabbitTest
{
    public class Startup
    {
        private readonly ILogger _logger;
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency>();
            _logger.LogInformation("Added MyDependency to services");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My Api",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",

                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty

                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Use under LICX"

                    }
                });
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "haha";//配置路由
            });
            app.UseMvc();
        }
    }
}
