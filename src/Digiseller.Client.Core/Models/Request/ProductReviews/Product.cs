using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductReviews
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        public Product()
        {
            
        }

        public Product(int productId)
        {
            Id = productId;
        }
        
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }
}