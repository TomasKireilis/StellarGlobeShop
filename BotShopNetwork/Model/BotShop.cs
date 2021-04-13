using Newtonsoft.Json;

namespace BotShopNetwork.Model
{
    public class BotShop
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("ShopName")]
        public string ShopName { get; set; }
    }
}