using GestaoClientes.WebApi.API.Bootstrapper;
using GestaoClientes.WebApi.API.Middlewares;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiBootstrapper(builder.Configuration);

var app = builder.Build();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
