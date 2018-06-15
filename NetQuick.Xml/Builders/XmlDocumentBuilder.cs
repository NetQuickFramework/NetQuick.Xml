using NetQuick.Core.Builders;
using System;
using System.Xml;

namespace NetQuick.Xml.Builders
{
    public class XmlDocumentBuilder : IBuilder<XmlDocument>
    {
        XmlDocument _xmlDocument;
        XmlElementBuilder _rootElementBuilder;
        bool _useXmlDeclaration;

        internal XmlDocumentBuilder(XmlDocument xmlDocument)
        {
            _xmlDocument = xmlDocument ?? throw new ArgumentNullException(nameof(xmlDocument));
        }     

        /// <summary>
        /// Initializes a new document builder.
        /// </summary>
        /// <returns></returns>
        public static XmlDocumentBuilder Initialize()
        {
            return new XmlDocumentBuilder(new XmlDocument());
        }

        /// <summary>
        /// Adds the xml declaration line to the generated <see cref="XmlDocument"/>.
        /// </summary>
        /// <param name="useXmlDeclaration"></param>
        /// <returns></returns>
        public XmlDocumentBuilder UseXmlDeclaration(bool useXmlDeclaration = true)
        {
            _useXmlDeclaration = useXmlDeclaration;
            return this;
        }

        /// <summary>
        /// Adds the root (main) element to the <see cref="XmlDocument"/>.
        /// </summary>
        /// <param name="name">The name of the </param>
        /// <returns>The related builder.</returns>
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
