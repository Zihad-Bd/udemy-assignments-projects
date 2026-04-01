using Assignment6.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    context => context.Request.Method == HttpMethod.Get.Method,
    innerApp =>
    {
        innerApp.Run(async innerContext =>
        {
            innerContext.Response.StatusCode = 200;
            innerContext.Response.WriteAsync("No response");
        });
    }
);
app.UseMyCustomMiddleware();


app.Run();
