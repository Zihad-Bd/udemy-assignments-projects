var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var countryList = new[]
{
    new { Name = "United States", Id = 1 },
    new { Name = "Canada", Id = 2 },
    new { Name = "United Kingdom", Id = 3 },
    new { Name = "Japan", Id = 4 },
    new { Name = "India", Id = 5 }
};

app.MapGet("/countries", async (context) =>
{
    foreach(var country in countryList)
    {
        await context.Response.WriteAsync($"{country.Id}: {country.Name}\n");
    }
});

app.MapGet("/countries/{id:int:range(1, 100)}", async (context) =>
{
    int id = Convert.ToInt32(context.Request.RouteValues["id"]);
    if (id > 5)
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("[No Country]");
    }
    else
    {
        string countryName = countryList[id - 1].Name;
        await context.Response.WriteAsync($"{countryName}");
    }
});


app.MapFallback(async (context) =>
{
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("The CountryID should be between 1 and 100");
});

app.Run();
