using System.Collections.Generic;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.CategoryGoods
{
    [XmlRoot(ElementName = "products")]
    public class Products
    {
        [XmlElement(ElementName = "order")]
        public string Order { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "product")]
        public List<Product> Product { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public int Cnt { get; set; }
    }
}