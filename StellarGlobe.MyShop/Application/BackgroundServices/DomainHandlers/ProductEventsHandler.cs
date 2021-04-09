using System;
using StellarGlobe.MyShop.Application.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobe.MyShop.Application.BackgroundServices.DomainHandlers
{
    public class ProductEventsHandler : IProductPurchaseHandler
    {
        //private readonly MyShopContext _myShopContext;

        //public ProductEventsHandler(MyShopContext myShopContext)
        //{
        //    _myShopContext = myShopContext;
        //}

        public void HandleProductPurchase(ProductPurchase productPurchase)
        {
            Console.WriteLine($"Purchasing product {productPurchase.ProductType}");
        }
    }
}