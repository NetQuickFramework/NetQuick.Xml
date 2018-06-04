
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
            XmlDocument = xmlDocument;
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
