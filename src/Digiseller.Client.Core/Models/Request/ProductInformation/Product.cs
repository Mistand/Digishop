using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductInformation
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        public Product()
        {
            
        }

        public Product(int id)
        {
            Id = id;
        }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }
}
