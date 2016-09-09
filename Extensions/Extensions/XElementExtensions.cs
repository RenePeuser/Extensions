using System;
using System.Linq;
using System.Xml.Linq;
using Extensions.Helpers;

namespace Extensions
{
    public static class XElementExtensions
    {
        public static byte ToByte(this XElement element, byte defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToByte);
        }

        public static int ToInt(this XElement element, int defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToInt32);
        }

        public static double ToDouble(this XElement element, double defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToDouble);
        }

        public static decimal ToDecimal(this XElement element, decimal defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToDecimal);
        }

        public static float ToFloat(this XElement element, float defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToSingle);
        }

        public static bool ToBool(this XElement element, bool defaultValue = false)
        {
            return element.To(defaultValue, Convert.ToBoolean);
        }

        public static string ValueOrDefault(this XElement element, string defaultValue = null)
        {
            return element.To(defaultValue, Convert.ToString);
        }

        public static byte ToByte(this XElement element, AttributeName attributeName, byte defaultValue = 0)
        {
            return element.To(attributeName, defaultValue, Convert.ToByte);
        }

        public static int ToInt(this XElement element, AttributeName attributeName, int defaultValue = 0)
        {
            return element.To(attributeName, defaultValue, Convert.ToInt32);
        }

        public static double ToDouble(this XElement element, AttributeName attributeName, double defaultValue = 0)
        {
            return element.To(attributeName, defaultValue, Convert.ToDouble);
        }

        public static decimal ToDecimal(this XElement element, AttributeName attributeName, decimal defaultValue = 0)
        {
            return element.To(attributeName, defaultValue, Convert.ToDecimal);
        }

        public static float ToFloat(this XElement element, AttributeName attributeName, float defaultValue = 0)
        {
            return element.To(attributeName, defaultValue, Convert.ToSingle);
        }

        public static bool ToBool(this XElement element, AttributeName attributeName, bool defaultValue = false)
        {
            return element.To(attributeName, defaultValue, Convert.ToBoolean);
        }

        public static string ValueOrDefault(this XElement element, AttributeName attributeName, string defaultValue = null)
        {
            return element.To(attributeName, defaultValue, Convert.ToString);
        }

        public static XAttribute Attribute(this XElement document, AttributeName attributeName)
        {
            var attribute = document.Attributes().FirstOrDefault(a => a.Name.LocalName.Equals(attributeName.Value));
            return attribute;
        }

        private static T To<T>(this XElement element, T defaultValue, Func<string, T> converter)
        {
            if (element == null)
            {
                return defaultValue;
            }

            if (element.Value.IsEmpty())
            {
                return defaultValue;
            }

            var result = converter(element.Value);
            return result;
        }

        private static T To<T>(this XElement element, AttributeName attributeName, T defaultValue, Func<string, T> converter)
        {
            if (element == null)
            {
                return defaultValue;
            }

            var attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                return defaultValue;
            }

            var result = converter(attribute.Value);
            return result;
        }
    }
}