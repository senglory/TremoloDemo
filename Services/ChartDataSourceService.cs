using TremoloDemo.Domain.Entities;
using TremoloDemo.Interfaces;
using TremoloDemo.Interfaces.DTO;

namespace TremoloDemo.Services;

public class ChartDataSourceService : IChartDataSourceService
{
    public async Task<IEnumerable<ElectricityProductDto>> GetChartDataForConsumptionAsync(
        int consumption,
        CancellationToken ct = default
        )
    {
        var productA = new ProductA();
        var productB = new ProductB();
        var t1 = Task.Run(() =>
            productA.Calculate(consumption)
            , ct);

        var t2 = Task.Run(() =>
            productB.Calculate(consumption)
            , ct);

        var allTasks = new Dictionary<ValueTask<decimal>, IElectricityProduct>() { 
            { new ValueTask<decimal>(t1), productA}, 
            { new ValueTask<decimal>(t2), productB}
        };
        var allTasksToWait = allTasks.Keys.Select(x => x.AsTask());
        await Task.WhenAll(allTasksToWait);

        var result = new List<ElectricityProductDto>();

        foreach (var task
                 in allTasks.Keys)
        {
            result.Add(  new ElectricityProductDto()
                {
                    Name = allTasks[task].Name,
                    TotalSum = task.Result
                });
        }

        result = result.OrderBy(x => x.TotalSum).ToList();

        return result;
    }
}
