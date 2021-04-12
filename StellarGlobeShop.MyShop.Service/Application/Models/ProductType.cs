using System.ComponentModel.DataAnnotations;

namespace StellarGlobeShop.MyShop.Service.Application.Models
{
    public class ProductType
    {
        [Key] public string Name { get; set; }
    }
}