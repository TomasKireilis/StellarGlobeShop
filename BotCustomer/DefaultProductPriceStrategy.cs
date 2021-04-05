using System;

namespace BotCustomer
{
    internal class DefaultProductPriceStrategy : IProductPriceStrategy
    {
        private readonly decimal _maxPriceToPay = 50;

        public DefaultProductPriceStrategy()
        {
        }

        public DefaultProductPriceStrategy(decimal maxPriceToPay)
        {
            _maxPriceToPay = maxPriceToPay;
        }

        public decimal GetCurrentPrice(CustomerRequiredProduct customerNeededProduct)
        {
            return Math.Min(
                customerNeededProduct.StartingPrice +
                customerNeededProduct.ShopsVisited * customerNeededProduct.StartingPrice / 10, _maxPriceToPay);
        }
    }
}