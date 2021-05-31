using System;

namespace MyShop.Domain.Common
{
    internal interface IEntity
    {
        public Guid Id { get; }
    }
}