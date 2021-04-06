using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BotCustomer.Services.GraphQLClient;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BotCustomer
{
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

        public virtual async Task<bool> UpdateShopsData()
        {
            var response = await _graphQlClient.GetShopsData();
            if (response == null)
            {
                _logger.LogWarning($"{GetType().Name}: Error updating Shops data. GraphQl client Response was null");
                return false;
            }

            ShopsData = response;
            return true;
        }

        public virtual async Task<decimal?> GetProductPrice(string shopID, string productID)
        {
            var response = await _graphQlClient.GetProductPrice(shopID, productID);

            if (!response.Item2)
            {
                _logger.LogWarning($"{GetType().Name}: error occurred while getting GraphQl client shop: {shopID} product: {productID} price");
                return null;
            }

            return response.Item1;
        }

        public virtual bool InitializeNeededProducts()
        {
            CustomerRequiredProducts = _requiredProductStrategy.AddStartingProducts(ShopsData);
            return true;
        }

        public virtual CustomerRequiredProduct GetReplacementForRequiredProduct(CustomerRequiredProduct oldProduct)
        {
            if (CustomerRequiredProducts == null)
            {
                _logger.LogWarning($"{GetType().Name}: _customerRequiredProducts is null while trying to replace its product");
                return null;
            }

            if (CustomerRequiredProducts.Count == 0)
            {
                _logger.LogWarning($"{GetType().Name}: _customerRequiredProducts is empty while trying to replace its product");
                return null;
            }

            if (CustomerRequiredProducts.All(x => x != oldProduct))
            {
                _logger.LogWarning($"{GetType().Name}: _customerRequiredProducts cannot find product that is being replaced");
                return null;
            }

            return _requiredProductStrategy.ReplaceProduct(oldProduct, ShopsData);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await UpdateShopsData();
            InitializeNeededProducts();

            while (!stoppingToken.IsCancellationRequested)
            {
                await PurchaseRequiredProduct(stoppingToken);
            }
        }

        protected async Task PurchaseRequiredProduct(CancellationToken stoppingToken)
        {
            if (CustomerRequiredProducts == null)
            {
                throw new ArgumentNullException($"{GetType().Name}: CustomerRequiredProducts is null");
            }

            if (CustomerRequiredProducts.Count == 0)
            {
                throw new ArgumentException($"{GetType().Name}: CustomerRequiredProducts is empty");
            }

            if (CustomerRequiredProducts[0].ShopsLeftToVisit.Count == 0)
            {
                var newProduct = GetReplacementForRequiredProduct(CustomerRequiredProducts[0]);
                CustomerRequiredProducts.Add(newProduct);
                CustomerRequiredProducts.RemoveAt(0);
            }

            var requiredProduct = CustomerRequiredProducts[0];

            if (requiredProduct.ShopsLeftToVisit.Count > 0)
            {
                var productPrice = await GetProductPrice(requiredProduct.ShopsLeftToVisit.First(), requiredProduct.ProductID);

                if (productPrice == null)
                {
                    _logger.LogInformation($"Purchasing product {requiredProduct.ProductID}");
                    requiredProduct.ShopsLeftToVisit.RemoveAt(0);
                    requiredProduct.ShopsVisited++;
                    return;
                }

                if (productPrice.Value > _priceStrategy.GetCurrentPrice(requiredProduct))
                {
                    requiredProduct.ShopsLeftToVisit.RemoveAt(0);
                    requiredProduct.ShopsVisited++;
                    return;
                }

                //TODO
                _logger.LogInformation("Purchasing product...");
                var newProduct = GetReplacementForRequiredProduct(CustomerRequiredProducts[0]);
                CustomerRequiredProducts.Add(newProduct);
                CustomerRequiredProducts.RemoveAt(0);
            }
        }
    }
}