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

        public static decimal ToDecimal(this double value)
        {
            return (decimal)value;
        }
    }
}