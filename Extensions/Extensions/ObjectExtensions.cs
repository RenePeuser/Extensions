using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Extensions
{
    public static class ObjectExtensions
    {
        public static bool HasAny(this object source, params object[] expectedValues)

        {
            Contract.Requires(source.IsNotNull());

            if (expectedValues.IsNull())
            {
                return source.IsNull();
            }

            var result = expectedValues.Any(item => expectedValues.Any(value => item.EqualityEquals(source)));
            return result;
        }

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

        public static bool IsNotPublic(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsNotPublic;
        }

        public static bool IsPublic(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsPublic;
        }

        public static bool IsNestedPublic(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsNestedPublic;
        }

        public static bool IsNestedPrivate(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsNestedPrivate;
        }

        public static bool IsNestedFamily(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsNestedFamily;
        }

        public static bool IsNestedAssembly(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsNestedAssembly;
        }

        public static bool IsNestedFamAndAssem(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsNestedFamANDAssem;
        }

        public static bool IsNestedFamOrAssem(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsNestedFamORAssem;
        }

        public static bool IsAutoLayout(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsAutoLayout;
        }

        public static bool IsLayoutSequential(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsLayoutSequential;
        }

        public static bool IsExplicitLayout(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsExplicitLayout;
        }

        public static bool IsClass(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsClass;
        }

        public static bool IsInterface(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsInterface;
        }

        public static bool IsValueType(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsValueType;
        }

        public static bool IsAbstract(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsAbstract;
        }

        public static bool IsSealed(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsSealed;
        }

        public static bool IsEnum(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsEnum;
        }

        public static bool IsSpecialName(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsSpecialName;
        }

        public static bool IsImport(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsImport;
        }

        public static bool IsSerializable(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsSerializable;
        }

        public static bool IsAnsiClass(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsAnsiClass;
        }

        public static bool IsUnicodeClass(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsUnicodeClass;
        }

        public static bool IsAutoClass(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsAutoClass;
        }

        public static bool IsArray(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsArray;
        }

        public static bool IsByRef(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsByRef;
        }

        public static bool IsPointer(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsPointer;
        }

        public static bool IsPrimitive(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsPrimitive;
        }

        public static bool IsComObject(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsCOMObject;
        }

        public static bool IsContextful(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsContextful;
        }

        public static bool IsMarshalByRef(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().IsMarshalByRef;
        }

        public static bool HasElementType(this object source)
        {
            Contract.Requires(source.IsNotNull());

            return source.GetType().HasElementType;
        }
    }
}