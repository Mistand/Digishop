using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.SellerProducts
{
    [XmlRoot(ElementName = "digiseller.response")]
    public class DigisellerSellerProductsResponseXml : DigisellerResponseXmlBase
    {
        [XmlElement(ElementName = "id_seller")]
        public int IdSeller { get; set; }
        [XmlElement(ElementName = "name_seller")]
        public string NameSeller { get; set; }
        [XmlElement(ElementName = "cnt_goods")]
        public int CntGoods { get; set; }
        [XmlElement(ElementName = "pages")]
        public int Pages { get; set; }
        [XmlElement(ElementName = "page")]
        public int Page { get; set; }
        [XmlElement(ElementName = "order_col")]
        public string OrderCol { get; set; }
        [XmlElement(ElementName = "order_dir")]
        public string OrderDir { get; set; }
        [XmlElement(ElementName = "rows")]
        public Rows Rows { get; set; }
    }
}