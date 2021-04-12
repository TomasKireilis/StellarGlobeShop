using HotChocolate.Types;
using StellarGlobeShop.MyShop.Service.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobeShop.MyShop.Service.GraphQl.GraphQLModels.InputModelTypes
{
    public class ProductPurchaseInputType : ObjectType<ProductPurchase>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductPurchase> descriptor)
        {
            descriptor
                .Field(f => f.ShopId).Type<UuidType>();

            descriptor
                .Field(f => f.UserId).Type<UuidType>();

            descriptor
                .Field(f => f.ProductType).Type<StringType>();
        }
    }
}