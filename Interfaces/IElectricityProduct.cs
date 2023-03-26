namespace TremoloDemo.Interfaces;

public interface IElectricityProduct
{
    string Name { get; }
    decimal Calculate(int kWth);
}
