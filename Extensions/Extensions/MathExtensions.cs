using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows;

namespace Extensions
{

    public static class MathExtensions
    {


        public static decimal Ceiling(this decimal d)
        {
            return Math.Ceiling(d);
        }

        public static decimal Floor(this decimal d)
        {
            return Math.Floor(d);
        }

        public static decimal Truncate(this decimal d)
        {
            return Math.Truncate(d);
        }

        public static double Truncate(this double d)
        {
            return Math.Truncate(d);
        }

        public static double IEEERemainder(this double x, double y)
        {
            return Math.IEEERemainder(x, y);
        }

        public static double Log(this double a, double newBase)
        {
            return Math.Log(a, newBase);
        }

        public static long BigMul(this int a, int b)
        {
            return Math.BigMul(a, b);
        }

        public static int DivRem(this int a, int b, out int result)
        {
            return Math.DivRem(a, b, out result);

        }

        public static long DivRem(this long a, long b, out long result)
        {
            return Math.DivRem(a, b, out result);
        }



        public static double Round(this double value, int digits)
        {
            return Math.Round(value, digits);
        }

        public static double Round(this double value, MidpointRounding mode)
        {
            return Math.Round(value, 0, mode);
        }

        public static double Round(this double value, int digits, MidpointRounding mode)
        {
            return Math.Round(value, digits, mode);
        }

        public static decimal Round(this decimal d)
        {
            return Math.Round(d, 0);
        }

        public static decimal Round(this decimal d, int decimals)
        {
            return Math.Round(d, decimals);
        }

        public static decimal Round(this decimal d, MidpointRounding mode)
        {
            return Math.Round(d, 0, mode);
        }

        public static decimal Round(this decimal d, int decimals, MidpointRounding mode)
        {
            return Math.Round(d, decimals, mode);
        }



        public static sbyte Abs(this sbyte value)
        {
            return Math.Abs(value);
        }

        public static short Abs(this short value)
        {
            return Math.Abs(value);
        }

        public static int Abs(this int value)
        {
            return Math.Abs(value);
        }

        public static long Abs(this long value)
        {
            return Math.Abs(value);
        }

        public static decimal Abs(this decimal value)
        {
            return Math.Abs(value);
        }



        public static sbyte Min(this sbyte val1, sbyte val2)
        {
            return Math.Min(val1, val2);
        }

        public static byte Min(this byte val1, byte val2)
        {
            return Math.Min(val1, val2);
        }

        public static short Min(this short val1, short val2)
        {
            return Math.Min(val1, val2);
        }

        public static ushort Min(this ushort val1, ushort val2)
        {
            return Math.Min(val1, val2);
        }

        public static int Min(this int val1, int val2)
        {
            return Math.Min(val1, val2);
        }

        public static uint Min(this uint val1, uint val2)
        {
            return Math.Min(val1, val2);
        }

        public static long Min(this long val1, long val2)
        {
            return Math.Min(val1, val2);
        }

        public static ulong Min(this ulong val1, ulong val2)
        {
            return Math.Min(val1, val2);
        }

        public static float Min(this float val1, float val2)
        {
            return Math.Min(val1, val2);
        }

        public static double Min(this double val1, double val2)
        {
            return Math.Min(val1, val2);
        }

        public static decimal Min(this decimal val1, decimal val2)
        {
            return Math.Min(val1, val2);
        }



        public static sbyte Max(this sbyte val1, sbyte val2)
        {
            return Math.Max(val1, val2);
        }

        public static byte Max(this byte val1, byte val2)
        {
            return Math.Max(val1, val2);
        }

        public static short Max(this short val1, short val2)
        {
            return Math.Max(val1, val2);
        }

        public static ushort Max(this ushort val1, ushort val2)
        {
            return Math.Max(val1, val2);
        }

        public static int Max(this int val1, int val2)
        {
            return Math.Max(val1, val2);
        }

        public static uint Max(this uint val1, uint val2)
        {
            return Math.Max(val1, val2);
        }

