using PrimeService;
using System;

namespace PrimeService.Tests
{
    public class AnyGoodsOffer : Offer
    {
        public int totalCost;
        public int points;

        public AnyGoodsOffer(int totalCost, int points)
        {
            this.totalCost = totalCost;
            this.points = points;
        }
        public AnyGoodsOffer(int totalCost, int points, DateTime offerDate)
        {
            this.totalCost = totalCost;
            this.points = points;
            this.offerDate = offerDate;
        }
        public override void Apply(Check check)
        {
            if(totalCost <= check.GetTotalCost())
            {
                AddPoints(check,points);
            }
        }
    }
}