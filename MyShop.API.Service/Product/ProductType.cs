using HotChocolate.Types;
using MyShop.Application.ProductTypes.Queries;

namespace MyShop.API.Service.Product
{
    public class ProductType : ObjectType<ProductModel>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductModel> descriptor)
        {
            descriptor
                .Field(f => f.Id);
            descriptor
                .Field(f => f.Image);
            descriptor
                .Field(f => f.Name);
        }

        public class Resolvers
        {
        }
    }
}