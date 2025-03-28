using System.Reflection;
using Vivi.Infrastructure.Core;
using Vivi.SharedKernel.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
var webApiAssembly = Assembly.GetExecutingAssembly();
var serviceInfo = ServiceInfo.CreateInstance(webApiAssembly);
// Add services to the container.

builder.Services.AddControllers();

var app = builder
    .Default(serviceInfo)
    .Build();

//Middlewares
app.UseVivi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
