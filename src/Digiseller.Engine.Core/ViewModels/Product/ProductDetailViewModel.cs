using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Interfaces.ProductReviews;

namespace Digiseller.Engine.Core.ViewModels.Product
{
    public class ProductDetailViewModel
    {
        public IProduct Product { get; set; }
        public IProductReviews GoodReviews { get; set; }
        public IProductReviews BadReviews { get; set; }
        public IProductReviews AllReviews { get; set; }
    }
}
