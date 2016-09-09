using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Extensions.Helpers;

namespace Extensions
{
    public static class XDocumentExtensions
    {
        public static XElement ElementBy(this XDocument document, LocalName localName)
        {
            var element = document.ElementsBy(localName).FirstOrDefault();
            return element;
        }

        public static IEnumerable<XElement> ElementsBy(this XDocument document, LocalName localName)
        {
            var elements = document.Descendants().Where(item => item.Name.LocalName.Equals(localName.Value));
            return elements;
        }

        public static XElement ElementBy(this XDocument document, AttributeName attributeName)
        {
            var element = document.ElementsBy(attributeName).FirstOrDefault();
            return element;
        }

        public static IEnumerable<XElement> ElementsBy(this XDocument document, AttributeName attributeName)
        {
            var elements = document.Descendants().Where(item => item.Attributes().Any(a => a.Name.LocalName.Equals(attributeName.Value)));
            return elements;
        }
    }
}