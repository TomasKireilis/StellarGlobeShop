using HotChocolate.Types;

namespace MyShop.API.Service.Products.Mutations.Types
{
    public class ProductPurchaseMutationType : ObjectType<ProductPurchaseMutation>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductPurchaseMutation> descriptor)
        {
            descriptor

                .Field(f => f.PurchaseProduct(default!, default!, default!))
                .Type<ProductPurchaseInputType>();
        }
    }
}