using System;
using Xunit;
using PrimeService;

namespace PrimeService.Tests
{
    public class UnitTest1
    {
        private Product milk_7;
        private Product bread_3;
        private CheckoutService checkoutService;
        public UnitTest1()
        {
            checkoutService = new CheckoutService();
            checkoutService.OpenCheck();

            milk_7 = new Product(7, "Milk", Category.MILK);
            bread_3 = new Product(3, "Bred");
        }

        [Fact]
        public void CheckoutServiceTest()
        {
            checkoutService.AddProduct(milk_7);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 7);

        }

        [Fact]
        public void closeCheck__withTwoProduc()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalCost(), 10);
        }

        [Fact]
        public void AddProduct__WhenCheckIsClosed__OpenNewCheck()
        {
            checkoutService.AddProduct(milk_7);
            Check milkCheck = checkoutService.CloseCheck();

            Assert.Equal(milkCheck.GetTotalCost(), 7);

            checkoutService.AddProduct(bread_3);
            Check breadCheck = checkoutService.CloseCheck();

            Assert.Equal(breadCheck.GetTotalCost(), 3);
        }

        [Fact]
        public void CloseCheck__CalcTotalPoint()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 10);
        }

        [Fact]
        public void UseOffer__AddOfferPoints()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);

            checkoutService.UseOffer(new AnyGoodsOffer(6, 2, DateTime.Today));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 12);
        }

        [Fact]
        public void UseOffer__WhenColsLessThanRequire__DoNothing()
        {
            checkoutService.AddProduct(bread_3);

            checkoutService.UseOffer(new AnyGoodsOffer(6, 2, DateTime.Today));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 3);
        }

        [Fact]
        public void UseOffer__FactorByCategory()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);

            checkoutService.UseOffer(new FactorByCategoryOffer(Category.MILK, 2, DateTime.Today));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 31);
        }

        [Fact]
        public void UseOffer__FactorByCategory__WhenOfferDateIsValid()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);

            checkoutService.UseOffer(new FactorByCategoryOffer(Category.MILK, 2, DateTime.Today));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 31);
        }
        [Fact]
        public void UseOffer__FactorByCategory__WhenOfferDateIsNOTValid()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);

            checkoutService.UseOffer(new FactorByCategoryOffer(Category.MILK, 2, DateTime.Today.AddDays(-1)));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 17);
        }

        [Fact]
        public void UseOffer__AnyGoodsOffer__WhenOfferDateIsValid()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);

            checkoutService.UseOffer(new AnyGoodsOffer(15, 2, DateTime.Today));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 19);
        }

        [Fact]
        public void UseOffer__AnyGoodsOffer__WhenOfferDateIsNOTValid()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);

            checkoutService.UseOffer(new AnyGoodsOffer(15, 2, DateTime.Today.AddDays(-1)));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 17);
        }
        [Fact]
        public void UseAnyGoodsOffer__BeforCheckIsClosed__DateIsValid()
        {
            checkoutService.UseOffer(new AnyGoodsOffer(9, 2, DateTime.Today));
            checkoutService.AddProduct(milk_7);
            checkoutService.UseOffer(new AnyGoodsOffer(5, 2, DateTime.Today));
            checkoutService.AddProduct(bread_3);

            Check check = checkoutService.CloseCheck();

            Assert.Equal(check.GetTotalPoints(), 12);
        }
    }
}
