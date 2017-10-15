using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductSearch
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerProductSearchResponseXml : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "pages")]
        public Pages Pages { get; set; }
        [XmlElement(ElementName = "products")]
        public Products Products { get; set; }
    }
}