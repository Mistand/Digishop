using System.Xml.Serialization;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Models.Request.ProductDiscount
{
    [XmlRoot(ElementName = "digiseller.request")]
    public class DigisellerProductDiscountRequest
    {
        public DigisellerProductDiscountRequest()
        {
            
        }

        public DigisellerProductDiscountRequest(int productId, string email, Currency currency = Currency.RUR)
        {
            Product = new Product(productId, currency.ToString());
            Email = email;
        }

        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
    }
}