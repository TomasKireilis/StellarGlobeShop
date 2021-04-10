using System;
using System.ComponentModel.DataAnnotations;

namespace StellarGlobe.MyShop.Application.Models
{
    public class ProductType
    {
        [Key] public string Name { get; set; }
    }
}