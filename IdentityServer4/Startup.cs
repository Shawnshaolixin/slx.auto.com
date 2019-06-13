using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace IdentityServer4
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
           AuthenticateRequest();

            services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(o =>
    {
        o.ClientId = "server.hybrid";
        o.ClientSecret = "secret";
        o.Authority = "https://demo.identityserver.io/";
        o.ResponseType = OpenIdConnectResponseType.CodeIdToken;
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
            app.UseAuthentication();
        }
    
        private void AuthenticateRequest()
        {
            // 创建一个用户身份，注意需要指定AuthenticationType，否则IsAuthenticated将为false。
            var claimIdentity = new ClaimsIdentity("myAuthenticationType");
            // 添加几个Claim 声明,就是添加了这个人的基本信息
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, "shaolixin"));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, "97065227@qq.com"));
            claimIdentity.AddClaim(new Claim(ClaimTypes.MobilePhone, "18888888888"));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Country, "china"));
            var principal = new ClaimsPrincipal(claimIdentity);
        
            var properties = new AuthenticationProperties();
            var ticket = new AuthenticationTicket(principal, properties, "myScheme");
            // 加密 序列化
            //  var token = JsonConvert(ticket);
        }
    }
}
