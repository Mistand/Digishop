using System.Collections.Generic;

namespace Digiseller.Client.Core.Interfaces.ProductSearch
{
    /// <summary>
    /// Search product
    /// </summary>
    public interface ISearchProduct
    {
        /// <summary>
        /// Pagination
        /// </summary>
        IPagination Pagination { get; }

        /// <summary>
        /// Products
        /// </summary>
        IEnumerable<IProduct> Products { get; }

        string SearchString { get; }
    }
}