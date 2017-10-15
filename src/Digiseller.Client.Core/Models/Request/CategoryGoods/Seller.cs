using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.CategoryGoods
{
    [XmlRoot(ElementName = "seller")]
    public class Seller
    {
        public Seller() { }

        public Seller(int sellerId)
        {
            Id = sellerId;
        }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }
}