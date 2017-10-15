using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.TopTwenty
{
    [XmlRoot(ElementName = "seller")]
    public class Seller
    {
        public Seller() { }

        public Seller(int sellerId, string uId)
        {
            Id = sellerId;
            Uid = uId;
        }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "uid")]
        public string Uid { get; set; }
    }
}
