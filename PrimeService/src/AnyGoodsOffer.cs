using PrimeService;
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
        public override void Apply(Check check)
        {
            if(totalCost <= check.GetTotalCost())
            {
                check.AddPoints(points);
            }
        }
    }
}