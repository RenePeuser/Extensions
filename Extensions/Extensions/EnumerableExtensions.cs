using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static TimeSpan Sum<T>(this IEnumerable<T> enumeration, Func<T, TimeSpan> selector)
        {
            Contract.Requires(enumeration.IsNotNull());
            Contract.Requires(selector.IsNotNull());

            var result = enumeration.Select(selector);
            var sum = result.Aggregate(new TimeSpan(), (span, timeSpan) => span.Add(timeSpan));
            return sum;
        }

        public static void ForEachReverse<T>(this IEnumerable<T> source, Action<T> action)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(action.IsNotNull());

            foreach (var item in source.Reverse())
            {
                action(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration == null)
            {
                return true;
            }

            return !enumeration.Any();
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> enumeration)
        {
            return !enumeration.IsNullOrEmpty();
        }

        public static IEnumerable<TSource> ConcatNullable<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            if (first.IsNull() && second.IsNull())
            {
                return new List<TSource>();
            }

            if (first.IsNull())
            {
                return second;
            }

            if (second.IsNull())
            {
                return first;
            }

            return first.Concat(second);
        }

        public static IEnumerable<TResult> MultiSelect<TSource, TResult>(this IEnumerable<TSource> source,
            params Func<TSource, TResult>[] selectors)
        {
            if (source.IsNull())
            {
                return new List<TResult>();
            }

            if (selectors.IsNull())
            {
                return new List<TResult>();
            }

            return selectors.SelectMany(source.Select);
        }

        public static IEnumerable<T> AddRange<T>(this IEnumerable<T> list, IEnumerable<T> rangeToAdd)
        {
            Contract.Requires(list.IsNotNull());
            Contract.Requires(rangeToAdd.IsNotNull());

            var tempList = list.ToList();
            tempList.AddRange(rangeToAdd);
            return tempList;
        }

        public static IEnumerable<T> FilterNullObjects<T>(this IEnumerable<T> source)
        {
            Contract.Requires(source.IsNotNull());

            var result = source.Where(item => item != null);
            return result;
        }

        public static TSource FirstOfType<TSource>(this IEnumerable source, Func<TSource, bool> predicate)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(predicate.IsNotNull());

            var result = source.OfType<TSource>().First(predicate);
            return result;
        }

        public static TSource FirstOfType<TSource>(this IEnumerable source)
        {
            Contract.Requires(source.IsNotNull());

            var result = source.OfType<TSource>().First();
            return result;
        }

        public static TSource FirstOrDefaultOfType<TSource>(this IEnumerable source, Func<TSource, bool> predicate)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(predicate.IsNotNull());

            var result = source.OfType<TSource>().FirstOrDefault(predicate);
            return result;
        }

        public static TSource FirstOrDefaultOfType<TSource>(this IEnumerable source)
        {
            Contract.Requires(source.IsNotNull());

            var result = source.OfType<TSource>().FirstOrDefault();
            return result;
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(action.IsNotNull());


            source.ToList().ForEach(action);
        }

        public static void ForEachOfType<TSource>(this IEnumerable source, Action<TSource> action)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(action.IsNotNull());

            source.OfType<TSource>().ToList().ForEach(action);
        }

        public static bool NotSequenceEqualsNullable<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
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
            Contract.Requires(first.IsNotNull());
            Contract.Requires(second.IsNotNull());

            return first.OfType<TSource>().SequenceEqual(second.OfType<TSource>());
        }

        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            Contract.Requires(source.IsNotNull());

            var result = source.ToList().AsReadOnly();
            return result;
        }

        public static List<TSource> ToListOfType<TSource>(this IEnumerable source)
        {
            Contract.Requires(source.IsNotNull());

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
            Contract.Requires(enumeration.IsNotNull());

            return new ObservableCollection<T>(enumeration);
        }

        public static ReadOnlyObservableCollection<T> ToReadonlyObservableCollection<T>(this IEnumerable<T> enumeration)
        {
            Contract.Requires(enumeration.IsNotNull());

            var readonlyObservableCollection = enumeration.ToObservableCollection().ToReadOnlyObservableCollection();
            return readonlyObservableCollection;
        }

        public static IEnumerable<TSource> WhereOfType<TSource>(this IEnumerable source, Func<TSource, bool> predicate)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(predicate.IsNotNull());

            var result = source.OfType<TSource>().Where(predicate);
            return result;
        }

        public static bool IsAnyItemNull<T>(this IEnumerable<T> source)
        {
            Contract.Requires(source.IsNotNull());

            var result = source.Any(item => item == null);
            return result;
        }

        public static bool IsNotAnyItemNull<T>(this IEnumerable<T> source)
        {
            return !source.IsAnyItemNull();
        }

        public static void Dispose<T>(this IEnumerable<T> source) where T : IDisposable
        {
            Contract.Requires(source.IsNotNull());

            source.ToList().ForEach(item => item.Dispose());
        }

        public static List<T> Remove<T>(this IEnumerable<T> source, params T[] itemsToRemove)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(itemsToRemove.IsNotNull());

            var items = source.ToList();
            CollectionExtensions.RemoveRange(items, itemsToRemove);
            return items;
        }

        public static bool CheckForValues<T>(this IEnumerable<T> source, params object[] expectedValues)
        {
            Contract.Requires(source.IsNotNull());

            var sourceArray = source.ToArray();
            return sourceArray.HasAny(expectedValues);
        }
    }
}