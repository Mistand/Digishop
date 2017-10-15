using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.CategoryGoods
{
    [XmlRoot(ElementName = "subcategory")]
    public class Subcategory
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public int Cnt { get; set; }
    }
}