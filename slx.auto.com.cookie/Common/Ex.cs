using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slx.auto.com.cookie.Common
{
    public static class Ex
    {
        public static IApplicationBuilder UseAuthorize(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    await next();
                }
                else
                {
                    var user = context.User;
                    if (user?.Identity?.IsAuthenticated ?? false)
                    {
                        await next();
                    }
                    else
                    {
                        await context.ChallengeAsync();
                    }
                }
            });
        }
    }
}
