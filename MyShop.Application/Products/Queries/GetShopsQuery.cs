﻿using System;
using System.Collections.Generic;
using System.Text;
using MyShop.Domain.Shops;

namespace MyShop.Application.Products.Queries
{
    public class GetShopsQuery : IGetShopsQuery
    {
        public List<ProductModel> Execute()
        {
            return new List<ProductModel>();
        }
    };
}
}