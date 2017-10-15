using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductReviews
{
    [XmlRoot(ElementName = "pages")]
    public class Pages
    {
        [XmlElement(ElementName = "num")]
        public int Num { get; set; }
        [XmlElement(ElementName = "rows")]
        public int Rows { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public int Cnt { get; set; }
    }
}