using HotChocolate.Types;
using MyShop.Application.Application.BackgroundServices.MessageBusHanders;

namespace MyShop.API.Service.GraphQl.Models.InputModelTypes
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