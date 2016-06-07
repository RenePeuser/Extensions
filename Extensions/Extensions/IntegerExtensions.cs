using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsOutOfRange(this int value, int min, int max)
        {
            var result = IsInRange(value, min, max);
            return !result;
        }

        public static int ToInt(this int? source)
        {
            return source ?? default(int);
        }

        public static int CalcPercent(this int source, int divisor)
        {
            if (divisor.Equals(0))
            {
                return 0;
            }

            var percent = (divisor / (double)source) * 100;
            return (int)percent;
        }

        public static bool IsInRange(this int source, int start, int end)
        {
            return source >= start && source <= end;
        }

        public static string ToLeadingZero(this int source, int totalWidth)
        {
            return source.ToString().PadLeft(totalWidth, '0');
        }

        public static int Negate(this int source)
        {
            return source * -1;
        }

        public static int Subtract(this IEnumerable<int> source)
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

        public static int Multiply(this int value1, int value2)
        {
            return value1 * value2;
        }

        public static int Subtract(this int value1, int value2)
        {
            return value1 - value2;
        }

        public static int Addition(this int value1, int value2)
        {
            return value1 + value2;
        }

        public static double Divide(this int source, double divisor)
        {
            return divisor.Equals(0) ? 0 : source.Cast<double>().Divide(divisor);
        }
    }
}