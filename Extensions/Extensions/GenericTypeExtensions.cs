using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        public static string NameOf<T>(Expression<Func<T>> expression)
        {
            Contract.Requires(expression.IsNotNull());

            return GetNameFromEpxression(expression);
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

        internal static string GetNameFromEpxression(Expression expression)
        {
            if (expression.IsNull())
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var lamda = expression as LambdaExpression;
            if (lamda.IsNull())
            {
                throw new ArgumentNullException(nameof(lamda));
            }

            var mbe = lamda.Body as MemberExpression;
            if (mbe != null)
            {
                return mbe.Member.Name;
            }

            var unary = lamda.Body as UnaryExpression;
            var member = unary?.Operand as MemberExpression;

            if (member != null)
            {
                return member.Member.Name;
            }

            var methodCallExpression = lamda.Body as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return methodCallExpression.Method.Name;
            }

            throw new Exception("Unexpected expression");
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

        public static bool IsAnyOfExpectedValues<T>(this T source, params object[] expectedValues) where T : class
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
    }
}