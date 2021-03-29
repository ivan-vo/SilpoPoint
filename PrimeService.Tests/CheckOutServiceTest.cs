using System;
using Xunit;
using PrimeService;

namespace PrimeService.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckoutServiceTest()
        {
            CheckoutService CheckoutService = new CheckoutService();
            CheckoutService.OpenCheck();

            CheckoutService.AddProduct(new Product(7, "Milk"));
            Check check = CheckoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 7);

        }

        [Fact]
        public void closeCheck__withTwoProduc()
        {
            CheckoutService CheckoutService = new CheckoutService();
            CheckoutService.OpenCheck();

            CheckoutService.AddProduct(new Product(7, "Milk"));
            CheckoutService.AddProduct(new Product(3, "Bred"));
            Check check = CheckoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 10);

        }
    }
}
