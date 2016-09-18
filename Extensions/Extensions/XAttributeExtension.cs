using System;
using System.Xml.Linq;

namespace Extensions
{
    public static class XAttributeExtension
    {
        public static byte ToByte(this XAttribute element, byte defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToByte);
        }

        public static int ToInt(this XAttribute element, int defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToInt32);
        }

        public static double ToDouble(this XAttribute element, double defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToDouble);
        }

        public static decimal ToDecimal(this XAttribute element, decimal defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToDecimal);
        }

        public static float ToFloat(this XAttribute element, float defaultValue = 0)
        {
            return element.To(defaultValue, Convert.ToSingle);
        }

        public static bool ToBool(this XAttribute element, bool defaultValue = false)
        {
            return element.To(defaultValue, Convert.ToBoolean);
        }

        public static string ValueOrDefault(this XAttribute element, string defaultValue = null)
        {
            return element.To(defaultValue, Convert.ToString);
        }

        private static T To<T>(this XAttribute element, T defaultValue, Func<string, T> converter)
        {
            if (element == null)
            {
                return defaultValue;
            }

            var result = converter(element.Value);
            return result;
        }
    }
}