using System;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Interfaces.ProductReviews;

namespace Digiseller.Client.Core.ViewModels.ProductReviews
{
    public class Review : IReview
    {
        public Review(Models.Response.ProductReviews.Review review)
        {
            if (review.Type.Length > 2)
            {
                var typeString = char.ToUpperInvariant(review.Type[0]) + review.Type.Substring(1);
                Type = Enum.TryParse(typeString, out ReviewType reviewType) ? reviewType : (ReviewType?)null;
            }
            
            Date = DateTime.TryParse(review.Date, out DateTime date) ? date : (DateTime?) null;
            Comment = review.Comment;
            Information = review.Info;
        }

        public ReviewType? Type { get; }
        public DateTime? Date { get; }
        public string Information { get; }
        public string Comment { get; }
    }
}
