using HotChocolate.Types;
using StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders;

namespace StellarGlobe.MyShop.GraphQl.GraphQLModels.InputModels.Types
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