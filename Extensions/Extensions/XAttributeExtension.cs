using System.Xml.Linq;

namespace Extensions
{
    public static class XAttributeExtension
    {
        public static string GetLocalName(XAttribute xAttribute)
        {
            return xAttribute == null ? string.Empty : xAttribute.Name.LocalName;
        }
    }
}