using System.Collections.Generic;

namespace MyShop.Application.Products.Queries
{
    public interface IGetShopsQuery
    {
        List<ProductModel> Execute();
    }
}