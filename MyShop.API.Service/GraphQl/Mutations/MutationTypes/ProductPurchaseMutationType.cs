using HotChocolate.Types;
using MyShop.API.Service.GraphQl.GraphQLModels.InputModelTypes;

namespace MyShop.API.Service.GraphQl.Mutations.MutationTypes
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