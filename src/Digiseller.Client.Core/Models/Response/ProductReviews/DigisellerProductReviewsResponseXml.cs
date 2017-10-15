using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductReviews
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerProductReviewsResponseXml : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
        [XmlElement(ElementName = "pages")]
        public Pages Pages { get; set; }
        [XmlElement(ElementName = "reviews")]
        public Reviews Reviews { get; set; }
    }
}