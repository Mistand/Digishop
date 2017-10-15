using System.Xml.Serialization;

namespace Digiseller.Client.Core.Models.Request.CategoryGoods
{
    [XmlRoot(ElementName = "category")]
    public class Category
    {
        public Category(int categoryId)
        {
            Id = categoryId;
        }

        /// <summary>
        ///     For serialization
        /// </summary>
        public Category()
        {
        }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }
}