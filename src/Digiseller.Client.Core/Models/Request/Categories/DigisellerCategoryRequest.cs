using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.Categories
{
    [XmlRoot(ElementName = "digiseller.request")]
    public class DigisellerCategoryRequest
    {
        public DigisellerCategoryRequest() { }
        public DigisellerCategoryRequest(int sellerId, int categoryId, string languageCode)
        {
            Seller = new Seller(sellerId);
            Category = new Category(categoryId);
            Lang = languageCode;
        }

        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
        [XmlElement(ElementName = "category")]
        public Category Category { get; set; }
        [XmlElement(ElementName = "lang")]
        public string Lang { get; set; }
    }
}