using System;
using PrimeService;
using System.Collections.Generic;

namespace PrimeService
{
    public class Product
    {
        internal readonly int price;
        internal readonly string name;
        public Category category;
        public Product(int price, string name, Category category)
        {
            this.price = price;
            this.name = name;
            this.category = category;
        }
        public Product(int price, string name)
        {
            this.price = price;
            this.name = name;
        }
    }
}
