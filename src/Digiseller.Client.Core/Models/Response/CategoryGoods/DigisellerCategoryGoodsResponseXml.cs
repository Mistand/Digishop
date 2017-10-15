using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.CategoryGoods
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerCategoryGoodsResponseXml : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }
        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
        [XmlElement(ElementName = "pages")]
        public Pages Pages { get; set; }
        [XmlElement(ElementName = "subcategories")]
        public Subcategories Subcategories { get; set; }
        [XmlElement(ElementName = "products")]
        public Products Products { get; set; }
    }
}