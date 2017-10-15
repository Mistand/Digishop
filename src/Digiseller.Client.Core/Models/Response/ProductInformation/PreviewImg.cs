using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "preview_img")]
    public class PreviewImg
    {
        [XmlElement(ElementName = "img_small")]
        public ImgSmall ImgSmall { get; set; }
        [XmlElement(ElementName = "img_real")]
        public ImgReal ImgReal { get; set; }
    }
}