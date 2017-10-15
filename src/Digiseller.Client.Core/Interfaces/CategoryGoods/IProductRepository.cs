using System.Collections.Generic;

namespace Digiseller.Client.Core.Interfaces.CategoryGoods
{
    /// <summary>
    /// Product repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Goods
        /// </summary>
        IEnumerable<IProduct> Goods { get; }

        /// <summary>
        /// Pagination
        /// </summary>
        IPagination Pagination { get; }

        /// <summary>
        /// Category
        /// </summary>
        ICategory Category { get; }

        /// <summary>
        /// Subcategories
        /// </summary>
        IEnumerable<ISubcategory> Subcategories { get; }
    }
}