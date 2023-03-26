using Microsoft.AspNetCore.Mvc;
using TremoloDemo.Api.Helpers;
using TremoloDemo.Api.Requests;
using TremoloDemo.Interfaces;

namespace TremoloDemo.Api.Controllers;

[ApiController]
[Route(Constants.ApiVersion + "/electricity")]
[Produces("application/json")]
public class ElectricityChartController : ControllerBase
{
    private readonly IChartDataSourceService _svc;

    public ElectricityChartController( IChartDataSourceService svc)
    {
        _svc=svc ?? throw new ArgumentNullException(nameof(svc));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost(Name = "chart")]
    public async Task<IActionResult> RetrieveChartData(ConsumptionRequest request, CancellationToken ct = default)
    {
        try
        {
            await FluentValidationHelper.ValidateConsumptionRequest(request);
            return Ok(_svc.GetChartDataForConsumptionAsync(request.Consumption, ct));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
