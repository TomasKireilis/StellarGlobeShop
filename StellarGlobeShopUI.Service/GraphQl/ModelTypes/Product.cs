using System;
using GraphQL.Types;
using StellarGlobeShopUI.Service.Models;

namespace StellarGlobeShopUI.Service.GraphQl.ModelTypes
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}