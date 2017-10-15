using System.Collections.Generic;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Response.CategoryGoods
{
    [XmlRoot(ElementName = "subcategories")]
    public class Subcategories
    {
        [XmlElement(ElementName = "subcategory")]
        public List<Subcategory> Subcategory { get; set; }
    }
}