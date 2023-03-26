using System.Reflection;
using FluentValidation;
using TremoloDemo.Interfaces;
using TremoloDemo.Services;

namespace TremoloDemo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        using var app =
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder
                    => webHostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                            _ = config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                                .AddJsonFile("appSettings.json", false, true))
                        .UseStartup<Startup>())
                .Build();
        app.Run();
    }
}
