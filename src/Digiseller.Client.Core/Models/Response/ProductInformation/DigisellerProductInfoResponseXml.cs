using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerProductInfoResponseXml : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
    }
}