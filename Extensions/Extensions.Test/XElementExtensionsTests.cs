using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Extensions.Test
{
    [TestClass]
    public class ElementByLocalNameTest
    {
        private static XDocument _xDocument;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var resource = typeof(ElementByLocalNameTest).Assembly.GetManifestResourceString("Test.xml");
            _xDocument = XDocument.Parse(resource);
        }

        [TestMethod]
        public void GetStringValueFromExistingElement()
        {
            Assert.AreEqual("Test", _xDocument.ElementBy("StringElement".ToLocalName()).ValueOrDefault());
        }

        [TestMethod]
        public void GetStringValueFromNotExistingElementWithoutDefault()
        {
            Assert.IsNull(_xDocument.ElementBy("NotExists".ToLocalName()).ValueOrDefault());
        }

        [TestMethod]
        public void GetStringValueFromNotExistingElementWithDefault()
        {
            Assert.AreEqual("Default", _xDocument.ElementBy("NotExists".ToLocalName()).ValueOrDefault("Default"));
        }
    }

    [TestClass]
    public class ElementsByLocalNameTest
    {
        private static XDocument _xDocument;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var resource = typeof(ElementByLocalNameTest).Assembly.GetManifestResourceString("MultiElements.xml");
            _xDocument = XDocument.Parse(resource);
        }

        [TestMethod]
        public void ExpectedCount()
        {
            Assert.AreEqual(7, _xDocument.ElementsBy("StringValue".ToLocalName()).Count());
        }

        [TestMethod]
        public void ExpectedValues()
        {
            var expectedStrings = new[] { "Test1", "Test2", "Test3", "Test4", "Test5", "Test6", "Test7" };
            var itemsFromXml = _xDocument.ElementsBy("StringValue".ToLocalName()).Select(item => item.ValueOrDefault());

            Assert.IsTrue(expectedStrings.SequenceEqual(itemsFromXml));
        }
    }

    [TestClass]
    public class ElementsByAttributeNameTest
    {
        private static XDocument _xDocument;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var resource = typeof(ElementByLocalNameTest).Assembly.GetManifestResourceString("ElementsWithAttributes.xml");
            _xDocument = XDocument.Parse(resource);
        }

        [TestMethod]
        public void GetElementWithExpectedAttribute()
        {
            Assert.IsNotNull(_xDocument.ElementBy("Start".ToAttributeName()));
        }

        [TestMethod]
        public void GetElementsWithExpectedAttribute()
        {
            Assert.AreEqual(2, _xDocument.ElementsBy("X".ToAttributeName()).Count());
        }

        [TestMethod]
        public void GetElementWhichNotHasAttribute()
        {
            Assert.IsFalse(_xDocument.ElementsBy("NotExists".ToAttributeName()).Any());
        }

        [TestMethod]
        public void ExpectedValues()
        {
            var expectedElement = _xDocument.ElementBy("Start".ToAttributeName());

            Assert.AreEqual("StartEnd", expectedElement.Name.LocalName);
        }
    }

    [TestClass]
    public class ToIntTest
    {
        private static XDocument _xDocument;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var resource = typeof(ElementByLocalNameTest).Assembly.GetManifestResourceString("ElementsWithAttributes.xml");
            _xDocument = XDocument.Parse(resource);
        }

        [TestMethod]
        public void GetInt32Value()
        {
            Assert.AreEqual(1, _xDocument.ElementBy("IntValue".ToAttributeName()).ToInt());
        }

        [TestMethod]
        public void IsIntType()
        {
            Assert.AreEqual(typeof(int), _xDocument.ElementBy("IntValue".ToAttributeName()).ToInt().GetType());
        }
    }

    [TestClass]
    public class ToDoubleTest
    {
        private static XDocument _xDocument;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var resource = typeof(ElementByLocalNameTest).Assembly.GetManifestResourceString("ElementsWithAttributes.xml");
            _xDocument = XDocument.Parse(resource);
        }

        [TestMethod]
        public void GetInt32Value()
        {
            Assert.AreEqual(3.33, _xDocument.ElementBy("DoubleValue".ToAttributeName()).ToDouble());
        }

        [TestMethod]
        public void IsIntType()
        {
            Assert.AreEqual(typeof(double), _xDocument.ElementBy("DoubleValue".ToAttributeName()).ToDouble().GetType());
        }
    }

    [TestClass]
    public class ToDecimalTest
    {
        private static XDocument _xDocument;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var resource = typeof(ElementByLocalNameTest).Assembly.GetManifestResourceString("ElementsWithAttributes.xml");
            _xDocument = XDocument.Parse(resource);
        }

        [TestMethod]
        public void GetInt32Value()
        {
            Assert.AreEqual(3.33, _xDocument.ElementBy("DoubleValue".ToAttributeName()).ToDecimal());
        }

        [TestMethod]
        public void IsIntType()
        {
            Assert.AreEqual(typeof(double), _xDocument.ElementBy("DoubleValue".ToAttributeName()).ToDecimal().GetType());
        }
    }

    [TestClass]
    public class ValueOrDefaultTest
    {
        private static XDocument _xDocument;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var resource = typeof(ElementByLocalNameTest).Assembly.GetManifestResourceString("ElementsWithAttributes.xml");
            _xDocument = XDocument.Parse(resource);
        }

        [TestMethod]
        public void IsNullIfNotExist()
        {
            Assert.IsNull(_xDocument.ElementBy("NotExists".ToLocalName()).ValueOrDefault());
        }

        [TestMethod]
        public void IsDefaultIfNotExists()
        {
            Assert.AreEqual(string.Empty, _xDocument.ElementBy("NotExists".ToLocalName()).ValueOrDefault(string.Empty));
        }

        [TestMethod]
        public void IsNullIfElementHasNoValue()
        {
            Assert.IsNull(_xDocument.ElementBy("StartEnd".ToLocalName()).ValueOrDefault());
        }

        [TestMethod]
        public void IsDefaultIfElementHasNoValue()
        {
            Assert.AreEqual(string.Empty, _xDocument.ElementBy("StartEnd".ToLocalName()).ValueOrDefault(string.Empty));
        }

        [TestMethod]
        public void IfExpectedValueIfExists()
        {
            Assert.AreEqual("Test", _xDocument.ElementBy("ElementWithValue".ToLocalName()).ValueOrDefault());
        }

        [TestMethod]
        public void IsType()
        {
            Assert.IsTrue(ObjectExtensions.IsTypeOf<int>(null));
        }
    }
}
