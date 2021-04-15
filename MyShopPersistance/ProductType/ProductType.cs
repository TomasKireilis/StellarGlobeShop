using System.ComponentModel.DataAnnotations;

namespace MyShopPersistance.ProductType
{
    public class ProductType
    {
        [Key] public string Name { get; set; }
    }
}