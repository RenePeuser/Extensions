using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;

namespace Extensions
{
    public static class ObjectExtensions
    {
        public static T GetCustomAttribute<T>(this object source, bool inherit = false) where T : Attribute
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().GetCustomAttribute<T>(inherit);
        }

        public static bool HasCustomAttribute<T>(this object source, bool inherit = false) where T : Attribute
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().HasCustomAttribute<T>(inherit);
        }

        public static bool IsImmutable(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsImmutable();
        }

        public static bool NotRefEquals(this object source, object target)
        {
            return !RefEquals(source, target);
        }

        public static bool RefEquals(this object source, object target)
        {
            return ReferenceEquals(source, target);
        }

        public static T As<T>(this object source) where T : class
        {
            var result = source as T;
            return result;
        }

        public static T Cast<T>(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return (T)source;
        }

        public static bool IsTypeOf<T>(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsTypeOf<T>();
        }

        public static bool IsSubClassOf<T>(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsSubclassOf(typeof(T));
        }

        public static bool IsInterfaceImplemented<T>(this object source) where T : class
        {
            Contract.Requires(source.IsNotNull());

            var result = source.GetType().GetInterface<T>();
            return result != null;
        }

        public static bool IsNull(this object source)
        {
            return source == null;
        }

        public static bool IsNotNull(this object source)
        {
            return !source.IsNull();
        }

        public static bool ToBool(this object source)
        {
            if (source.IsNull())
            {
                return false;
            }

            if (source is bool)
            {
                return (bool)source;
            }

            return Convert.ToBoolean(source);
        }

        public static Guid ToGuid(this object source)
        {
            if (source.IsNull())
            {
                return Guid.Empty;
            }

            if (source is Guid)
            {
                return (Guid)source;
            }

            if (!(source is string))
            {
                return Guid.Empty;
            }

            var value = source.ToString();
            return value.ToGuid();
        }


        public static bool NullableEqual(this object source, object target)
        {
            if (source.IsNull() || target.IsNull())
            {
                return RefEquals(source, target);
            }

            return source.Equals(target);
        }

        public static bool NullableNotEqual(this object source, object target)
        {
            return !source.NullableEqual(target);
        }

        public static int ToInt(this object source)
        {
            return source.IsNull() ? 0 : Convert.ToInt32(source);
        }

        public static double ToDouble(this object source, NumberFormatInfo numberFormatInfo = null)
        {
            return source.IsNull() ? 0 : Convert.ToDouble(source, numberFormatInfo);
        }

        public static decimal ToDecimal(this object source, NumberFormatInfo numberFormatInfo = null)
        {
            return source.ToString().ToDecimal();
        }

        public static TimeSpan ToTimeSpan(this object source)
        {
            if (source.IsNull())
            {
                return new TimeSpan();
            }

            if (source is TimeSpan)
            {
                return (TimeSpan)source;
            }

            return new TimeSpan();
        }

        public static DirectoryInfo ToDirectoryInfo(this object source)
        {
            return source as DirectoryInfo;
        }

        public static DateTime ToDateTime(this object source)
        {
            if (source is DateTime)
            {
                return (DateTime)source;
            }

            DateTime result;
            DateTime.TryParse(source.ToString(), out result);
            return result;
        }

        public static FileInfo ToFileInfo(this object source)
        {
            if (source.IsNull())
            {
                return null;
            }

            var info = source.As<FileInfo>();
            if (info != null)
            {
                return info;
            }

            if (source is string)
            {
                return new FileInfo(source.ToString());
            }

            return null;
        }

        public static Uri ToUri(this object source, UriKind uriKind = UriKind.RelativeOrAbsolute)
        {
            return source.IsNull() ? null : new Uri(source.ToString(), uriKind);
        }

        public static T ToEnum<T>(this object value) where T : struct
        {
            T result;
            if (!Enum.TryParse(value.ToString(), out result))
            {
                throw new Exception("Can not parse enum");
            }
            return result;
        }

        public static CultureInfo ToCultureInfo(this object value)
        {
            Contract.Requires(value.IsNotNull());
            Contract.Requires(value is CultureInfo);

            return value.Cast<CultureInfo>();
        }
    }
}