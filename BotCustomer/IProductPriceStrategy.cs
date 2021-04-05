namespace BotCustomer
{
    public interface IProductPriceStrategy
    {
        decimal GetCurrentPrice(CustomerRequiredProduct customerNeededProduct);
    }
}