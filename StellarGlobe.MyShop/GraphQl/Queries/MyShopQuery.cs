using System;
using System.Collections.Generic;
using HotChocolate;
using System.Linq;
using AutoMapper;
using HotChocolate.Data;
using StellarGlobe.MyShop.Database;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class MyShopQuery
    {
        [UseDbContext(typeof(MyShopContext))]
        public ShopDTO GetShop(Guid id, [ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
        {
            var shop = myShopContext.Shops.FirstOrDefault(x => x.Id == id);
            var shopDTO = mapper.Map<ShopDTO>(shop);
            return shopDTO;
        }

        [UseDbContext(typeof(MyShopContext))]
        public List<ShopDTO> GetShops([ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
        {
            var shops = myShopContext.Shops.ToList();
            var shopsDTO = mapper.Map<List<ShopDTO>>(shops);
            return shopsDTO;
        }

        [UseDbContext(typeof(MyShopContext))]
        public List<ProductTypeDTO> GetProductTypes([ScopedService] MyShopContext myShopContext, [Service] IMapper mapper)
        {
            var productTypes = myShopContext.ProductTypes.ToList();
            var productTypesDTO = mapper.Map<List<ProductTypeDTO>>(productTypes);
            return productTypesDTO;
        }
    }
}