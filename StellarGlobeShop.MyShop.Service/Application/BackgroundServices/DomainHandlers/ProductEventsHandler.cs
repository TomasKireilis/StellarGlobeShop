using System;
using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobeShop.MyShop.Service.Application.BackgroundServices.DomainHandlers
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