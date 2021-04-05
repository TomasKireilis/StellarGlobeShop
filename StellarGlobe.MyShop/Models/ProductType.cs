using System;
using System.ComponentModel.DataAnnotations;

namespace StellarGlobe.MyShop.Models
{
    public class ProductType
    {
        public string Name { get; set; }
        [Key] public Guid Id { get; set; }
    }
}