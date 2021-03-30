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
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();

            checkoutService.AddProduct(new Product(7, "Milk"));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 7);

        }

        [Fact]
        public void closeCheck__withTwoProduc()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();

            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(3, "Bred"));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 10);

        }

        [Fact]
        public void AddProduct__WhenCheckIsClosed__OpenNewCheck()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();

            checkoutService.AddProduct(new Product(7, "Milk"));
            Check milkCheck = checkoutService.CloseCheck();

            Assert.Equal(milkCheck.GetTotalCost(), 7);

            checkoutService.AddProduct(new Product(3, "Bred"));
            Check breadCheck = checkoutService.CloseCheck();

            Assert.Equal(breadCheck.GetTotalCost(), 3);
        }
    }
}
