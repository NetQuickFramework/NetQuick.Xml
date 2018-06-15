using NetQuick.Xml.Builders;
using Xunit;

namespace NetQuick.Xml.Test.Builders
{
    public class XmlDocumentBuilderTest
    {
        [Fact]
        public void InitializeNewBuilder_DocumentBuilderIsCreated()
        {
            var documentBuilder = XmlDocumentBuilder.Initialize();
            Assert.NotNull(documentBuilder);
        }
    }
}
