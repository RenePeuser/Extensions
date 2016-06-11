using System.Diagnostics.Contracts;
using System.Windows;
using Extensions;

namespace WpfExtensions
{
    public static class FrameworkElementExtensions
    {
        public static Style FindImplicitStyleResource<T>(this FrameworkElement frameworkElement)
            where T : FrameworkElement
        {
            Contract.Requires(frameworkElement.IsNotNull());

            var resourceDictionary = frameworkElement.Resources;
            var expectedStyle = resourceDictionary.Values.FirstOrDefaultOfType<Style>(item => item.TargetType == typeof(T));
            return expectedStyle;
        }
    }
}