using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.CategoryGoods
{
    [XmlRoot(ElementName = "pages")]
    public class Pages
    {
        [XmlElement(ElementName = "num")]
        public int PageNumber { get; set; }
        [XmlElement(ElementName = "rows")]
        public int RowsCount { get; set; }
        [XmlAttribute(AttributeName = "cnt")]
        public int PagesCount { get; set; }
    }
}