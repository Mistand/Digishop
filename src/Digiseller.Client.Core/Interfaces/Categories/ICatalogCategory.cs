using System.Collections.Generic;

namespace Digiseller.Client.Core.Interfaces.Categories
{
    /// <summary>
    /// ICatalog Category
    /// </summary>
    public interface ICatalogCategory
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Name of this category
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Child categories
        /// </summary>
        IEnumerable<ICatalogCategory> ChildCategories { get; }
    }
}
