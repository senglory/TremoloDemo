using TremoloDemo.Interfaces;

namespace TremoloDemo.Domain.Entities;

public class ProductA : IElectricityProduct
{
    public string Name => "basic electricity tariff";

    public decimal Calculate(int kWth)
    {
        decimal baseCosts = 5 * 12;
        decimal consumptionCosts = kWth * 0.22M;
        return baseCosts + consumptionCosts;
    }
}
