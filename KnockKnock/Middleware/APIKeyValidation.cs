using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace KnockKnock.Middleware
{
    public class APIKeyValidation
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _settings;

        public APIKeyValidation(RequestDelegate next, IOptions<AppSettings> options)
        {
            _next = next;
            _settings = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Query.ContainsKey("api_key"))
            {
                await _next.Invoke(context);
                return;
            }
            else
            {
                if (context.Request.Query["api_key"] != _settings.api_key)
                {
                    context.Response.StatusCode = 401; //UnAuthorized
                    await context.Response.WriteAsync("Invalid User Key");
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }
}
