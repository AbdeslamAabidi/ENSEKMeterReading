using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace ENSEKMeterReading.Api.Extensions
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var requestHost = httpContext.Request.Headers["origin"];

            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", requestHost.ToString());
            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Authorization, Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
            httpContext.Response.Headers.Add("Access-Control-Max-Age", "1728000");

            if (httpContext.Request.Method == "OPTIONS")
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                await httpContext.Response.WriteAsync("OK");
            }

            await _next(httpContext);
        }
    }
}
