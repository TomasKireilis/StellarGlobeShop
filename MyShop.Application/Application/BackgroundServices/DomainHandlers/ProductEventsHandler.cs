using System;
using MyShop.Application.Application.BackgroundServices.DomainHandlers.Interfaces;
using MyShop.Application.Application.BackgroundServices.MessageBusHanders;

namespace MyShop.Application.Application.BackgroundServices.DomainHandlers
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