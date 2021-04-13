using MyShop.Application.Application.BackgroundServices.MessageBusHanders;

namespace MyShop.Application.Application.Commands
{
    public class ProductPurchaseCommand : IRequest<ProductPurchase>
    {
        public ProductPurchase ProductPurchase { get; set; }
    }
}