using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BotCustomer.Services.GraphQLClient
{
    public class GraphqlClient : IGraphQlClient
    {
        private readonly ILogger<GraphqlClient> _logger;
        private readonly string _clientUrl;

        public GraphqlClient(ILogger<GraphqlClient> logger, IConfiguration configuration)
        {
            _logger = logger;
            _clientUrl = configuration["StellarGlobeShopUI.Service:ApplicationUrl"];
        }

        public async Task<ShopsData> GetShopsData()
        {
            var shopsDataQuery = @"{  shops { id }  productTypes { name }}";

            _logger.LogInformation("Fetching shops data...");

            try
            {
                var qraphQLShopsData = await RetryUtils.RetryIfThrown<Exception, GraphQLResponse<GraphQLShopsData>>(async () =>
                    await SendQueryAsync<GraphQLShopsData>(_clientUrl, shopsDataQuery), 10, 250, 1000);

                var shopsData = new ShopsData()
                {
                    ProductsIDs = qraphQLShopsData.Data.ProductTypes.Select(x => x.Name).ToList(),
                    ShopsIDs = qraphQLShopsData.Data.Shops.Select(x => x.Id).ToList()
                };
                if (qraphQLShopsData.Errors != null)
                {
                    _logger.LogWarning($"Fetched shops data with warnings: {qraphQLShopsData.Errors}");

                    return shopsData;
                }

                _logger.LogInformation("Fetched shops data successfully");
                return shopsData;
            }
            catch (Exception e)
            {
                _logger.LogError(ExceptionEvents.GenerateEventId(LoggerEventType.GraphQLClient), e, "Error while getting shop data");
                return null;
            }
        }

        public async Task<(decimal?, bool)> GetProductPrice(string shopID, string productID)
        {
            var productPriceQuery = @"{  shops { id }  productTypes { name }}";
            try
            {
                var qraphQLShopsData = await RetryUtils.RetryIfThrown<Exception, GraphQLResponse<GraphQLShopsData>>(async () =>
                    await SendQueryAsync<GraphQLShopsData>(_clientUrl, productPriceQuery), 10, 250, 1000);
                return (null, false);
            }
            catch (Exception e)
            {
                var eventID = new EventId(0, $"Get Product Price: {shopID} , {productID}");
                _logger.LogError(eventID, e, "Error while getting product price");
                return (null, false);
            }
        }

        public async Task<GraphQLResponse<T>> SendQueryAsync<T>(string clientUrl, string query)
        {
            var client = new GraphQLHttpClient(clientUrl, new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query = query
            };

            var responseData = await client.SendQueryAsync<T>(request);
            return responseData;
        }
    }
}