using System;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}