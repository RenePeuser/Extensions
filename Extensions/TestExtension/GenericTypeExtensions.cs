using System.Diagnostics.Contracts;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestExtension
{
    public static class GenericTypeExtensions
    {
        public static PrivateObject ToPrivateObject<T>(this T source)
        {
            Contract.Requires(source.IsNotNull());

            return new PrivateObject(source);
        }
    }
}
