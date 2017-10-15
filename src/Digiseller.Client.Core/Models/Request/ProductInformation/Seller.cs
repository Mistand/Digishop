using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductInformation
{
    [XmlRoot(ElementName = "seller")]
    public class Seller
    {
        public Seller()
        {
            
        }

        public Seller(int id)
        {
            Id = id;
        }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }
}