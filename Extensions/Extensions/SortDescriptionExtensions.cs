using System.ComponentModel;

namespace Extensions
{
    public static class SortDescriptionExtensions
    {
        public static bool AreEqual(this SortDescription source, SortDescription target)
        {
            return source.PropertyName == target.PropertyName && source.Direction == target.Direction;
        }

        public static bool AreNotEqual(this SortDescription source, SortDescription target)
        {
            return !source.AreEqual(target);
        }
    }
}