using System.Collections.Generic;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductReviews
{
    [XmlRoot(ElementName = "reviews")]
    public class Reviews
    {
        [XmlElement(ElementName = "review")]
        public List<Review> Review { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public int Cnt { get; set; }
    }
}