using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductDiscount
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
    }
}
