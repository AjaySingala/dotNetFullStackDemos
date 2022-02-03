using Xunit;

namespace PrimeService.Tests
{
    public class PrimeService_IsPrimeShould
    {
        //[Fact]
        //public void IsPrime_InputIs1_ReturnFalse()
        //{
        //    var primeService = new PrimeService();
        //    bool result = primeService.IsPrime(1);

        //    Assert.False(result, "1 should not be prime");
        //}

        //[Fact]
        //public void IsPrime_InputIs0_ReturnFalse()
        //{
        //    var primeService = new PrimeService();
        //    bool result = primeService.IsPrime(0);

        //    Assert.False(result, "0 should not be prime");
        //}

        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}