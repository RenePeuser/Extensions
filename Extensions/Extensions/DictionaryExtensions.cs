using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            Contract.Requires(dictionary.IsNotNull());
            Contract.Requires(key.IsNotNull());

            TValue result;
            dictionary.TryGetValue(key, out result);
            return result;
        }
    }
}