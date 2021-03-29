using System;
using PrimeService;
using System.Collections.Generic;

namespace PrimeService
{
    public class CheckoutService
    {
        private Check check;
        public void OpenCheck()
        {
            check = new Check();
            check.products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            check.products.Add(product);
        }
        public Check CloseCheck()
        {
            foreach(var product in check.products)
            {
                check.totalCost += product.price;
            }
            return check;
        }
    }
}
