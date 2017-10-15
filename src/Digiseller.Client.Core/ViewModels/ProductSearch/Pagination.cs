using Digiseller.Client.Core.Interfaces.ProductSearch;
using Digiseller.Client.Core.Models.Response.ProductSearch;

namespace Digiseller.Client.Core.ViewModels.ProductSearch
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
