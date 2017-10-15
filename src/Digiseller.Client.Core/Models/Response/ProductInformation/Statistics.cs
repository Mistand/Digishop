using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "statistics")]
    public class Statistics
    {
        [XmlElement(ElementName = "sales")]
        public string Sales { get; set; }
        [XmlElement(ElementName = "refunds")]
        public string Refunds { get; set; }
        [XmlElement(ElementName = "good_reviews")]
        public string GoodReviews { get; set; }
        [XmlElement(ElementName = "bad_reviews")]
        public string BadReviews { get; set; }
    }
}