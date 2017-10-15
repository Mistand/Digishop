using System.Collections.Generic;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.SellerProducts
{
    /// <summary>
    /// Seller goods
    /// </summary>
    public interface ISellerProducts
    {
        /// <summary>
        /// Seller Id
        /// </summary>
        int SellerId { get; }

        /// <summary>
        /// Seller Name
        /// </summary>
        string SellerName { get; }
        
        /// <summary>
        /// Count of goods
        /// </summary>
        int CountOfGoods { get; }

        /// <summary>
        /// Goods
        /// </summary>
        IEnumerable<IProduct> Products { get; }

        /// <summary>
        /// Page number
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Rows count per page
        /// </summary>
        int RowsCount { get; }

        /// <summary>
        /// Page count
        /// </summary>
        int PageCount { get; }
        
        /// <summary>
        /// Order column
        /// </summary>
        OrderColumn? Column { get; }

        /// <summary>
        /// Order by
        /// </summary>
        OrderDir? OrderDir { get; }
    }
}
