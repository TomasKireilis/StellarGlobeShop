using MyShop.Application.Application.BackgroundServices.MessageBusHanders;

namespace MyShop.Application.Application.BackgroundServices.DomainHandlers.Interfaces
{
    public interface IProductPurchaseHandler
    {
        void HandleProductPurchase(ProductPurchase productPurchase);
    }
}