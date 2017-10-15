using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.TopTwenty
{
    [XmlRoot(ElementName = "digiseller.request")]
    public class DigisellerTopTwentyRequest
    {
        public DigisellerTopTwentyRequest() { }
        public DigisellerTopTwentyRequest(int sellerId, string uId, bool gropping, string languageCode)
        {
            Seller = new Seller(sellerId, uId);
            Group = gropping;
            Lang = languageCode;
        }

        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
        [XmlElement(ElementName = "group")]
        public bool Group { get; set; }
        [XmlElement(ElementName = "lang")]
        public string Lang { get; set; }
    }
}