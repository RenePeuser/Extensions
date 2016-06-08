using System;
using System.Diagnostics.Contracts;

namespace Extensions
{
    public static class DoubleExtensions
    {
        public static double CalcPercent(this double source, double divisor, int decimals = 0)
        {
            Contract.Requires(divisor.NotRefEquals(0));

            var percent = divisor / source * 100;
            return Math.Round(percent, decimals);
        }

        public static bool IsMinValue(this double value)
        {
            return value.Equals(double.MinValue);
        }

        public static bool IsMaxValue(this double value)
        {
            return value.Equals(double.MaxValue);
        }

        public static int ToInt(this double value)
        {
            return value.Cast<int>();
        }

        public static decimal ToDecimal(this double value)
        {
            return value.Cast<decimal>();
        }
    }
}