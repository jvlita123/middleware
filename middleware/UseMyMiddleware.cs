using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace middleware
{
    public class UseMyMiddleware : ControllerBase
    {
        private RequestDelegate _next;

        public UseMyMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public Task Invoke(HttpContext context)
        {
            string path = context.Request.Path;

            if (path.Contains("/Privacy"))
                context.Response.Redirect("https://www.youtube.com/watch?v=6NAqDi0Gy5Y&t=1136s&ab_channel=Codewrinkles");
            return _next(context);

        }


    }
    public static class Midd
    {
        public static IApplicationBuilder UseUrlTransformMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UseMyMiddleware>();
        }
    }
}
