using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobeShop.MyShop.Service.Application.BackgroundServices.DomainHandlers.Interfaces
{
    public interface IProductPurchaseHandler
    {
        void HandleProductPurchase(ProductPurchase productPurchase);
    }
}