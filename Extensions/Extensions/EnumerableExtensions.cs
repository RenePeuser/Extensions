using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> FilterNullObjects<T>(this IEnumerable<T> source) where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var result = source.Where(item => item != null);
            return result;
        }

        public static TSource FirstOfType<TSource>(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var result = source.FirstOrDefaultOfType<TSource>();
            if (result == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Enumeration does not contains any item of the specific type: {0}", typeof(TSource).Name));
            }

            return result;
        }

        public static TSource FirstOrDefaultOfType<TSource>(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var result = source.OfType<TSource>().FirstOrDefault();
            return result;
        }

        public static TSource FirstOfType<TSource>(this IEnumerable source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            var result = source.FirstOrDefaultOfType(predicate);
            if (result == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Enumeration does not contains any item of the specific type: {0}", typeof(TSource).Name));
            }

            return result;
        }

        public static TSource FirstOrDefaultOfType<TSource>(this IEnumerable source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            var result = source.OfType<TSource>().FirstOrDefault(predicate);
            return result;
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            source.ToList().ForEach(action);
        }

        public static void ForEachOfType<TSource>(this IEnumerable source, Action<TSource> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            source.OfType<TSource>().ToList().ForEach(action);
        }

        public static bool NotSequenceEqualsNullable<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            // no argument checking is needed because SequenceEqualsNullable can handle null values.
            return !first.SequenceEqualsNullable(second);
        }

        public static bool SequenceEqualsNullable<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            return first.SequenceEqual(second);
        }

        public static bool SequenceEqualsOfType<TSource>(this IEnumerable first, IEnumerable second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            return first.OfType<TSource>().SequenceEqual(second.OfType<TSource>());
        }

        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var result = source.ToList().AsReadOnly();
            return result;
        }

        public static List<TSource> ToListOfType<TSource>(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var result = source.OfType<TSource>().ToList();
            return result;
        }

        public static List<TSource> ToListOfTypeOrEmpty<TSource>(this IEnumerable source)
        {
            if (source == null)
            {
                return new List<TSource>();
            }

            var result = source.OfType<TSource>().ToList();
            return result;
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration == null)
            {
                throw new ArgumentNullException("enumeration");
            }

            return new ObservableCollection<T>(enumeration);
        }

        public static ReadOnlyObservableCollection<T> ToReadonlyObservableCollection<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration == null)
            {
                throw new ArgumentNullException("enumeration");
            }

            var readonlyObservableCollection = enumeration.ToObservableCollection().ToReadOnlyObservableCollection();
            return readonlyObservableCollection;
        }


        public static IEnumerable<TSource> WhereOfType<TSource>(this IEnumerable source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            var result = source.OfType<TSource>().Where(predicate);
            return result;
        }

        public static bool IsAnyItemNull<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var result = source.Any(item => item == null);
            return result;
        }

        public static bool IsNotAnyItemNull<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return !source.IsAnyItemNull();
        }

        public static void Dispose<T>(this IEnumerable<T> source) where T : IDisposable
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            source.ToList().ForEach(item => item.Dispose());
        }

        public static List<T> Remove<T>(this IEnumerable<T> source, params T[] itemsToRemove)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (itemsToRemove == null)
            {
                throw new ArgumentNullException("itemsToRemove");
            }

            var items = source.ToList();
            items.RemoveRange(itemsToRemove);
            return items;
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, params T[] expectedItems)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (expectedItems == null)
            {
                throw new ArgumentNullException("expectedItems");
            }

            var sourceContainsAllExpectedItems = expectedItems.All(source.Contains);
            return sourceContainsAllExpectedItems;
        }

        public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] expectedItems)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (expectedItems == null)
            {
                throw new ArgumentNullException("expectedItems");
            }

            var sourceContainsAllExpectedItems = expectedItems.Any(source.Contains);
            return sourceContainsAllExpectedItems;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return !source.Any();
        }

        public static IEnumerable<T> Except<T, TProperty>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TProperty> selector) where T : class
        {
            var result = first.Except(second, selector, selector);
            return result;
        }

        public static IEnumerable<T1> Except<T1, T2, TProperty>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, TProperty> selector1, Func<T2, TProperty> selector2)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException("selector1");
            }

            if (selector2 == null)
            {
                throw new ArgumentNullException("selector2");
            }

            var result = first.InternalExcept(second, selector1, selector2);
            return result;
        }

        public static bool SequenceEqual<T, TProperty>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TProperty> selector) where T : class
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            var result = first.SequenceEqual(second, selector, selector);
            return result;
        }


        public static bool SequenceEqual<T1, T2, TProperty>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, TProperty> selector1, Func<T2, TProperty> selector2)
            where T1 : class
            where T2 : class
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (selector1 == null)
            {
                throw new ArgumentNullException("selector1");
            }

            if (selector2 == null)
            {
                throw new ArgumentNullException("selector2");
            }

            var valueOfFirst = first.Select(selector1).ToList();
            var valueOfSecond = second.Select(selector2).ToList();
            var result = valueOfFirst.SequenceEqual(valueOfSecond);
            return result;
        }

        public static IEnumerable<T> MergeItemsWithoutRemove<T, TProperty>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TProperty> selector) where T : class
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            var targetItems = first.ToList();
            var sourceItems = second.ToList();
            var itemsToAdd = sourceItems.Except(targetItems, selector).ToList();

            foreach (var item in itemsToAdd)
            {
                var index = sourceItems.IndexOf(item);
                targetItems.Insert(index, item);
            }

            return targetItems;
        }

        public static string ToString<T>(this IEnumerable<T> source, string title, params Expression<Func<T, object>>[] infoSelector) where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            if (infoSelector == null)
            {
                throw new ArgumentNullException("infoSelector");
            }

            var compiledExpressions = infoSelector.ToCompiledExpressionWithInfo();
            var stringbuilder = new StringBuilder();
            stringbuilder.AppendLine(title);
            source.ForEach(item => stringbuilder.AppendLine(item.ToString(compiledExpressions)));
            return stringbuilder.ToString();
        }

        public static bool ContainsNoItemWith<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return !source.Any(predicate);
        }

        public static bool HasAny<T>(this IEnumerable<T> source, params object[] expectedValues)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return HasAny(source.ToArray(), expectedValues);
        }

        public static IEnumerable<T> Distinct<T, TProperty>(this IEnumerable<T> source, Func<T, TProperty> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            var dictionary = new Dictionary<TProperty, T>();
            foreach (T item in source)
            {
                var value = selector(item);
                if (!dictionary.ContainsKey(value))
                {
                    dictionary.Add(value, item);
                }
            }

            return dictionary.Values;
        }

        private static IEnumerable<T1> InternalExcept<T1, T2, TProperty>(
            this IEnumerable<T1> first,
            IEnumerable<T2> second,
            Func<T1, TProperty> selector1,
            Func<T2, TProperty> selector2)
        {
            var firstItems = first.ToList();
            var secondItems = second.ToList();

            foreach (T1 item in firstItems)
            {
                var result = secondItems.FirstOrDefault(i => selector2(i).EqualityEquals(selector1(item)));
                if (result == null)
                {
                    yield return item;
                }
            }
        }
    }
}