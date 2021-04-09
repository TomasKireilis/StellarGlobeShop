using StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobe.MyShop.Application.BackgroundServices.DomainHandlers.Interfaces
{
    public interface IProductPurchaseHandler
    {
        void HandleProductPurchase(ProductPurchase productPurchase);
    }
}