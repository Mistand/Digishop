using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductReviews
{
    [XmlRoot(ElementName = "review")]
    public class Review
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "info")]
        public string Info { get; set; }
        [XmlElement(ElementName = "comment")]
        public string Comment { get; set; }
        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public long Id { get; set; }
    }
}