using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductReviews
{
    [XmlRoot(ElementName = "reviews")]
    public class Reviews
    {
        public Reviews()
        {
            
        }

        public Reviews(string reviewType)
        {
            Type = reviewType;
        }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
    }
}