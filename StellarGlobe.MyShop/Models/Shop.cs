using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class Shop
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}