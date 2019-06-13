using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using slx.auto.com.OAuth.Common;

namespace slx.auto.com.OAuth
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region OAuth
            //            services.AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = OAuthDefaults.DisplayName;
            //    })
            //.AddCookie()
            //.AddOAuth(OAuthDefaults.DisplayName, options =>
            //{
            //options.ClientId = "oauth.code";
            //options.ClientSecret = "secret";
            //options.AuthorizationEndpoint = "https://oidc.faasx.com/connect/authorize";
            //options.TokenEndpoint = "https://oidc.faasx.com/connect/token";
            //options.CallbackPath = "/signin-oauth";
            //options.Scope.Add("openid");
            //options.Scope.Add("profile");
            //options.Scope.Add("email");
            //options.SaveTokens = true;
            //        // 事件执行顺序 ：
            //        // 1.创建Ticket之前触发
            //        options.Events.OnCreatingTicket = context => Task.CompletedTask;
            //        // 2.创建Ticket失败时触发
            //        options.Events.OnRemoteFailure = context => Task.CompletedTask;
            //        // 3.Ticket接收完成之后触发
            //        options.Events.OnTicketReceived = context => Task.CompletedTask;
            //        // 4.Challenge时触发，默认跳转到OAuth服务器
            //        // options.Events.OnRedirectToAuthorizationEndpoint = context => context.Response.Redirect(context.RedirectUri);
            //    }); 
            #endregion
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
.AddCookie()
.AddOpenIdConnect(o =>
{
    o.ClientId = "oidc.hybrid";
    o.ClientSecret = "secret";

    // 若不设置Authority，就必须指定MetadataAddress
    o.Authority = "https://oidc.faasx.com/";
    // 默认为Authority+".well-known/openid-configuration"
    //o.MetadataAddress = "https://oidc.faasx.com/.well-known/openid-configuration";
    o.RequireHttpsMetadata = false;

    // 使用混合流
    o.ResponseType = OpenIdConnectResponseType.CodeIdToken;
    // 是否将Tokens保存到AuthenticationProperties中
    o.SaveTokens = true;
    // 是否从UserInfoEndpoint获取Claims
    o.GetClaimsFromUserInfoEndpoint = true;
    // 在本示例中，使用的是IdentityServer，而它的ClaimType使用的是JwtClaimTypes。
    o.TokenValidationParameters.NameClaimType = "name"; //JwtClaimTypes.Name;

    // 以下参数均有对应的默认值，通常无需设置。
    //o.CallbackPath = new PathString("/signin-oidc");
    //o.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
    //o.RemoteSignOutPath = new PathString("/signout-oidc");
    //o.Scope.Add("openid");
    //o.Scope.Add("profile");
    //o.ResponseMode = OpenIdConnectResponseMode.FormPost; 

    /***********************************相关事件***********************************/
    // 未授权时，重定向到OIDC服务器时触发
    //o.Events.OnRedirectToIdentityProvider = context => Task.CompletedTask;

    // 获取到授权码时触发
    //o.Events.OnAuthorizationCodeReceived = context => Task.CompletedTask;
    // 接收到OIDC服务器返回的认证信息（包含Code, ID Token等）时触发
    //o.Events.OnMessageReceived = context => Task.CompletedTask;
    // 接收到TokenEndpoint返回的信息时触发
    //o.Events.OnTokenResponseReceived = context => Task.CompletedTask;
    // 验证Token时触发
    //o.Events.OnTokenValidated = context => Task.CompletedTask;
    // 接收到UserInfoEndpoint返回的信息时触发
    //o.Events.OnUserInformationReceived = context => Task.CompletedTask;
    // 出现异常时触发
    //o.Events.OnAuthenticationFailed = context => Task.CompletedTask;

    // 退出时，重定向到OIDC服务器时触发
    //o.Events.OnRedirectToIdentityProviderForSignOut = context => Task.CompletedTask;
    // OIDC服务器退出后，服务端回调时触发
    //o.Events.OnRemoteSignOut = context => Task.CompletedTask;
    // OIDC服务器退出后，客户端重定向时触发
    //o.Events.OnSignedOutCallbackRedirect = context => Task.CompletedTask;

});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            // 授权，与上一章Cookie认证中的实现一样
            app.UseAuthorize();
            // 我的信息
            app.Map("/profile", builder => builder.Run(async context =>
            {
                await context.Response.WriteHtmlAsync(async res =>
                {
                    await res.WriteAsync($"<h1>你好，当前登录用户： {HttpResponseExtensions.HtmlEncode(context.User.Identity.Name)}</h1>");
                    await res.WriteAsync("<a class=\"btn btn-default\" href=\"/Account/Logout\">退出</a>");

                    await res.WriteAsync($"<h2>AuthenticationType：{context.User.Identity.AuthenticationType}</h2>");

                    await res.WriteAsync("<h2>Claims:</h2>");
                    await res.WriteTableHeader(new string[] { "Claim Type", "Value" }, context.User.Claims.Select(c => new string[] { c.Type, c.Value }));

                    // 在第一章中介绍过HandleAuthenticateOnceAsync方法，在此调用并不会有多余的性能损耗。
                    var result = await context.AuthenticateAsync();
                    await res.WriteAsync("<h2>Tokens:</h2>");
                    await res.WriteTableHeader(new string[] { "Token Type", "Value" }, result.Properties.GetTokens().Select(token => new string[] { token.Name, token.Value }));
                });
            }));
            // 本地退出
            app.Map("/signout", builder => builder.Run(async context =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await context.Response.WriteHtmlAsync(async res =>
                {
                    await res.WriteAsync($"<h1>Signed out {HttpResponseExtensions.HtmlEncode(context.User.Identity.Name)}</h1>");
                    await res.WriteAsync("<a class=\"btn btn-default\" href=\"/\">Home</a>");
                });
            }));

            // 远程退出
            app.Map("/signout-remote", builder => builder.Run(async context =>
            {
                await context.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties()
                {
                    RedirectUri = "/signout"
                });
            }));
            // 退出
            app.Map("/Account/Logout", builder => builder.Run(async context =>
            {
                await context.SignOutAsync();
                context.Response.Redirect("/");
            }));

            // 首页
            app.Run(async context =>
            {
                await context.Response.WriteHtmlAsync(async res =>
                {
                    await res.WriteAsync($"<h2>Hello OAuth Authentication</h2>");
                    await res.WriteAsync("<a class=\"btn btn-default\" href=\"/profile\">我的信息</a>");
                });
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
