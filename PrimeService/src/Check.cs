using System;
using PrimeService;
using System.Collections.Generic;

namespace PrimeService
{
    public class Check
    {
        private List<Product> products = new List<Product>();
        private int points = 0;

        public int GetTotalCost()
        {
            int totalCost = 0;
            foreach (var product in products)
            {
                totalCost += product.price;
            }
            return totalCost;
        }

        internal void AddProduct(Product product)
        {
            products.Add(product);
        }

        public int GetTotalPoints()
        {
            return GetTotalCost() + points;
        }

        internal void AddPoints(int points)
        {
            this.points += points;
        }

        internal int GetCostByCategory(Category category)
        {
            int totalCost = 0;
            foreach(var product in products)
            {
                if (product.category == category)
                {
                totalCost += product.price ;
                }
            }
            return totalCost;
        }
    }
}
