using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stockToSell = portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (stockToSell == null)
            {
                return $"{companyName} does not exist.";
            }

            if (stockToSell.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;
            portfolio.Remove(stockToSell);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) => portfolio.FirstOrDefault(s => s.CompanyName == companyName);

        public Stock FindBiggestCompany() => portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder output = new StringBuilder();
            
            output.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                output.AppendLine(stock.ToString());
            }

            return output.ToString().TrimEnd();
        }


    }
}
