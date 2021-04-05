using System.Collections.Generic;

namespace BotCustomer
{
    public interface IRequiredProductsStrategy
    {
        List<CustomerRequiredProduct> AddStartingProducts(ShopsData shopsData);

        CustomerRequiredProduct ReplaceProduct(CustomerRequiredProduct oldProduct, ShopsData shopsData);
    }
}