using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "file")]
    public class File
    {
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "trial")]
        public string Trial { get; set; }
    }
}