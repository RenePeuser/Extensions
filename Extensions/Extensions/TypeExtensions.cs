using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<T> GetCustomAttributes<T>(this Type type, bool inherit = false) where T : Attribute
        {
            Contract.Requires(type.IsNotNull());

            var attributes = type.GetCustomAttributes(typeof(T), inherit).ToListOfType<T>();
            return attributes;
        }

        public static bool HasCustomAttribute<T>(this Type type, bool inherit = false) where T : Attribute
        {
            Contract.Requires(type.IsNotNull());

            var attribute = type.GetCustomAttribute<T>(inherit);
            var hasCustomAttribute = attribute != null;
            return hasCustomAttribute;
        }

        public static T GetCustomAttribute<T>(this Type type, bool inherit = false) where T : Attribute
        {
            return type.GetCustomAttributes<T>(inherit).FirstOrDefault();
        }

        public static Type GetInterface<T>(this Type type) where T : class
        {
            Contract.Requires(type.IsNotNull());

            var genericType = typeof(T);
            if (!genericType.IsInterface)
            {
                throw new ArgumentException($"The generic type '{typeof(T).Name}' is not an interface");
            }

            var result = type.GetInterface(genericType.Name);
            return result;
        }

        public static bool IsInterfaceImplemented<T>(this Type type) where T : class
        {
            Contract.Requires(type.IsNotNull());

            var result = type.GetInterface<T>();
            return result != null;
        }

        public static bool IsImmutable(this Type type)
        {
            Contract.Requires(type.IsNotNull());

            var result = type.GetCustomAttribute<ImmutableObjectAttribute>();
            return result != null && result.Immutable;
        }

        public static bool IsClsCompliant(this Type type)
        {
            Contract.Requires(type.IsNotNull());

            var attribute = type.GetCustomAttribute<CLSCompliantAttribute>();
            return attribute != null && attribute.IsCompliant;
        }

        public static bool IsSubClassOf<T>(this Type type)
        {
            Contract.Requires(type.IsNotNull());

            return type.IsSubclassOf(typeof(T));
        }

        public static bool IsTypeOf<T>(this Type type)
        {
            Contract.Requires(type.IsNotNull());

            return type == typeof(T);
        }        
    }
}