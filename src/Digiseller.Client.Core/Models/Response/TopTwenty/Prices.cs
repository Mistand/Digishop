using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.TopTwenty
{
    [XmlRoot(ElementName = "prices")]
    public class Prices
    {
        [XmlElement(ElementName = "rur")]
        public decimal Rur { get; set; }
        [XmlElement(ElementName = "usd")]
        public decimal Usd { get; set; }
        [XmlElement(ElementName = "eur")]
        public decimal Eur { get; set; }
        [XmlElement(ElementName = "uah")]
        public decimal Uah { get; set; }
    }
}
