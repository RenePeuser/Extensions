namespace Extensions
{
    public static class IntegerExtensions
    {
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

        public static string ToLeadingZero(this int source, int totalWidth)
        {
            return source.ToString().PadLeft(totalWidth, '0');
        }

        public static bool IsMaxValue(this int source)
        {
            return source == int.MaxValue;
        }

        public static bool IsMinValue(this int source)
        {
            return source == int.MinValue;
        }
    }
}