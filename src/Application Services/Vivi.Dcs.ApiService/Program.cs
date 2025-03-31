using NLog;
using System.Reflection;
using Vivi.Infrastructure.Core;
using Vivi.SharedKernel.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
var webApiAssembly = Assembly.GetExecutingAssembly();
var serviceInfo = ServiceInfo.CreateInstance(webApiAssembly);
// Add services to the container.

builder.Services.AddControllers();
try
{
    var app = builder
    .Default(serviceInfo)
    .Build();

    //Middlewares
    app.UseVivi();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
finally
{
    LogManager.Shutdown();
}