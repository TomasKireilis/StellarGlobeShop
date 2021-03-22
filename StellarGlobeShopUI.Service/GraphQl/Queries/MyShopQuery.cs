using System;
using System.Collections.Generic;
using ClassMapper.JsonMapper;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using StellarGlobeShopUI.Service.GraphQl.ModelTypes;
using StellarGlobeShopUI.Service.Models;
using StellarGlobeShopUI.Service.Services.MessageBus.Models;
using StellarGlobeShopUI.Service.Services.MessageBus.RabbitMQ;

namespace StellarGlobeShopUI.Service.GraphQl.Queries
{
    public class MyShopQuery : ObjectGraphType
    {
        public MyShopQuery(IMessageBus messageBus, IConfiguration configuration)
        {
            Field<ListGraphType<CrystalacideStonkType>>(
                "activeStonks",
                "Returns a list of stonks that are being open to sell and can be purchased",
                resolve: context =>
                {
                    return new List<CrystalacideStonk>();
                });
        }
    }
}