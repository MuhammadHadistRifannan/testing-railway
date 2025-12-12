var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");


var app = builder.Build();


app.UseHttpsRedirection();


app.MapGet("/" , () =>
{
    var key = Environment.GetEnvironmentVariable("APIKEY");
    return Results.Ok(new
    {
        text = "Ini adalah webapi" ,
        apikey = key ?? "Tidak ditemukan Key"
    });
});


app.Run();