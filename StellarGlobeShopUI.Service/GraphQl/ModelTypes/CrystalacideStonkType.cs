using GraphQL.Types;
using StellarGlobeShopUI.Service.Models;

namespace StellarGlobeShopUI.Service.GraphQl.ModelTypes
{
    public sealed class CrystalacideStonkType : ObjectGraphType<CrystalacideStonk>
    {
        public CrystalacideStonkType()
        {
            Field(x => x.StonkId).Description("Stonk identification token");
            Field(x => x.CompanyName).Description("Company name");
            Field(x => x.StonkAmount).Description("Stonk amount");
        }
    }
}