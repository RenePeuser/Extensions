using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Extensions.Helpers;

namespace Extensions
{
    public static class XContainerExtensions
    {
        public static XElement ElementBy(this XContainer container, LocalName localName)
        {
            Contract.Requires(container.IsNotNull());
            Contract.Requires(localName.IsNotNull());

            var element = container.ElementsBy(localName).FirstOrDefault();
            return element;
        }

        public static IEnumerable<XElement> ElementsBy(this XContainer container, LocalName localName)
        {
            Contract.Requires(container.IsNotNull());
            Contract.Requires(localName.IsNotNull());

            var elements = container.Descendants().Where(item => item.Name.LocalName.Equals(localName.Value));
            return elements;
        }

        public static XElement ElementBy(this XContainer container, AttributeName attributeName)
        {
            Contract.Requires(container.IsNotNull());
            Contract.Requires(attributeName.IsNotNull());

            var element = container.ElementsBy(attributeName).FirstOrDefault();
            return element;
        }

        public static IEnumerable<XElement> ElementsBy(this XContainer container, AttributeName attributeName)
        {
            Contract.Requires(container.IsNotNull());
            Contract.Requires(attributeName.IsNotNull());

            var elements = container.Descendants().Where(item => item.Attributes().Any(a => a.Name.LocalName.Equals(attributeName.Value)));
            return elements;
        }
    }
}