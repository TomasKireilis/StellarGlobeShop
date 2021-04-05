using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace BotCustomer
{
    public class RequiredProductsStrategy : IRequiredProductsStrategy
    {
        protected readonly Random Random;
        protected (decimal, decimal) StartingProductPriceRange = ((decimal)0.01, 1);
        protected double ChanceThatReplacingProductItStaysTheSame = 0.9f;
        private readonly ILogger<RequiredProductsStrategy> _logger;
        private readonly int _productAmount;
        private readonly int _decimalSpaces = 2;

        public RequiredProductsStrategy(ILogger<RequiredProductsStrategy> logger, Random random, int productAmount = 10)
        {
            _logger = logger;
            Random = random;
            _productAmount = productAmount;
        }

        public List<CustomerRequiredProduct> AddStartingProducts(ShopsData shopsData)
        {
            if (shopsData?.ShopsIDs == null || shopsData.ProductsIDs == null)
            {
                _logger.LogWarning($"ReplaceProduct: shopsData is null");
                return new List<CustomerRequiredProduct>();
            }
            var requiredProducts = new List<CustomerRequiredProduct>();

            for (int i = 0; i < _productAmount; i++)
            {
                var productIndex = Random.Next(0, shopsData.ProductsIDs.Count);

                requiredProducts.Add(

                    new CustomerRequiredProduct(CalculateStartingPrice(Random))
                    {
                        ProductID = shopsData.ProductsIDs[productIndex],
                        ShopsLeftToVisit = shopsData.ShopsIDs,
                    }

                    );
            }

            return requiredProducts;
        }

        public CustomerRequiredProduct ReplaceProduct(CustomerRequiredProduct oldProduct, ShopsData shopsData)
        {
            if (shopsData == null)
            {
                _logger.LogWarning($"ReplaceProduct: shopsData is null");
                return null;
            }
            var random = Random.NextDouble();

            var productReplacement = new CustomerRequiredProduct(CalculateStartingPrice(Random))
            {
                ShopsLeftToVisit = shopsData.ShopsIDs,
            };

            if (random <= ChanceThatReplacingProductItStaysTheSame)
            {
                productReplacement.ProductID = oldProduct.ProductID;
                return productReplacement;
            }

            var productIndex = Random.Next(0, shopsData.ProductsIDs.Count);

            productReplacement.ProductID = shopsData.ProductsIDs[productIndex];

            return productReplacement;
        }

        public decimal CalculateStartingPrice(Random random)
        {
            return Math.Round(

                GenerateValueInRange(
                    random,
                    StartingProductPriceRange.Item1,
                    StartingProductPriceRange.Item2)

                , _decimalSpaces);
        }

        public decimal GenerateValueInRange(Random random, decimal min, decimal max)
        {
            if (min >= max) _logger.LogWarning($"GenerateDecimalInRange: min: {min} value is bigger/equal that max: {max}");
            return ((decimal)random.NextDouble()) * (max - min) - min;
        }
    }
}