using HotChocolate;
using Microsoft.Extensions.Configuration;
using StellarGlobe.MyShop.GraphQl.ModelTypes;
using StellarGlobe.MyShop.Services.MessageBus.RabbitMQ;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class MyShopQuery
    {
        public Product GetMyShopData([Service] IMessageBus messageBus, [Service] IConfiguration configuration)
        {
            return new Product();
        }
    }
}