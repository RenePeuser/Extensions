using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Extensions
{
    public static class CollectionExtensions
    {
        public static void RefillWith<T>(this ICollection<T> collection, IEnumerable<T> itemsForRefill)
        {
            Contract.Requires(collection.IsNotNull());
            Contract.Requires(itemsForRefill.IsNotNull());

            collection.Clear();
            collection.AddRange(itemsForRefill);
        }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> itemsToAdd)
        {
            Contract.Requires(collection.IsNotNull());
            Contract.Requires(itemsToAdd.IsNotNull());

            itemsToAdd.ToList().ForEach(collection.Add);
        }

        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> itemsToRemove)
        {
            Contract.Requires(collection.IsNotNull());
            Contract.Requires(itemsToRemove.IsNotNull());

            itemsToRemove.ToList().ForEach(item => collection.Remove(item));
        }

        public static void RemoveAll<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            Contract.Requires(collection.IsNotNull());
            Contract.Requires(predicate.IsNotNull());

            var itemsToRemove = collection.Where(predicate).ToList();
            collection.RemoveRange(itemsToRemove);
        }

        public static void ReplaceAt<T>(this Collection<T> sourceCollection, int index, T newItem)
        {
            Contract.Requires(sourceCollection.IsNotNull());

            sourceCollection[index] = newItem;
        }

        public static void Replace<T>(this Collection<T> sourceCollection, T oldItem, T newItem)
        {
            Contract.Requires(sourceCollection.IsNotNull());

            var index = sourceCollection.IndexOf(oldItem);
            sourceCollection.ReplaceAt(index, newItem);
        }
    }
}