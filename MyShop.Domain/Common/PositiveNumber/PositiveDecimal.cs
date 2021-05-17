using System;

namespace MyShop.Domain.Common.PositiveNumber
{
    internal class PositiveDecimal
    {
        public PositiveDecimal(decimal value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
            Value = value;
        }

        public decimal Value { get; }

        public static implicit operator decimal(PositiveDecimal classToConvert)
        {
            return classToConvert.Value;
        }

        public static implicit operator PositiveDecimal(decimal value)
        {
            return new PositiveDecimal(value);
        }
    }
}