using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.ProductInformation
{
    [XmlRoot(ElementName = "prices")]
    public class Prices
    {
        [XmlElement(ElementName = "wmz")]
        public string Wmz { get; set; }
        [XmlElement(ElementName = "wmr")]
        public string Wmr { get; set; }
        [XmlElement(ElementName = "wme")]
        public string Wme { get; set; }
        [XmlElement(ElementName = "wmu")]
        public string Wmu { get; set; }
        [XmlElement(ElementName = "wmx")]
        public string Wmx { get; set; }
        [XmlElement(ElementName = "rcc")]
        public string Rcc { get; set; }
        [XmlElement(ElementName = "zcc")]
        public string Zcc { get; set; }
        [XmlElement(ElementName = "ecc")]
        public string Ecc { get; set; }
        [XmlElement(ElementName = "mts")]
        public string Mts { get; set; }
        [XmlElement(ElementName = "bln")]
        public string Bln { get; set; }
        [XmlElement(ElementName = "mgf")]
        public string Mgf { get; set; }
        [XmlElement(ElementName = "tl2")]
        public string Tl2 { get; set; }
        [XmlElement(ElementName = "pcr")]
        public string Pcr { get; set; }
        [XmlElement(ElementName = "mrr")]
        public string Mrr { get; set; }
        [XmlElement(ElementName = "qsr")]
        public string Qsr { get; set; }
        [XmlElement(ElementName = "atm")]
        public string Atm { get; set; }
        [XmlElement(ElementName = "rub")]
        public string Rub { get; set; }
        [XmlElement(ElementName = "bnk")]
        public string Bnk { get; set; }
    }
}
