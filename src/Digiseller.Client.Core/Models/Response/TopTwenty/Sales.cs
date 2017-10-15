using System.Collections.Generic;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.TopTwenty
{
    [XmlRoot(ElementName = "sales")]
    public class Sales
    {
        [XmlElement(ElementName = "sale")]
        public List<Sale> Sale { get; set; }
    }
}