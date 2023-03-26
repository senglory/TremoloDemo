using TremoloDemo.Interfaces;

namespace TremoloDemo.Domain.Entities;

public class ProductB : IElectricityProduct
{
    public string Name => "Packaged tariff";

    public decimal Calculate(int kWth)
    {
        decimal baseCosts = 800; // €/year
        decimal additionalCosts = 0; // €/year

        if (kWth > 4000)
        {
            additionalCosts = (kWth - 4000) * 0.3M; // €/year
        }

        return baseCosts + additionalCosts;
    }
}
