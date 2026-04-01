using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Assignment6.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == HttpMethod.Post.Method)
            {
                using var reader = new StreamReader(httpContext.Request.Body);
                string body = await reader.ReadToEndAsync();

                var dictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                string error = "";

                if (!dictionary.ContainsKey("username"))
                    error = "Invalid input for 'username'";
                else if (!dictionary.ContainsKey("password"))
                    error = "Invalid input for 'password'";
                else
                {
                    string userName = dictionary["username"][0];
                    string password = dictionary["password"][0];

                    if (userName == "admin@example.com" && password == "admin1234")
                    {
                        httpContext.Response.StatusCode = 200;
                        await httpContext.Response.WriteAsync("Successful login");
                        return;
                    }
                    else
                    {
                        error = "Invalid login";
                    }
                }

                // 🔥 Only ONE place to write response
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync(error);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
