using System;
using PrimeService;
using System.Collections.Generic;

namespace PrimeService
{
    public abstract class Offer
    {
        public DateTime offerDate;
        public abstract void Apply(Check check);

        public bool CheckOfferDate(Check check, int points)
        {
            if (DateTime.Today <= offerDate) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddPoints(Check check, int points)
        {
            if (CheckOfferDate(check, points))
            {
                check.AddPoints(points);
            }
        }
    }
}
