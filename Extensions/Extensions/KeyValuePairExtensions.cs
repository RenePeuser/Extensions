using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Extensions
{
    public static class KeyValuePairExtensions
    {
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            Contract.Requires(keyValuePairs.IsNotNull());

            var dictionary = keyValuePairs.ToDictionary(item => item.Key, item => item.Value);
            return dictionary;
        }
    }
}