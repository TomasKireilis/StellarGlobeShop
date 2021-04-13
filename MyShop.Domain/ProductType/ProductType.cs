using System.ComponentModel.DataAnnotations;

namespace MyShop.Application.Application.Models
{
    public class ProductType
    {
        [Key] public string Name { get; set; }
    }
}