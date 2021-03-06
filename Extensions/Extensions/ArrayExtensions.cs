﻿using System.Linq;

namespace Extensions
{
    public static class ArrayExtensions
    {
        public static bool HasAny<T>(this T[] source, params object[] expectedValues)
        {
            var itemsToCheck = source;
            var result = itemsToCheck.Any(item => expectedValues.Any(value => item.EqualityEquals(value)));
            return result;
        }
    }
}
