using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ReadOnlyObservableCollection<T> ToReadOnlyObservableCollection<T>(
            this ObservableCollection<T> observableCollection)
        {
            Contract.Requires(observableCollection.IsNotNull());

            return new ReadOnlyObservableCollection<T>(observableCollection);
        }

        public static void AddRange<T>(this ObservableCollection<T> source, IEnumerable<T> itemsToAdd)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(itemsToAdd.IsNotNull());

            itemsToAdd.ForEach(source.Add);
        }

        public static void RemoveRange<T>(this ObservableCollection<T> source, IEnumerable<T> itemsToRemove)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(itemsToRemove.IsNotNull());

            itemsToRemove.ForEach(item => source.Remove(item));
        }

        public static IEnumerable<T> GetRange<T>(this ObservableCollection<T> source, int fromIndex, int toIndex)
        {
            if (source == null)
            {
                yield break;
            }

            for (var i = fromIndex; i <= toIndex; i++)
            {
                yield return source[i];
            }
        }
    }
}