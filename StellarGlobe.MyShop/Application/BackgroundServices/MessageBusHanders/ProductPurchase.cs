using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotChocolate.AspNetCore.Subscriptions.Messages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace StellarGlobe.MyShop.BackgroundServices.MessageBusHanders
{
    public class ProductPurchase
    {
        public Guid UserId { get; set; }
        public Guid ShopId { get; set; }
        public string ProductType { get; set; }
    }
}