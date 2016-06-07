using System.Collections.Concurrent;
using System.Diagnostics.Contracts;

namespace Extensions
{
    public static class ConcurrentDictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            Contract.Requires(dictionary.IsNotNull());
            Contract.Requires(key.IsNotNull());

            TValue result;
            dictionary.TryGetValue(key, out result);
            return result;
        }

        public static void AddOrUpdate<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key,
            TValue value)
        {
            Contract.Requires(dictionary.IsNotNull());
            Contract.Requires(key.IsNotNull());

            dictionary.AddOrUpdate(key, value, (k, v) => value);
        }
    }
}