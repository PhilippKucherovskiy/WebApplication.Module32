using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Module32
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogDatabase(HttpContext context, IBlogRepository repository)
        {
            var request = new Request
            {
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await repository.AddRequest(request);
        }

        public async Task InvokeAsync(HttpContext context, IBlogRepository repository)
        {
            LogConsole(context);
            await LogDatabase(context, repository);

            await _next.Invoke(context);
        }
    }
}
