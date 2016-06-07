using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Extensions
{
    public static class ListExtensions
    {
        public static void AddRange<T>(this IList<T> list, params T[] items)
        {
            Contract.Requires(list.IsNotNull());
            Contract.Requires(items.IsNotNull());

            items.ForEach(item =>
            {
                if (item.IsNotNull())
                {
                    list.Add(item);
                }
            });
        }

        public static void RemoveRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            Contract.Requires(list.IsNotNull());
            Contract.Requires(items.IsNotNull());

            items.ForEach(item =>
            {
                if (item.IsNotNull())
                {
                    list.Remove(item);
                }
            });
        }

        public static string ToStrings<T>(this IList<T> source)
        {
            Contract.Requires(source.IsNotNull());

            var stringBuilder = new StringBuilder();
            source.ForEach(item => stringBuilder.AppendLine(item.ToString()));
            return stringBuilder.ToString();
        }
    }
}