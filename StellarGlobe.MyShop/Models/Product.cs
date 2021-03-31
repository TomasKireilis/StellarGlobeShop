using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate.Utilities;

namespace StellarGlobe.MyShop.GraphQl.ModelTypes
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}