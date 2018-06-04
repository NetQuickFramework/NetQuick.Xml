using System.Collections.Generic;
using System.Xml;

namespace NetQuick.Xml.Builders
{
    /// <summary>
    /// Builds a new <see cref="XmlElement"/> based on its name.
    /// </summary>
    public class XmlElementBuilder
    {
        readonly string _name;
        readonly IList<XmlElementBuilder> _childElementBuilders;
        readonly IList<XmlAttributeBuilder> _attributeBuilders;
        XmlDocument _xmlDocument;

        internal XmlElementBuilder(XmlDocument xmlDocument, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new System.ArgumentNullException(nameof(name));
            if (xmlDocument == null)
                throw new System.ArgumentNullException(nameof(xmlDocument));

            _xmlDocument = xmlDocument;
            _name = name;

            _childElementBuilders = new List<XmlElementBuilder>();
            _attributeBuilders = new List<XmlAttributeBuilder>();           
        }

        public XmlElement Build()
        {
            XmlElement xmlElement = _xmlDocument.CreateElement(_name);

            foreach (var xmlAttributeBuilder in _attributeBuilders)
            {
                var xmlAttribute = xmlAttributeBuilder.Build();
                xmlElement.Attributes.Append(xmlAttribute);
                
            }

            foreach (var childElementBuilder in _childElementBuilders)
            {
                var childElement = childElementBuilder.Build();
                xmlElement.AppendChild(childElement);
            }

            return xmlElement;
        }

        /// <summary>
        /// Add a new child element to this element.
        /// </summary>
        /// <param name="name">The name of the new element.</param>
        /// <returns></returns>
        public XmlElementBuilder AddElement(string name)
        {
            var xmlElementBuilder = new XmlElementBuilder(_xmlDocument, name);

            _childElementBuilders.Add(xmlElementBuilder);

            return xmlElementBuilder;
        }

        /// <summary>
        /// Adds a new attribute to to this element.
        /// </summary>
        /// <param name="name">Name of the new attribute.</param>
        /// <param name="value">Value of the new attribute.</param>
        /// <returns></returns>
        public XmlElementBuilder AddAttribute(string name, string value)
        {
            if (value == null)
                throw new System.ArgumentNullException(nameof(value));
            if (name == null)
                throw new System.ArgumentNullException(nameof(name));

            XmlAttributeBuilder xmlAttributeBuilder = new XmlAttributeBuilder(_xmlDocument, name, value);
            _attributeBuilders.Add(xmlAttributeBuilder);

            return this;
        }

        public XmlElementBuilder AddAttribute<T>(string name, T value) where T : struct
        {            
            if (name == null)
                throw new System.ArgumentNullException(nameof(name));

            return AddAttribute(name, value.ToString());
        }
    }
}
