using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "categories")]
    public class Categories
    {
        [XmlElement(ElementName = "category")]
        public Category Category { get; set; }
    }
}