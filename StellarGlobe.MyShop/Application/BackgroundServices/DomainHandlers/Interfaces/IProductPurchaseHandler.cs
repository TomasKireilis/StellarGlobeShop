using StellarGlobe.MyShop.BackgroundServices.MessageBusHanders;

namespace StellarGlobe.MyShop.BackgroundServices.DomainHandlers.Interfaces
{
    public interface IProductPurchaseHandler
    {
        void HandleProductPurchase(ProductPurchase productPurchase);
    }
}