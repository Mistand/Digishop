using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.ProductSearch
{
    [XmlRoot(ElementName = "pages")]
    public class Pages
    {
        public Pages()
        {
            
        }

        public Pages(int pageNumber, int rowsCount)
        {
            Num = pageNumber;
            Rows = rowsCount;
        }

        [XmlElement(ElementName = "num")]
        public int Num { get; set; }
        [XmlElement(ElementName = "rows")]
        public int Rows { get; set; }
    }
}