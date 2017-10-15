using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.TopTwenty
{
    [XmlRoot(ElementName = "sale")]
    public class Sale
    {
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
    }
}