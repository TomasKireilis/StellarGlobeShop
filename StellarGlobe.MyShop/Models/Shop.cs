﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StellarGlobe.MyShop.Models
{
    public class Shop
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}