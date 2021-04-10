using System;
using System.Collections.Generic;
using HotChocolate;
using System.Linq;
using AutoMapper;
using HotChocolate.Data;
using StellarGlobe.MyShop.GraphQl.ModelTypes.Models;
using StellarGlobe.MyShop.Infrastructure.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class MyShopQuery
    {
        [UseDbContext(typeof(MyShopContext))]
        public ShopDto GetShop(Guid id, [ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
        {
            var shop = myShopContext.Shops.FirstOrDefault(x => x.Id == id);
            var shopDto = mapper.Map<ShopDto>(shop);
            return shopDto;
        }

        [UseDbContext(typeof(MyShopContext))]
        public List<ShopDto> GetShops([ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
        {
            var shops = myShopContext.Shops.ToList();
            var shopsDto = mapper.Map<List<ShopDto>>(shops);
            return shopsDto;
        }

        [UseDbContext(typeof(MyShopContext))]
        public List<ProductTypeDto> GetProductTypes([ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
        {
            var productTypes = myShopContext.ProductTypes.ToList();
            var productTypesDto = mapper.Map<List<ProductTypeDto>>(productTypes);
            return productTypesDto;
        }
    }
}