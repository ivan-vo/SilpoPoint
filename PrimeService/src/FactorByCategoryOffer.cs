using System;
namespace PrimeService.Tests
{
    public class FactorByCategoryOffer : Offer
    {
        public Category category;
        public int factor;

        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }
        public FactorByCategoryOffer(Category category, int factor, DateTime offerDate)
        {
            this.category = category;
            this.factor = factor;
            this.offerDate = offerDate;
        }
        public override void Apply(Check check)
        {
            int points = check.GetCostByCategory(category);
            AddPoints(check, points * (factor - 1));
        }
    }
}