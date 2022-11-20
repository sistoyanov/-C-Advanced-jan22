namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        private const double DESKTOP_COMPUTER_OVERALL_PERFORMANCE = 15;
        public DesktopComputer(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price, DESKTOP_COMPUTER_OVERALL_PERFORMANCE)
        {
        }
    }
}
