using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.Categories
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerCategoriesCatalog : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }
    }
}