using System;

namespace MyShopPersistance.Common
{
    internal interface IEntity
    {
        public Guid Id { get; set; }
    }
}