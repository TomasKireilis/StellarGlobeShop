﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using MyShopPersistance.Common;
using MyShopPersistance.Shops;

namespace MyShopPersistance.Product
{
    public class Product : IEntity
    {
        public string ProductTypeName { get; set; }
        public ProductType.ProductType ProductType { get; set; }
        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal SellingPrice { get; set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
        public Guid Id { get; set; }
    }
}