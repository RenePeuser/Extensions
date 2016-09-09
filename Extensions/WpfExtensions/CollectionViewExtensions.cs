using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using Extensions;

namespace WpfExtensions
{
    public static class CollectionViewExtensions
    {
        public static void TrySetFilter(this ICollectionView collectionView, Predicate<object> filter)
        {
            if (collectionView.IsNull())
            {
                return;
            }

            collectionView.Filter = filter;
        }

        public static void UpdateSortDescriptions(this ICollectionView collectionView, params SortDescription[] sortDescriptions)
        {
            Contract.Requires(collectionView.IsNotNull());

            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.AddRange(sortDescriptions);
        }
    }
}