using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.TopTwenty
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerTopTwentyResponseXml : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "sales")]
        public Sales Sales { get; set; }
    }
}