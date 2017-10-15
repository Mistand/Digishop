using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "info")]
        public string Info { get; set; }
        [XmlElement(ElementName = "add_info")]
        public string AddInfo { get; set; }
        [XmlElement(ElementName = "release_date")]
        public string ReleaseDate { get; set; }
        [XmlElement(ElementName = "agency_fee")]
        public int AgencyFee { get; set; }
        [XmlElement(ElementName = "in_stock")]
        public int InStock { get; set; }
        [XmlElement(ElementName = "num_in_stock")]
        public int? NumInStock { get; set; }
        [XmlElement(ElementName = "prices")]
        public Prices Prices { get; set; }
        [XmlElement(ElementName = "previews_img")]
        public PreviewsImg PreviewsImg { get; set; }
        [XmlElement(ElementName = "previews_video")]
        public PreviewsVideo PreviewsVideo { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "text")]
        public Text Text { get; set; }
        [XmlElement(ElementName = "file")]
        public File File { get; set; }
        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }
        [XmlElement(ElementName = "discounts")]
        public Discounts Discounts { get; set; }
        [XmlElement(ElementName = "statistics")]
        public Statistics Statistics { get; set; }
        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
    }
}