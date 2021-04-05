using System.Collections.Generic;

namespace BotCustomer.Services.GraphQLClient
{
    public interface IGraphQlClient
    {
        List<ShopsData> GetShopsData();

        (decimal?, bool) GetProductPrice(string shopID, string productID);
    }
}