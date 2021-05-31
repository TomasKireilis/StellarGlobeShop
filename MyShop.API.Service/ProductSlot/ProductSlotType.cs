using HotChocolate.Types;
using MyShop.Application.ProductSlots.Queries;

namespace MyShop.API.Service.ProductSlot
{
    public class ProductSlotType : ObjectType<ProductSlotModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductSlotModel> descriptor)
        {
            descriptor
                .Field(f => f.Id);
            descriptor
                .Field(f => f.Quantity);
            descriptor
                .Field(f => f.ProductType);
        }

        public class Resolvers
        {
            //public ShopModel GetShop(ProductModel product, [ScopedService] MyShopContext myShopContext)
            //{
            //    return myShopContext.Shops.FirstOrDefault(x => x.Id == product.ShopId);
            //}

            //public ProductTypeModel GetProductType(
            //    ProductModel product,
            //    [ScopedService] MyShopContext myShopContext)
            //{
            //    return myShopContext.ProductTypes.FirstOrDefault(x => x.Name == product.ProductTypeName);
            //}
        }
    }
}