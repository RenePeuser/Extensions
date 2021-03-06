﻿using System.Collections.Specialized;
using System.Diagnostics.Contracts;

namespace Extensions
{
    public static class NotifyCollectionChangedEventArgsExtensions
    {
        public static int DeltaMoveIndex(this NotifyCollectionChangedEventArgs e)
        {
            Contract.Requires(e.IsNotNull());

            var deltaMovement = e.NewStartingIndex - e.OldStartingIndex;
            return deltaMovement;
        }
    }
}