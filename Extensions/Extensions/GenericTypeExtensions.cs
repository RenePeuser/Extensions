using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Extensions
{
    public static class GenericTypeExtensions
    {
        public static string NameOf<TClass, TNameOf>(this TClass source, Expression<Func<TClass, TNameOf>> expression)
            where TClass : class
        {
            Contract.Requires(expression.IsNotNull());

            return expression.NameOf();
        }

        public static void SetPropertyValue<TClass, TProperty>(this TClass source,
            Expression<Func<TClass, TProperty>> expression, object value)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(expression.IsNotNull());

            var memberSelectorExpression = expression.Body as MemberExpression;
            var property = memberSelectorExpression?.Member as PropertyInfo;
            property?.SetValue(source, value, null);
        }

        public static TProperty GetPropertyValue<TClass, TProperty>(this TClass source,
            Expression<Func<TClass, TProperty>> expression)
        {
            var memberSelectorExpression = expression.Body as MemberExpression;
            var property = memberSelectorExpression?.Member as PropertyInfo;
            if (property != null)
            {
                return (TProperty)property.GetValue(source);
            }

            return default(TProperty);
        }

        public static void TryDispose<T>(this T source) where T : IDisposable
        {
            if (source == null)
            {
                return;
            }

            source.Dispose();
        }

        public static bool EqualityEquals<T>(this T source, T target)
        {
            return EqualityComparer<T>.Default.Equals(source, target);
        }

        public static bool NotEqualityEquals<T>(this T source, T target)
        {
            return !source.EqualityEquals(target);
        }

        public static IList<T> ToIList<T>(this T item)
        {
            return new List<T> { item };
        }

        public static bool HasAny<T>(this T source, params object[] expectedValues) where T : class
        {
            if (source.EqualityEquals<object>(expectedValues))
            {
                return true;
            }

            if (expectedValues == null)
            {
                return false;
            }

            var result = expectedValues.Any(item => item.EqualityEquals(source));
            return result;
        }

        public static void IfNotNullThen<T>(this T source, Func<T, Action> action) where T : class
        {
            if (source == null)
            {
                return;
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            action(source)();
        }

        public static void IfNotNullThen<T>(this T source, Action action)
        {
            if (source == null)
            {
                return;
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            action();
        }

        public static string ToString<T>(this T source, string title, params Expression<Func<T, object>>[] infoSelector) where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            if (infoSelector == null)
            {
                throw new ArgumentNullException("infoSelector");
            }

            var compiledExpressions = infoSelector.ToCompiledExpressionWithInfo();
            var stringbuilder = new StringBuilder();
            stringbuilder.AppendLine(title);
            stringbuilder.AppendLine(source.ToString(compiledExpressions));
            return stringbuilder.ToString();
        }

        public static string ToString<T>(this T source, Dictionary<string, Func<T, object>> compiledExpressions)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (compiledExpressions == null)
            {
                throw new ArgumentNullException("compiledExpressions");
            }

            var stringbuilder = new StringBuilder();
            compiledExpressions.ForEach(item => stringbuilder.Append(item.ToString(source)));
            return stringbuilder.ToString();
        }

        public static string GetTypeName<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return source.GetType().Name;
        }
    }
}