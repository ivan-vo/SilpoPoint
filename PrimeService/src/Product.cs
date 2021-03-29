using System;
using PrimeService;
using System.Collections.Generic;

namespace PrimeService
{
    public class Product
    {
        public int price;
        readonly string name;
        public Product(int price, string name)
        {
            this.price = price;
            this.name = name;
        }
    }
}
