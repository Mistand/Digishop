using System.Collections.Generic;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "previews_video")]
    public class PreviewsVideo
    {
        [XmlElement(ElementName = "preview_video")]
        public List<PreviewVideo> PreviewVideo { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public string Cnt { get; set; }
    }
}