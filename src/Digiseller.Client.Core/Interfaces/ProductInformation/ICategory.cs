namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Category information
    /// </summary>
    public interface ICategory
    {
        int Id { get; }
        string Name { get; }

        /// <summary>
        /// Count of goods in this category
        /// </summary>
        int GoodsCount { get; }

        /// <summary>
        /// Child category
        /// </summary>
        ICategory ChildCategory { get; }
    }
}