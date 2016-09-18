using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Extensions
{
    public static class ExpressionExtensions
    {
        public static string ExtractPropertyName<T>(this Expression<Func<T>> propertyExpression)
        {
            Contract.Requires(propertyExpression.IsNotNull());

            var memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null)
            {
                throw new ArgumentException("Expression is not a member expression", "propertyExpression");
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException("Member of member expression is not a property info", "propertyExpression");
            }

            if (propertyInfo.GetGetMethod(true).IsStatic)
            {
                throw new ArgumentException("Gets the accessors of the property info is static", "propertyExpression");
            }
            else
            {
                return memberExpression.Member.Name;
            }
        }

        public static string NameOf(this Expression expression)
        {
            Contract.Requires(expression.IsNotNull());

            var lambdaExpression = expression as LambdaExpression;
            if (lambdaExpression == null)
            {
                throw new ArgumentException("Expression is not a LambdaExpression");
            }

            string name = null;

            var memberExpression = lambdaExpression.Body as MemberExpression;
            if (memberExpression != null)
            {
                name = memberExpression.Member.Name;
            }

            var unaryExpression = lambdaExpression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var member = unaryExpression.Operand as MemberExpression;
                if (member != null)
                {
                    name = member.Member.Name;
                }
            }

            var methodCallExpression = lambdaExpression.Body as MethodCallExpression;
            if (methodCallExpression != null)
            {
                name = methodCallExpression.Method.Name;
            }

            if (name == null)
            {
                throw new ArgumentException("Unknown expression type for extracting name.", "expression");
            }

            return name;
        }

        public static Dictionary<string, Func<T, object>> ToCompiledExpressionWithInfo<T>(
            this Expression<Func<T, object>>[] expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }

            var result = expressions.ToDictionary(item => item.NameOf(), item => item.Compile());
            return result;
        }
    }
}