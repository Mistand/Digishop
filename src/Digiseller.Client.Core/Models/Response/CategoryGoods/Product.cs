using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.CategoryGoods
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "info")]
        public string Info { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "base_price")]
        public string BasePrice { get; set; }
        [XmlElement(ElementName = "base_currency")]
        public string BaseCurrency { get; set; }
        [XmlElement(ElementName = "partner_comiss")]
        public int PartnerComiss { get; set; }
        [XmlElement(ElementName = "collection")]
        public string Collection { get; set; }
        [XmlElement(ElementName = "in_stock")]
        public int? InStock { get; set; }
        [XmlElement(ElementName = "num_in_stock")]
        public int? NumInStock { get; set; }
        [XmlAttribute(AttributeName = "img")]
        public string Img { get; set; }
        [XmlAttribute(AttributeName = "icon")]
        public string Icon { get; set; }
    }
}