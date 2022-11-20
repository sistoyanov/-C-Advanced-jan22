namespace OnlineShop.Models.Products.Components
{
    public class CentralProcessingUnit : Component
    {
        private const double CENTRAL_PROCESSING_UNIT_OVERALL_PERFORMANCE_MULTIPLIER = 1.25;
        public CentralProcessingUnit(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * CENTRAL_PROCESSING_UNIT_OVERALL_PERFORMANCE_MULTIPLIER;
    }
}
