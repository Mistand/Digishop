using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductInformation
{
    [XmlRoot(ElementName = "digiseller.request")]
    public class DigisellerProductInfoRequest
    {
        public DigisellerProductInfoRequest() { }
        public DigisellerProductInfoRequest(int sellerId, int productId, string agentUid, string languageCode)
        {
            Product = new Product(productId);
            Seller = new Seller(sellerId);
            PartnerUid = agentUid;
            Lang = languageCode;
        }

        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
        [XmlElement(ElementName = "partner_uid")]
        public string PartnerUid { get; set; }
        [XmlElement(ElementName = "lang")]
        public string Lang { get; set; }
    }
}