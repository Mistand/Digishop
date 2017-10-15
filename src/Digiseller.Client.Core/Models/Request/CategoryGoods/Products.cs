using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.CategoryGoods
{
    [XmlRoot(ElementName = "products")]
    public class Products
    {
        /// <summary>
        ///     For serialization
        /// </summary>
        public Products() { }
        public Products(string order, string currency)
        {
            Order = order;
            Currency = currency;
        }

        [XmlElement(ElementName = "order")]
        public string Order { get; set; }

        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
    }
}