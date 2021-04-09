using HotChocolate.Types;
using StellarGlobe.MyShop.GraphQl.Mutations;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes.QueryTypes
{
    public class ProductPurchaseMutationType : ObjectType<ProductPurchaseMutation>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductPurchaseMutation> descriptor)
        {
            descriptor

                .Field(f => f.PurchaseProduct(default, default, default, default))
                .Type<BooleanType>();
        }
    }
}