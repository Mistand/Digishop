using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductSearch
{
    [XmlRoot(ElementName = "digiseller.request")]
    public class DigisellerProductSearchRequest
    {
        public DigisellerProductSearchRequest() { }
        public DigisellerProductSearchRequest(int sellerId, string search, string currencyCode, int pageNumber = 1, int rowsCount = 20)
        {
            Seller = new Seller(sellerId);
            Products = new Products(search, currencyCode);
            Pages = new Pages(pageNumber, rowsCount);
        }

        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
        [XmlElement(ElementName = "products")]
        public Products Products { get; set; }
        [XmlElement(ElementName = "pages")]
        public Pages Pages { get; set; }
    }
}