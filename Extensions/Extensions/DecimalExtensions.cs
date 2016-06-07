using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class DecimalExtensions
    {
        public static decimal CalcPercent(this decimal source, decimal divisor)
        {
            if (divisor.Equals(0))
            {
                return 0;
            }

            var percent = divisor / source * 100;
            return Math.Round(percent, 0);
        }

        public static bool IsInRange(this decimal source, decimal start, decimal end)
        {
            return source >= start && source <= end;
        }

        public static decimal Truncate(this decimal value)
        {
            return Math.Truncate(value);
        }

        public static decimal Subtract(this IEnumerable<decimal> source)
        {
            var sourceList = source.ToList();
            if (sourceList.IsNullOrEmpty())
            {
                return 0;
            }

            var difference = sourceList.First();
            var count = sourceList.Count;

            for (var i = 1; i < count; i++)
            {
                difference -= sourceList[i];
            }

            return difference;
        }

        public static decimal Multiply(this decimal value1, decimal value2)
        {
            return value1 * value2;
        }

        public static decimal Multiply(this decimal value1, int value2)
        {
            return value1 * value2;
        }

        public static decimal Subtract(this decimal value1, int value2)
        {
            return value1 - value2;
        }

        public static decimal Subtract(this decimal value1, decimal value2)
        {
            return value1 - value2;
        }

        public static decimal Addition(this decimal value1, decimal value2)
        {
            return value1 + value2;
        }

        public static decimal Divide(this decimal value, decimal divisor)
        {
            return divisor.Equals(0) ? 0 : value / divisor;
        }

        public static double ToDouble(this decimal value)
        {
            return value.Cast<double>();
        }

        public static bool IsMinValue(this decimal value)
        {
            return value == decimal.MinValue;
        }

        public static int ToInt(this decimal value)
        {
            return value.Cast<int>();
        }
    }
}