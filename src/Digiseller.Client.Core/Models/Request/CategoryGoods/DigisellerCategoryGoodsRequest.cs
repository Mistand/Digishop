using System.Xml.Serialization;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Models.Request.CategoryGoods
{
    [XmlRoot(ElementName = "digiseller.request")]
    public class DigisellerCategoryGoodsRequest
    {
        /// <summary>
        ///     For serialization
        /// </summary>
        public DigisellerCategoryGoodsRequest()
        {
        }

        public DigisellerCategoryGoodsRequest(int sellerId, int rootCategory = 0, string languageCode = "",
            int pageNumber = 1, int countGoods = 50, Currency currency = Currency.RUR, Sorting sorting = Sorting.name)
        {
            Category = new Category(rootCategory);
            Seller = new Seller(sellerId);
            Pages = new Pages(pageNumber, countGoods);
            Products = new Products(sorting.ToString(), currency.ToString());
            Lang = languageCode;
        }

        [XmlElement(ElementName = "category")]
        public Category Category { get; set; }

        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }

        [XmlElement(ElementName = "pages")]
        public Pages Pages { get; set; }

        [XmlElement(ElementName = "products")]
        public Products Products { get; set; }

        [XmlElement(ElementName = "lang")]
        public string Lang { get; set; }
    }
}