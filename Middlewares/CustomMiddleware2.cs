using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.API.Middlewares
{
    public class CustomMiddleware2 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware-2 Entered\n");

            await next(context);

            await context.Response.WriteAsync("Custom Middleware-2 Exited\n");
        }

    }
}
