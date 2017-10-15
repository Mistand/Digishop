using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductReviews
{
    [XmlRoot(ElementName = "seller")]
    public class Seller
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        public Seller()
        {
                
        }

        public Seller(int sellerId)
        {
            Id = sellerId;
        }
    }
}