        public static long Max(this long val1, long val2)
        {
            return Math.Max(val1, val2);
        }

        public static ulong Max(this ulong val1, ulong val2)
        {
            return Math.Max(val1, val2);
        }

        public static float Max(this float val1, float val2)
        {
            return Math.Max(val1, val2);
        }

        public static double Max(this double val1, double val2)
        {
            return Math.Max(val1, val2);
        }

        public static decimal Max(this decimal val1, decimal val2)
        {
            return Math.Max(val1, val2);
        }



        public static int Sign(this sbyte value)
        {
            return Math.Sign(value);
        }

        public static int Sign(this short value)
        {
            return Math.Sign(value);
        }

        public static int Sign(this int value)
        {
            return Math.Sign(value);
        }

        public static int Sign(this long value)
        {
            return Math.Sign(value);
        }

        public static int Sign(this float value)
        {
            return Math.Sign(value);
        }

        public static int Sign(this double value)
        {
            return Math.Sign(value);
        }

        public static int Sign(this decimal value)
        {
            return Math.Sign(value);
        }




        public static bool IsInRange(this sbyte source, sbyte start, sbyte end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this byte source, byte start, byte end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this short source, short start, short end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this ushort source, ushort start, ushort end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this int source, int start, int end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this uint source, uint start, uint end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this long source, long start, long end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this ulong source, ulong start, ulong end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this float source, float start, float end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this double source, double start, double end)
        {
            return source >= start & source <= end;
        }

        public static bool IsInRange(this decimal source, decimal start, decimal end)
        {
            return source >= start & source <= end;
        }






        public static bool IsOutOfRange(this sbyte source, sbyte start, sbyte end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this byte source, byte start, byte end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this short source, short start, short end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this ushort source, ushort start, ushort end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this int source, int start, int end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this uint source, uint start, uint end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this long source, long start, long end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this ulong source, ulong start, ulong end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this float source, float start, float end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this double source, double start, double end)
        {
            return source.IsInRange(start, end);
        }

        public static bool IsOutOfRange(this decimal source, decimal start, decimal end)
        {
            return source.IsInRange(start, end);
        }






        public static int Sum(this int val1, int val2)
        {
            return val1 + val2;
        }

        public static uint Sum(this uint val1, uint val2)
        {
            return val1 + val2;
        }

        public static long Sum(this long val1, long val2)
        {
            return val1 + val2;
        }

        public static ulong Sum(this ulong val1, ulong val2)
        {
            return val1 + val2;
        }

        public static float Sum(this float val1, float val2)
        {
            return val1 + val2;
        }

        public static double Sum(this double val1, double val2)
        {
            return val1 + val2;
        }

        public static decimal Sum(this decimal val1, decimal val2)
        {
            return val1 + val2;
        }

        public static Point Sum(this Point val1, Point val2)
        {
            var x = val1.X.Sum(val2.X);
            var y = val1.Y.Sum(val2.Y);
            return new Point(x, y);
        }




        public static int Subtract(this int val1, int val2)
        {
            return val1 - val2;
        }

        public static uint Subtract(this uint val1, uint val2)
        {
            return val1 - val2;
        }

        public static long Subtract(this long val1, long val2)
        {
            return val1 - val2;
        }

        public static ulong Subtract(this ulong val1, ulong val2)
        {
            return val1 - val2;
        }

        public static float Subtract(this float val1, float val2)
        {
            return val1 - val2;
        }

        public static double Subtract(this double val1, double val2)
        {
            return val1 - val2;
        }

        public static decimal Subtract(this decimal val1, decimal val2)
        {
            return val1 - val2;
        }

        public static Point Subtract(this Point val1, Point val2)
        {
            var x = val1.X.Subtract(val2.X);
            var y = val1.Y.Subtract(val2.Y);
            return new Point(x, y);
        }





        public static int Multiply(this int val1, int val2)
        {
            return val1 * val2;
        }

        public static uint Multiply(this uint val1, uint val2)
        {
            return val1 * val2;
        }

