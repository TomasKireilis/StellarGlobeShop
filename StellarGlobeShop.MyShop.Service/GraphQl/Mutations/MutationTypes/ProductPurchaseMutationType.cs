using HotChocolate.Types;
using StellarGlobeShop.MyShop.Service.GraphQl.GraphQLModels.InputModelTypes;

namespace StellarGlobeShop.MyShop.Service.GraphQl.Mutations.MutationTypes
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