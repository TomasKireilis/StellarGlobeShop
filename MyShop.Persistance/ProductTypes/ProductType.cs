using System.ComponentModel.DataAnnotations;

namespace MyShop.Persistance.ProductTypes
{
    public class ProductType
    {
        [Key] public string Name { get; set; }
    }
}