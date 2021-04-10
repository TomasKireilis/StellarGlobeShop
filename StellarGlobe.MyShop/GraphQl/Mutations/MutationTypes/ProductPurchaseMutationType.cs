using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.GraphQLModels.InputModels;
using StellarGlobe.MyShop.GraphQl.GraphQLModels.InputModels.Types;

namespace StellarGlobe.MyShop.GraphQl.Mutations.MutationTypes
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