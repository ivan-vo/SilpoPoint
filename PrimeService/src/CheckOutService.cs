using System;
using PrimeService;
using System.Collections.Generic;
using PrimeService.Tests;

namespace PrimeService
{
    public class CheckoutService
    {
        private Check check;
        public void OpenCheck()
        {
            check = new Check();
        }
        public void AddProduct(Product product)
        {
            if (check == null)
            {
                OpenCheck();
            }
            check.AddProduct(product);
        }
        public Check CloseCheck()
        {
            Check closedCheck = check;
            check = null;
            return closedCheck;
        }

        public void UseOffer(AnyGoodsOffer offer)
        {
            if (offer.GetType() == (typeof(FactorByCategoryOffer)))
            {
                FactorByCategoryOffer fbOffer = (FactorByCategoryOffer)offer;
                int points = check.GetCostByCategory(fbOffer.category);
                check.AddPoints(points * (fbOffer.factor - 1));
            }
            else
            {
                if (offer.totalCost <= check.GetTotalCost())
                {
                    check.AddPoints(offer.points);   
                }
            }
        }
    }
}