        public static long Multiply(this long val1, long val2)
        {
            return val1 * val2;
        }

        public static ulong Multiply(this ulong val1, ulong val2)
        {
            return val1 * val2;
        }

        public static float Multiply(this float val1, float val2)
        {
            return val1 * val2;
        }

        public static double Multiply(this double val1, double val2)
        {
            return val1 * val2;
        }

        public static decimal Multiply(this decimal val1, decimal val2)
        {
            return val1 * val2;
        }

        public static Point Multiply(this Point val1, Point val2)
        {
            var x = val1.X.Multiply(val2.X);
            var y = val1.Y.Multiply(val2.Y);
            return new Point(x, y);
        }




        public static int Divide(this int val1, int val2)
        {
            Contract.Requires(val2 != 0);
            return val1 / val2;
        }

        public static uint Divide(this uint val1, uint val2)
        {
            Contract.Requires(val2 != 0);
            return val1 / val2;
        }

        public static long Divide(this long val1, long val2)
        {
            Contract.Requires(val2 != 0);
            return val1 / val2;
        }

        public static ulong Divide(this ulong val1, ulong val2)
        {
            Contract.Requires(val2 != 0);
            return val1 / val2;
        }

        public static float Divide(this float val1, float val2)
        {
            Contract.Requires(val2.NotRefEquals(0));
            return val1 / val2;
        }

        public static double Divide(this double val1, double val2)
        {
            Contract.Requires(val2.NotRefEquals(0));
            return val1 / val2;
        }

        public static decimal Divide(this decimal val1, decimal val2)
        {
            Contract.Requires(val2 != 0);
            return val1 / val2;
        }

        public static Point Divide(this Point val1, Point val2)
        {
            var x = val1.X.Divide(val2.X);
            var y = val1.Y.Divide(val2.Y);
            return new Point(x, y);
        }



        public static int Negate(this int value)
        {
            return value * -1;
        }

        public static long Negate(this long value)
        {
            return value * -1;
        }

        public static float Negate(this float value)
        {
            return value * -1;
        }

        public static double Negate(this double value)
        {
            return value * -1;
        }

        public static decimal Negate(this decimal value)
        {
            return value * -1;
        }

        public static Point Negate(this Point val1, Point val2)
        {
            var x = val1.X.Negate();
            var y = val1.Y.Negate();
            return new Point(x, y);
        }



        public static int Product(this IEnumerable<int> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product *= values[i];
            }
            return product;
        }

        public static long Product(this IEnumerable<long> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product *= values[i];
            }
            return product;
        }

        public static float Product(this IEnumerable<float> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product *= values[i];
            }
            return product;
        }

        public static double Product(this IEnumerable<double> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product *= values[i];
            }
            return product;

        }

        public static decimal Product(this IEnumerable<decimal> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product *= values[i];
            }
            return product;
        }




        public static int Diff(this IEnumerable<int> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product -= values[i];
            }
            return product;
        }

        public static long Diff(this IEnumerable<long> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product -= values[i];
            }
            return product;
        }

        public static float Diff(this IEnumerable<float> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product -= values[i];
            }
            return product;
        }

        public static double Diff(this IEnumerable<double> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product -= values[i];
            }
            return product;

        }

        public static decimal Diff(this IEnumerable<decimal> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product -= values[i];
            }
            return product;
        }




        public static int Quotient(this IEnumerable<int> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product /= values[i];
            }
            return product;
        }

        public static long Quotient(this IEnumerable<long> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product /= values[i];
            }
            return product;
        }

        public static float Quotient(this IEnumerable<float> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product /= values[i];
            }
            return product;
        }

        public static double Quotient(this IEnumerable<double> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product /= values[i];
            }
            return product;

        }

        public static decimal Quotient(this IEnumerable<decimal> source)
        {
            Contract.Requires(source.IsNotNull());

            var values = source.ToList();
            var product = values.FirstOrDefault();

            for (var i = 1; i < values.Count; i++)
            {
                product /= values[i];
            }
            return product;
        }
    }
}