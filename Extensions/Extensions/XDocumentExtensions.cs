using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

namespace Extensions
{
    public static class XDocumentExtensions
    {
        public static XElement AddXElement(this XDocument xDocument, XName container, XName xElementName)
        {
            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(container.IsNotNull());
            Contract.Requires(xElementName.IsNotNull());

            var expectedContainer = xDocument.Descendant(container);
            if (expectedContainer == null)
            {
                return null;
            }

            var expectedXNameElement = xDocument.Descendant(xElementName);
            if (expectedXNameElement.IsNotNull())
            {
                return expectedXNameElement;
            }

            var xElement = new XElement(xElementName);
            expectedContainer.Add(xElement);
            return xElement;
        }

        public static void AddOrUpdate<T>(this XDocument xDocument, XName container, XName xElementName, T newValue,
            Func<T, string> converter)
        {
            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(container.IsNotNull());
            Contract.Requires(xElementName.IsNotNull());

            var result = AddXElement(xDocument, container, xElementName);
            if (result == null)
            {
                return;
            }

            result.Value = converter(newValue);
        }

        public static void AddOrUpdate(this XDocument xDocument, XName container, XName xElementName, string newValue)
        {
            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(container.IsNotNull());
            Contract.Requires(xElementName.IsNotNull());

            var result = AddXElement(xDocument, container, xElementName);
            if (result == null)
            {
                return;
            }

            result.Value = newValue;
        }

        public static XElement Descendant(this XDocument xDocument, XName xElementName)
        {
            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(xElementName.IsNotNull());

            return xDocument.Descendants(xElementName).FirstOrDefault();
        }

        public static T GetElementValueByName<T>(this XDocument xDocument, string name,
            Func<XElement, string> getPropertyName, Func<string, T> converter, T defaultValue)
        {
            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(name.IsNotNullOrEmpty());
            Contract.Requires(getPropertyName.IsNotNull());
            Contract.Requires(converter.IsNotNull());

            var element = xDocument.Descendants().FirstOrDefault(item => getPropertyName(item) == name);
            if (element == null)
            {
                return defaultValue;
            }

            return element.Value.IsNullOrEmpty() ? defaultValue : converter(element.Value);
        }

        public static string GetElementValueByName(this XDocument xDocument, string name,
            Func<XElement, string> getPropertyName, string defaultValue = null)
        {
            return xDocument.GetElementValueByName(name, getPropertyName, Convert.ToString, defaultValue);
        }

        public static string GetElementValueByName(this XDocument xDocument, string xElementName,
            Func<string, string> converter, string defaultValue = null)
        {
            return GetElementValueByName(xDocument, xElementName, XElementExtensions.GetLocalName, converter,
                defaultValue);
        }

        public static string GetElementValueByName(this XDocument xDocument, XName xElementName,
            string defaultValue = null)
        {
            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(xElementName.IsNotNull());

            var expectedElement = xDocument.Descendant(xElementName);
            return expectedElement?.Value;
        }

        public static void SetElementValueByName<T>(this XDocument xDocument, string name,
            Func<XElement, string> getPropertyName, T newValue)
        {

            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(name.IsNotNullOrEmpty());
            Contract.Requires(getPropertyName.IsNotNull());

            var element = xDocument?.Descendants().FirstOrDefault(item => getPropertyName(item) == name);
            if (element == null)
            {
                return;
            }

            element.Value = newValue.ToString();
        }

        public static IEnumerable<XElement> GetAllElementsFromElement(this XDocument xDocument, string elementName,
            Func<XElement, string> getPropertyName)
        {
            Contract.Requires(xDocument.IsNotNull());
            Contract.Requires(getPropertyName.IsNotNull());

            if (elementName.IsNullOrEmpty())
            {
                return new List<XElement>();
            }

            var expectedElements = xDocument.GetXElementsByName(elementName, getPropertyName);
            if (expectedElements.IsNullOrEmpty())
            {
                return new List<XElement>();
            }

            return expectedElements.Descendants();
        }

        public static IEnumerable<XElement> GetXElementsByName(this XDocument xDocument, string name)
        {
            return GetXElementsByName(xDocument, name, XElementExtensions.GetName);
        }

        public static IEnumerable<XElement> GetXElementsByName(this XDocument xDocument, string name,
            Func<XElement, string> getPropertyName)
        {
            Contract.Requires(xDocument.IsNotNull());

            return xDocument.Descendants().Where(item => getPropertyName(item) == name);
        }

        public static XElement GetXElementByName(this XDocument xDocument, string name,
            Func<XElement, string> getPropertyName)
        {
            return xDocument.GetXElementsByName(name, getPropertyName).FirstOrDefault();
        }

        public static T GetAttributeValueFromElement<T>(this XDocument xDocument, string xElementName,
            string xAttributeName, Func<string, T> converter, T defaultValue)
        {
            var expectedElement = xDocument.GetXElementByName(xElementName, XElementExtensions.GetLocalName);
            return expectedElement.GetAttributeValue(xAttributeName, converter, defaultValue);
        }

        public static XNamespace GetNamespace(this XDocument xDocument, string expectedNameSpaceKey)
        {
            return xDocument.Root.GetAttributeValue(expectedNameSpaceKey, XAttributeExtension.GetLocalName, null);
        }
    }
}