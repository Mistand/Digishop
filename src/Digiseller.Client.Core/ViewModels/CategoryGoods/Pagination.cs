using Digiseller.Client.Core.Interfaces.CategoryGoods;
using Digiseller.Client.Core.Models.Response.CategoryGoods;

namespace Digiseller.Client.Core.ViewModels.CategoryGoods
{
    public class Pagination : IPagination
    {
        public Pagination(Pages pages)
        {
            PageNumber = pages.PageNumber;
            RowsCount = pages.RowsCount;
            PagesCount = pages.PagesCount;
        }

        public int PageNumber { get; }
        public int RowsCount { get; }
        public int PagesCount { get; }
    }
}