using System.ComponentModel;

namespace WpfExtensions
{
    public static class SortDescriptionExtensions
    {
        public static bool IsEqual(this SortDescription source, SortDescription target)
        {
            return source.PropertyName == target.PropertyName && source.Direction == target.Direction;
        }

        public static bool IsNotEqual(this SortDescription source, SortDescription target)
        {
            return !source.IsEqual(target);
        }
    }
}