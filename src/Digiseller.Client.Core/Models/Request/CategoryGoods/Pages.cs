using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.CategoryGoods
{
    [XmlRoot(ElementName = "pages")]
    public class Pages
    {
        /// <summary>
        ///     For serialization
        /// </summary>
        public Pages() { }

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