using System.Collections.Generic;
using System.Linq;
using Digiseller.Client.Core.Interfaces.ProductReviews;
using Digiseller.Client.Core.Models.Response.ProductReviews;

namespace Digiseller.Client.Core.ViewModels.ProductReviews
{
    public class ProductReviews : IProductReviews
    {
        public ProductReviews(DigisellerProductReviewsResponseXml responseXml)
        {
            Reviews = new List<IReview>();
            if (responseXml.Reviews?.Review?.Count > 0)
                Reviews = responseXml.Reviews?.Review?.Select(p => new Review(p));

            if(responseXml.Pages != null)
                Pagination = new Pagination(responseXml.Pages);
        }

        public IEnumerable<IReview> Reviews { get; }
        public IPagination Pagination { get; }
    }
}