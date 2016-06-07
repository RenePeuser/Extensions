using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var name = Enum.GetName(type, enumValue);
            return type.GetField(name).GetCustomAttributes(false).OfType<T>().SingleOrDefault();
        }

        public static IEnumerable<T> ToListOf<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            Contract.Requires(!typeof(T).IsEnum);

            return Enum.GetValues(typeof(T)).ToListOfType<T>();
        }

        public static IEnumerable<T> ToListExceptOf<T>(params T[] ignoreTypes)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var enumList = ToListOf<T>();
            return enumList.Except(ignoreTypes);
        }
    }
}