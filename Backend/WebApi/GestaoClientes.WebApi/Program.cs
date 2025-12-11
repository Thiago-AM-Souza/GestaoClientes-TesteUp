using GestaoClientes.WebApi.API.Bootstrapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiBootstrapper();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
