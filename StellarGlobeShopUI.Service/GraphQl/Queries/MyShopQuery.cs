using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using HotChocolate;
using Microsoft.Extensions.Configuration;
using StellarGlobeShopUI.Service.GraphQl.ModelTypes;
using StellarGlobeShopUI.Service.Models;
using StellarGlobeShopUI.Service.Services.MessageBus.RabbitMQ;

namespace StellarGlobeShopUI.Service.GraphQl.Queries
{
    public class MyShopQuery
    {
        public Product GetMyShopData([Service] IMessageBus messageBus, [Service] IConfiguration configuration)
        {
            return new Product();
        }
    }
}