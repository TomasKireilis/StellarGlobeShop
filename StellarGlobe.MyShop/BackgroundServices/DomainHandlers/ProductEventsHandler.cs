using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StellarGlobe.MyShop.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobe.MyShop.BackgroundServices.MessageBusHanders;
using StellarGlobe.MyShop.Database;

namespace StellarGlobe.MyShop.BackgroundServices.DomainHandlers
{
    public class ProductEventsHandler : IProductPurchaseHandler
    {
        private readonly MyShopContext _myShopContext;

        public ProductEventsHandler(MyShopContext myShopContext)
        {
            _myShopContext = myShopContext;
        }

        public void HandleProductPurchase(ProductPurchase productPurchase)
        {
            Console.WriteLine($"Purchasing product {productPurchase.ProductType}");
        }
    }
}