using TremoloDemo.Interfaces.DTO;

namespace TremoloDemo.Interfaces;

public  interface IChartDataSourceService
{
    Task<IEnumerable<ElectricityProductDto>> GetChartDataForConsumptionAsync(int consumption, CancellationToken ct=default);
}

