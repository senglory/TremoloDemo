using FluentValidation;
using TremoloDemo.Api.Requests;

namespace TremoloDemo.Api.Validators;

public class ConsumptionRequestValidation : AbstractValidator<ConsumptionRequest>
{
    public ConsumptionRequestValidation()
    {
        RuleFor(x => x.Consumption)
            .GreaterThan(0)
            .WithMessage("Please enter a correct consumption value (kWh/year)");
    }
}
