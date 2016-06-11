using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestExtension
{
    public static class PrivateObjectExtensions
    {
        public static T GetField<T>(this PrivateObject privateObject, string fieldName) where T : class
        {
            Contract.Requires(privateObject.IsNotNull());
            Contract.Requires(fieldName.IsNotNullOrEmpty());

            return privateObject.GetField(fieldName).As<T>();
        }

        public static void SetProperty<T>(this PrivateObject privateObject, Expression<Func<T>> propertyExpression,
            T newValue)
        {
            Contract.Requires(privateObject.IsNotNull());
            Contract.Requires(propertyExpression.IsNotNull());

            var properyName = propertyExpression.ExtractPropertyName();
            privateObject.SetProperty(properyName, newValue);
        }
    }
}