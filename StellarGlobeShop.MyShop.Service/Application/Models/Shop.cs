using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StellarGlobeShop.MyShop.Service.Application.Models
{
    public class Shop
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}