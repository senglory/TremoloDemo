using TremoloDemo.Api.Requests;
using TremoloDemo.Api.Validators;

namespace TremoloDemo.Api.Helpers;

public static class FluentValidationHelper
{
    public static async Task ValidateConsumptionRequest(ConsumptionRequest request)
    {
        var validator = await new ConsumptionRequestValidation().ValidateAsync(request);
        if (!validator.IsValid)
            throw new ArgumentException(validator.ToString());
    }
}
