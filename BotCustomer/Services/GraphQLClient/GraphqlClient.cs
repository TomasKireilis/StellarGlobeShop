using System;
using System.Collections.Generic;
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
            _logger.LogInformation("Getting shops data...");
            var shopsDataQuery = @"d";
            try
            {
                var response = await RetryUtils.RetryIfThrown<Exception, GraphQLResponse<ShopsData>>(async () =>
               {
                   var client = new GraphQLHttpClient(_clientUrl, new NewtonsoftJsonSerializer());

                   var request = new GraphQLRequest
                   {
                       Query = shopsDataQuery
                   };

                   var queryResponse = await client.SendQueryAsync<ShopsData>(request);
                   return queryResponse;
               }, 10, 250, 1000);
                return response?.Data;
            }
            catch (Exception e)
            {
                _logger.LogError(ExceptionEvents.GenerateEventId(LoggerEventType.GraphQLClient), e, "Error while getting shop data");
                return null;
            }
        }

        public async Task<(decimal?, bool)> GetProductPrice(string shopID, string productID)
        {
            try
            {
                var response = await RetryUtils.RetryIfThrown<Exception, (decimal?, bool)>(() =>
                 {
                     throw new NotImplementedException();
                 }, 5, 250, 500);
                return response;
            }
            catch (Exception e)
            {
                var eventID = new EventId(0, $"Get Product Price: {shopID} , {productID}");
                _logger.LogError(eventID, e, "Error while getting product price");
                return (null, false);
            }
        }
    }
}