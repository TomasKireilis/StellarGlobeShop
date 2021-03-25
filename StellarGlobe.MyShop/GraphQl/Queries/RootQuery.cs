using HotChocolate;

namespace StellarGlobe.MyShop.GraphQl.Queries
{
    public class RootQuery
    {
        public MyShopQuery MyShopProduct([Service] MyShopQuery myShopQuery)
        {
            return myShopQuery;
        }
    }
}