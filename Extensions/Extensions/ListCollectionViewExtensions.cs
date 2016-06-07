using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Windows.Data;

namespace Extensions
{
    public static class ListCollectionViewExtensions
    {
        public static void SetCustomSort(this ListCollectionView listCollectionView, IComparer comparer)
        {
            Contract.Requires(listCollectionView.IsNotNull());

            listCollectionView.CustomSort = comparer;
        }

        public static void ActivateLiveSorting(this ListCollectionView listCollectionView,
            SortDescription sortDescription)
        {
            Contract.Requires(listCollectionView.IsNotNull());
            Contract.Requires(listCollectionView.CanChangeLiveSorting);

            listCollectionView.SortDescriptions.Add(sortDescription);
            listCollectionView.LiveSortingProperties.Add(sortDescription.PropertyName);
            listCollectionView.IsLiveSorting = true;
        }
    }
}