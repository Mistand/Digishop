using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.TopTwenty
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "prices")]
        public Prices Prices { get; set; }
    }
}