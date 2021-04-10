using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobe.MyShop.Application.Commands
{
    public class ProductPurchaseCommand : IRequest<ProductPurchase>
    {
        public ProductPurchase ProductPurchase { get; set; }
    }
}