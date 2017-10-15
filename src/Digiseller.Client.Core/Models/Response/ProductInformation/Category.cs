using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "category")]
    public class Category
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public int GoodsCount { get; set; }
        [XmlElement(ElementName = "category")]
        public Category ChildCategory { get; set; }
    }
}