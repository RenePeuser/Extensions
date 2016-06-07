using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Extensions
{
    public static class DoubleExtensions
    {
        public static int CalcPercent(this double source, double divisor)
        {
            if (divisor.Equals(0))
            {
                return 0;
            }

            var percent = divisor / source * 100;
            return (int)Math.Round(percent, 0);
        }

        public static bool IsInRange(this double source, double start, double end)
        {
            return source >= start && source <= end;
        }

        public static double Truncate(this double value)
        {
            return Math.Truncate(value);
        }

        public static double Subtract(this IEnumerable<double> source)
        {
            Contract.Requires(source.IsNotNull());

            var sourceList = source.ToList();
            var difference = sourceList.First();
            var count = sourceList.Count;

            for (int i = 1; i < count; i++)
            {
                difference -= sourceList[i];
            }

            return difference;
        }

        public static double Multiply(this double value1, double value2)
        {
            return value1 * value2;
        }

        public static double Multiply(this double value1, int value2)
        {
            return value1 * value2;
        }

        public static double Subtract(this double value1, int value2)
        {
            return value1 - value2;
        }

        public static double Subtract(this double value1, double value2)
        {
            return value1 - value2;
        }

        public static double Addition(this double value1, double value2)
        {
            return value1 + value2;
        }

        public static double Divide(this double value, double divisor)
        {
            if (divisor.Equals(0))
            {
                return 0;
            }

            return value / divisor;
        }

        public static decimal ToDecimal(this double value)
        {
            return (decimal)value;
        }
    }
}