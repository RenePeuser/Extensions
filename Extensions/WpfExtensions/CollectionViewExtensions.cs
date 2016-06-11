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

        public static void UpdateSortDescription(this ICollectionView collectionView, SortDescription sortDescription)
        {
            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.Add(sortDescription);
        }
    }
}