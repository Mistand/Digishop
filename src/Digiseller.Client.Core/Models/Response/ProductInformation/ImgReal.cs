using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "img_real")]
    public class ImgReal
    {
        [XmlAttribute(AttributeName = "height")]
        public int Height { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public int Width { get; set; }
        [XmlText]
        public string Url { get; set; }
    }
}