using System.Xml.Serialization;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Models.Request.ProductReviews
{
    [XmlRoot(ElementName = "digiseller.request")]
    public class DigisellerProductReviewsRequest
    {
        public DigisellerProductReviewsRequest()
        {

        }

        public DigisellerProductReviewsRequest(int sellerId, int productId, int pageNumber, int rowsCount, ReviewType reviewType = ReviewType.All)
        {
            Seller = new Seller(sellerId);
            Product = new Product(productId);
            Pages = new Pages(pageNumber, rowsCount);
            Reviews = new Reviews(reviewType.ToString().ToLower());
        }

        [XmlElement(ElementName = "seller")]
        public Seller Seller { get; set; }
        [XmlElement(ElementName = "product")]
        public Product Product { get; set; }
        [XmlElement(ElementName = "reviews")]
        public Reviews Reviews { get; set; }
        [XmlElement(ElementName = "pages")]
        public Pages Pages { get; set; }
    }
}