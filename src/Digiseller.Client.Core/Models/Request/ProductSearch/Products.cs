using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductSearch
{
    [XmlRoot(ElementName = "products")]
    public class Products
    {
        public Products()
        {
            
        }

        public Products(string searchString, string currencyCode)
        {
            Search = searchString;
            Currency = currencyCode;
        }

        [XmlElement(ElementName = "search")]
        public string Search { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
    }
}