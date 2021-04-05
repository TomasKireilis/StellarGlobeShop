using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BotCustomer.Services.GraphQLClient;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BotCustomer
{
    public interface IRequiredProductsStrategy
    {
        List<CustomerRequiredProduct> AddStartingProducts();

        CustomerRequiredProduct ReplaceProduct(CustomerRequiredProduct oldProduct);
    }

    public class Consumer : BackgroundService
    {
        protected ShopsData ShopsData = new ShopsData();
        protected List<CustomerRequiredProduct> CustomerRequiredProducts = new List<CustomerRequiredProduct>();
        private readonly ILogger<Consumer> _logger;
        private readonly IProductPriceStrategy _priceStrategy;
        private readonly IRequiredProductsStrategy _requiredProductStrategy;
        private readonly IGraphQlClient _graphQlClient;

        public Consumer(ILogger<Consumer> logger, IProductPriceStrategy priceStrategy, IRequiredProductsStrategy requiredProductStrategy, IGraphQlClient graphQlClient)
        {
            _logger = logger;
            _priceStrategy = priceStrategy;
            _requiredProductStrategy = requiredProductStrategy;
            _graphQlClient = graphQlClient;
        }

        public virtual bool UpdateShopsData()
        {
            var response = _graphQlClient.GetShopsData();
            if (response == null)
            {
                _logger.LogWarning($"{GetType().Name}: Error updating Shops data. GraphQl client Response was null");
                return false;
            }
            return true;
        }

        public virtual decimal? GetProductPrice(string shopID, string productID)
        {
            var response = _graphQlClient.GetProductPrice(shopID, productID);

            if (!response.Item2)
            {
                _logger.LogWarning($"{GetType().Name}: error occurred while getting GraphQl client shop: {shopID} product: {productID} price");
                return null;
            }

            return response.Item1;
        }

        public virtual bool InitializeNeededProducts()
        {
            CustomerRequiredProducts = _requiredProductStrategy.AddStartingProducts();
            return true;
        }

        public virtual bool ReplaceRequiredProduct(CustomerRequiredProduct oldProduct)
        {
            if (CustomerRequiredProducts == null)
            {
                _logger.LogWarning($"{GetType().Name}: _customerRequiredProducts is null while trying to replace its product");
                return false;
            }

            if (CustomerRequiredProducts.Count == 0)
            {
                _logger.LogWarning($"{GetType().Name}: _customerRequiredProducts is empty while trying to replace its product");
                return false;
            }

            var index = CustomerRequiredProducts.FindIndex(x => x == oldProduct);

            if (index < 0)
            {
                _logger.LogWarning($"{GetType().Name}: _customerRequiredProducts cannot find index of product that is being replaced");
                return false;
            }

            CustomerRequiredProducts[index] = _requiredProductStrategy.ReplaceProduct(oldProduct);
            return true;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
            }
        }
    }
}