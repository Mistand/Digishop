using Digiseller.Client.Core.Interfaces.ProductReviews;
using Digiseller.Client.Core.Models.Response.ProductReviews;

namespace Digiseller.Client.Core.ViewModels.ProductReviews
{
    public class Pagination : IPagination
    {
        public Pagination(Pages pages)
        {
            PageNumber = pages.Num;
            RowsCount = pages.Rows;
            PageCount = pages.Cnt;
        }

        public int PageNumber { get; }
        public int RowsCount { get; }
        public int PageCount { get; }
    }
}