var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();


app.UseHttpsRedirection();


app.MapGet("/" , () =>
{
    return Results.Ok(new
    {
        text = "Ini adalah webapi"
    });
});


app.Run();