using System;

namespace MyShop.Domain.Common.PositiveNumber
{
    public class PositiveInteger
    {
        public PositiveInteger(int value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
            Value = value;
        }

        public int Value { get; }

        public static implicit operator int(PositiveInteger classToConvert)
        {
            return classToConvert.Value;
        }

        public static implicit operator PositiveInteger(int value)
        {
            return new PositiveInteger(value);
        }
    }
}