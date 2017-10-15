using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.SellerProducts
{
    [XmlRoot(ElementName = "row")]
    public class Row
    {
        [XmlElement(ElementName = "name_goods")]
        public string NameGoods { get; set; }
        [XmlElement(ElementName = "info_goods")]
        public string InfoGoods { get; set; }
        [XmlElement(ElementName = "add_info")]
        public string AddInfo { get; set; }
        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "cnt_sell")]
        public int CntSell { get; set; }
        [XmlElement(ElementName = "cnt_return")]
        public int CntReturn { get; set; }
        [XmlElement(ElementName = "cnt_goodresponses")]
        public int CntGoodresponses { get; set; }
        [XmlElement(ElementName = "cnt_badresponses")]
        public int CntBadresponses { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}
