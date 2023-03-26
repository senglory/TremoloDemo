using TremoloDemo.Domain.Entities;

namespace TremoloDemo.Tests
{
    public class TesDomainModel
    {
        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        [InlineData(6000, 1380)]
        public void TestProductA_TotalsShouldMatch(int kWth, decimal expectedTotal)
        {
            var product = new ProductA();
            var total = product.Calculate(kWth);
            Assert.Equal(expectedTotal, total);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        public void TestProductB_TotalsShouldMatch(int kWth, decimal expectedTotal)
        {
            var product = new ProductB();
            var total = product.Calculate(kWth);
            Assert.Equal(expectedTotal, total);
        }
    }
}