using System;
using System.Linq;
using System.Xml.Linq;

namespace Extensions
{
    public static class XElementExtensions
    {
        public static T GetAttributeValue<T>(this XElement xElement, string attributeName,
            Func<XAttribute, string> getPropertyName, Func<string, T> converter, T defaultValue)
        {
            if (xElement == null)
            {
                return defaultValue;
            }

            var attribute = xElement.Attributes().FirstOrDefault(item => getPropertyName(item) == attributeName);
            if (attribute == null)
            {
                return defaultValue;
            }

            return converter(attribute.Value);
        }

        public static T GetAttributeValue<T>(this XElement xElement, string attributeName, Func<string, T> converter,
            T defaultValue)
        {
            return GetAttributeValue(xElement, attributeName, XAttributeExtension.GetLocalName, converter, defaultValue);
        }

        public static string GetAttributeValue(this XElement xElement, string attributeName,
            Func<XAttribute, string> getPropertyName, string defaultValue)
        {
            return GetAttributeValue(xElement, attributeName, XAttributeExtension.GetLocalName, Convert.ToString,
                defaultValue);
        }

        public static string GetAttributeValue(this XElement xElement, string attributeName, string defaultValue = null)
        {
            return GetAttributeValue(xElement, attributeName, XAttributeExtension.GetLocalName, defaultValue);
        }

        public static void SetAttributeValue<T>(this XElement xElement, string attributeName, T value)
        {
            if (xElement == null)
            {
                return;
            }

            var attribute = xElement.Attribute(attributeName);
            if (attribute == null)
            {
                return;
            }

            attribute.Value = value.ToString();
        }

        public static bool HasExpectedAttributeWithExpectedValue<T>(this XElement xElement, string attributeName,
            Func<string, T> converter, T expectedValue)
        {
            var result = xElement.GetAttributeValue(attributeName, converter, default(T));
            return ObjectExtensions.RefEquals(result, expectedValue);
        }

        public static bool HasExpectedAttributeWithExpectedValue(this XElement xElement, string attributeName,
            string expectedValue)
        {
            var result = GetAttributeValue(xElement, attributeName, XAttributeExtension.GetLocalName, null);
            return result.NullableEqual(expectedValue);
        }

        public static string GetName(XElement xElement)
        {
            return xElement?.Name.ToString() ?? string.Empty;
        }

        public static string GetLocalName(XElement xElement)
        {
            return xElement == null ? string.Empty : xElement.Name.LocalName;
        }
    }
}