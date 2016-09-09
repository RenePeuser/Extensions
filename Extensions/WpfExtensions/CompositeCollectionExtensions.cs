using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Data;
using Extensions;

namespace WpfExtensions
{
    public static class CompositeCollectionExtensions
    {
        public static void TrySetSortDescription(this CompositeCollection compositeCollection,
            SortDescription sortDescription)
        {
            Contract.Requires(compositeCollection.IsNotNull());

            var collectionViews = compositeCollection.ContainerCollectionsOfType<ICollectionView>().ToList();

            if (!collectionViews.Any())
            {
                throw new ArgumentException("CompositeCollection does not contains ICollectionView to set sort description");
            }

            collectionViews.ForEach(item => item.UpdateSortDescriptions(sortDescription));
        }

        public static IEnumerable<T> ContainerCollectionsOfType<T>(this CompositeCollection compositeCollection)
            where T : ICollectionView
        {
            Contract.Requires(compositeCollection.IsNotNull());

            var collectionViews = compositeCollection.OfType<CollectionContainer>().Select(item => item.Collection).OfType<T>();
            return collectionViews;
        }
    }
}