using System;
using System.Collections.Generic;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes.Models
{
    public class ShopDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}