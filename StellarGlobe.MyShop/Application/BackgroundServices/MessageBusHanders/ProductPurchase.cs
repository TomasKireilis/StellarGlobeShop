﻿using System;

namespace StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders
{
    public class ProductPurchase
    {
        public Guid UserId { get; set; }
        public Guid ShopId { get; set; }
        public string ProductType { get; set; }
    }
}