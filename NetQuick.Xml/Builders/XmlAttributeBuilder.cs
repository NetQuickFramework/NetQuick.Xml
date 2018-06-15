
using System;
using System.Xml;

namespace NetQuick.Xml.Builders
{
    public class XmlAttributeBuilder
    {
        public string Name { get; }
        public string Value { get; }
        public XmlDocument XmlDocument { get; }

        public XmlAttributeBuilder(XmlDocument xmlDocument, string name, string value)
        {
            XmlDocument = xmlDocument ?? throw new ArgumentNullException(nameof(xmlDocument));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Attribute name cannot be null or empty.");

            Value = value;
            Name = name;
        }

        public XmlAttribute Build()
        {
            var xmlAttribute = XmlDocument.CreateAttribute(Name);
            xmlAttribute.Value = Value;
            return xmlAttribute;
        }
    }
}
