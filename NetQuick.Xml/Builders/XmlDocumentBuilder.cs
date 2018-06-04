using System;
using System.Xml;

namespace NetQuick.Xml.Builders
{
    public class XmlDocumentBuilder
    {
        XmlDocument _xmlDocument;
        XmlElementBuilder _rootElementBuilder;
        bool _useXmlDeclaration;

        public XmlDocumentBuilder()
        {          
            _xmlDocument = new XmlDocument();
        }

        public XmlDocumentBuilder UseXmlDeclaration(bool useXmlDeclaration = true)
        {
            _useXmlDeclaration = useXmlDeclaration;
            return this;
        }

        public XmlElementBuilder AddRootElement(string name)
        {
            if (_rootElementBuilder != null)
            {
                throw new NotSupportedException("Root element already exists, only one root element is allowed.");
            }

            _rootElementBuilder = new XmlElementBuilder(_xmlDocument, name);
            return _rootElementBuilder;
        }

        public XmlDocument Build()
        {
            if (_useXmlDeclaration)
            {
                XmlDeclaration xmlDeclaration = _xmlDocument.CreateXmlDeclaration("1.0", "utf-8", "yes");
                _xmlDocument.AppendChild(xmlDeclaration);
            }

            _xmlDocument.AppendChild(_rootElementBuilder.Build());

            return _xmlDocument;
        }
    }
}
