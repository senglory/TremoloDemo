using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TremoloDemo.Api;
using TremoloDemo.Interfaces;
using TremoloDemo.Interfaces.DTO;

namespace TremoloDemo.Tests;

public class TestChartDataSourceService
{
    private TestServer _server;

    public TestChartDataSourceService()
    {
        var cfg = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .AddEnvironmentVariables()
            .Build();

        _server = new TestServer(
            new WebHostBuilder()
                .UseEnvironment("Development")
                .UseConfiguration(cfg)
                .ConfigureServices(services =>
                {
                    services.AddTransient(typeof(ILogger<>), typeof(NullLogger<>));
                })
                .UseStartup<Startup>())
            ;

    }

    [Theory]
    [InlineData(3500)]
    [InlineData(4500)]
    [InlineData(6000)]
    public async Task TestGetChartDataForConsumptionAsync_ShouldMatchGenericRequirements(int kWth)
    {
        var svc = _server.Services.GetService<IChartDataSourceService>();
        var res = await svc.GetChartDataForConsumptionAsync(kWth);
        Assert.NotNull(res);
        var allData = new List<ElectricityProductDto>(res);
        Assert.Equal(2, allData.Count);
        Assert.True(allData.First().TotalSum < allData.Last().TotalSum);
    }
}
