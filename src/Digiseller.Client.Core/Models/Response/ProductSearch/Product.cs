using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductSearch
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "agency_fee")]
        public string AgencyFee { get; set; }
        [XmlElement(ElementName = "snippets")]
        public Snippets Snippets { get; set; }
    }
}