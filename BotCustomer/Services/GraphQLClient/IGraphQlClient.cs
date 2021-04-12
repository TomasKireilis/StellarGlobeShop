using System.Threading.Tasks;

namespace BotCustomer.Services.GraphQLClient
{
    public interface IGraphQlClient
    {
        Task<ShopsData> GetShopsData();

        Task<(decimal?, bool)> GetProductPrice(string shopID, string productID);
    }
}