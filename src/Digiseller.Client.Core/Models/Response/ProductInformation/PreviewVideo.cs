using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "preview_video")]
    public class PreviewVideo
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "preview")]
        public string Preview { get; set; }
    }
}