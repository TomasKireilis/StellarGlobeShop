using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Common
{
    internal interface IEntity
    {
        public Guid Id { get; }
    }
}