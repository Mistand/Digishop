using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductReviews
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }
}