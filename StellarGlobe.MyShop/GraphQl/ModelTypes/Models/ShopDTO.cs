using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StellarGlobe.MyShop.Models
{
    public class ShopDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}