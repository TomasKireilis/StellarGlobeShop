using MediatR;
using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobeShop.MyShop.Service.Application.Commands
{
    public class ProductPurchaseCommand : IRequest<ProductPurchase>
    {
        public ProductPurchase ProductPurchase { get; set; }
    }
}