using System.Collections.Generic;

namespace Digiseller.Client.Core.Interfaces.ProductReviews
{
    /// <summary>
    /// Reviews repository
    /// </summary>
    public interface IProductReviews
    {
        /// <summary>
        /// Reviews
        /// </summary>
        IEnumerable<IReview> Reviews { get; }

        /// <summary>
        /// Pagination
        /// </summary>
        IPagination Pagination { get; }
    }
}