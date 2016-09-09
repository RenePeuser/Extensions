using System;
using System.ComponentModel;
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
            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.AddRange(sortDescriptions);
        }
    }
}