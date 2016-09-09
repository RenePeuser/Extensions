using System.Diagnostics.Contracts;
using System.Windows.Controls;
using System.Windows.Data;
using Extensions;

namespace WpfExtensions
{
    public static class ItemsControlExtensions
    {
        public static ListCollectionView GetListCollectionView(this ItemsControl itemsControl)
        {
            Contract.Requires(itemsControl.IsNull());

            var listCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(itemsControl.ItemsSource);
            return listCollectionView;
        }
    }
}
