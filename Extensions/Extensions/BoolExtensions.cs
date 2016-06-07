namespace Extensions
{
    public static class BoolExtensions
    {
        public static bool ToBool(this bool? source)
        {
            return source.HasValue && source.Value;
        }
    }
}