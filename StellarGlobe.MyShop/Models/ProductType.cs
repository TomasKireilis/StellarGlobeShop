using System;
using System.ComponentModel.DataAnnotations;

namespace StellarGlobe.MyShop.Models
{
    public class ProductType
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
    }
}