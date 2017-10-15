using System.Collections.Generic;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "previews_img")]
    public class PreviewsImg
    {
        [XmlElement(ElementName = "preview_img")]
        public List<PreviewImg> PreviewImg { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public string ImagesCount { get; set; }
    }
}