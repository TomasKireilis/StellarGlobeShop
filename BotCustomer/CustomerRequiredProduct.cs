using System.Collections.Generic;

namespace BotCustomer
{
    public class CustomerRequiredProduct
    {
        public CustomerRequiredProduct(decimal startingPrice)
        {
            StartingPrice = startingPrice;
        }

        public string ProductID { get; set; }
        public decimal StartingPrice { get; }

        public int ShopsVisited { get; set; }
        public List<string> ShopsLeftToVisit { get; set; } = new List<string>();
    }
}