using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
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

        public static string ToString<T>(this KeyValuePair<string, Func<T, object>> compiledExpression, T argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException("argument");
            }

            var result = string.Format(CultureInfo.InvariantCulture, "{0}[{1}] ", compiledExpression.Key, compiledExpression.Value.Invoke(argument));
            return result;
        }
    }
}