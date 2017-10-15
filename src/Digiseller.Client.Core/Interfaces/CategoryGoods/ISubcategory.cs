namespace Digiseller.Client.Core.Interfaces.CategoryGoods
{
    /// <summary>
    /// ISubcategory
    /// </summary>
    public interface ISubcategory
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Count of goods in current category
        /// </summary>
        int GoodsCount { get; }
    }
}