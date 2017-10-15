namespace Digiseller.Client.Core.Interfaces.ProductSearch
{
    /// <summary>
    /// Product
    /// </summary>
    public interface IProduct
    {
        int Id { get; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Price
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Agency fee
        /// </summary>
        int AgencyFee { get; }

        /// <summary>
        /// Snippet
        /// </summary>
        ISnippet Snippet { get; }
    }
}