using System;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.ProductReviews
{
    /// <summary>
    /// Review
    /// </summary>
    public interface IReview
    {
        /// <summary>
        /// Review type
        /// </summary>
        ReviewType? Type { get; }

        /// <summary>
        /// Review date
        /// </summary>
        DateTime? Date { get; }

        /// <summary>
        /// Buyer review
        /// </summary>
        string Information { get; }

        /// <summary>
        /// Seller comment for this review
        /// </summary>
        string Comment { get; }
    }
}
