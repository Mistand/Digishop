using System.Collections.Generic;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "discounts")]
    public class Discounts
    {
        [XmlElement(ElementName = "discount")]
        public List<Discount> Discount { get; set; }
    }
}