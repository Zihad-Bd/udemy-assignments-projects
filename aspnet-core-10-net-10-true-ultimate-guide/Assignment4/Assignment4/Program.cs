var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
    context.Response.StatusCode = 200;
    int firstNumber = 0, secondNumber = 0;
    string operation = "";
    string line1 = string.Empty;
    string line2 = string.Empty;
    string line3 = string.Empty;
    if (context.Request.Query.ContainsKey("firstNumber"))
    {
        bool result = int.TryParse(context.Request.Query["firstNumber"][0], out int number);
        if (result)
        {
            firstNumber = number; 
        }
        else
        {
            line1 = "Invalid input for 'firstNumber'";
            context.Response.StatusCode = 400;

        }
    }
    else
    {
        line1 = "Invalid input for 'firstNumber'";
        context.Response.StatusCode = 400;

    }
    if (context.Request.Query.ContainsKey("secondNumber"))
    {
        bool result = int.TryParse(context.Request.Query["secondNumber"][0], out int number);
        if (result)
        {
            secondNumber = number;
        }
        else
        {
            line2 = "Invalid input for 'secondNumber'";
            context.Response.StatusCode = 400;

        }
    }
    else
    {
        line2 = "Invalid input for 'secondNumber'";
        context.Response.StatusCode = 400;

    }
    if (context.Request.Query.ContainsKey("operation"))
    {
        operation = context.Request.Query["operation"][0];
        if (operation is not ("add" or "subtract" or "multiply" or "divide" or "remainder"))
        {
            line1 = "Invalid input for 'operation'";
            context.Response.StatusCode = 400;

        }
    }
    else
    {
        line1 = "Invalid input for 'operation'";
        context.Response.StatusCode = 400;

    }
    if ((operation is "divide" or "remainder") && secondNumber == 0)
    {
        line2 = "Invalid input for 'secondNumber'";
        context.Response.StatusCode = 400;
    }
    if (context.Response.StatusCode == 200)
    {
        int result = operation switch
        {
            "add" => firstNumber + secondNumber,
            "subtract" => firstNumber - secondNumber,
            "multiply" => firstNumber * secondNumber,
            "divide" => firstNumber / secondNumber,
            "remainder" => firstNumber % secondNumber,
        };
        await context.Response.WriteAsync(result.ToString());
    }
    else
    {
        string response = $"""
        {line1}
        {line2}
        {line3}
        """;
        await context.Response.WriteAsync(response);

    }
});

app.Run();
