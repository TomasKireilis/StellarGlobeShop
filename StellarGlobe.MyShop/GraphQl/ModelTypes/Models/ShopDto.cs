using System;
using System.Collections.Generic;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes.Models
{
    public class ShopDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}