using System.Collections.Generic;
using Newtonsoft.Json;

namespace BotCustomer.Services.GraphQLClient
{
    public class GraphQLShopsData
    {
        [JsonProperty("shops")]
        public List<Shop> Shops { get; set; }

        [JsonProperty("productTypes")]
        public List<ProductType> ProductTypes { get; set; }

        public class ProductType
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class Shop
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }
    }
}