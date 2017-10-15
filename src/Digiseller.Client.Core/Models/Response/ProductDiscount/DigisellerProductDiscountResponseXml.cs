using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductDiscount
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerProductDiscountResponseXml : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
        [XmlElement(ElementName = "discount")]
        public Discount Discount { get; set; }
    }
}