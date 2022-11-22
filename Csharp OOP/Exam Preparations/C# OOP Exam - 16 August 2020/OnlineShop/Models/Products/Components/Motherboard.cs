namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Component
    {
        private const double MOTHERBOARD_UNIT_OVERALL_PERFORMANCE_MULTIPLIER = 1.25;
        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * MOTHERBOARD_UNIT_OVERALL_PERFORMANCE_MULTIPLIER;
    }
}
