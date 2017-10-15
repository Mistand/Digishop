using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.SellerProducts
{
    /// <summary>
    /// Product
    /// </summary>
    public interface IProduct
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
        /// Information
        /// </summary>
        string Information { get; }

        /// <summary>
        /// AdditionalInformation
        /// </summary>
        string AdditionalInformation { get; }

        /// <summary>
        /// Price
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Currency
        /// </summary>
        Currency? Currency { get; }

        /// <summary>
        /// Count of sell
        /// </summary>
        int SellCount { get; }

        /// <summary>
        /// Count of returns
        /// </summary>
        int ReturnCount { get; }

        /// <summary>
        /// Count of goods responses (reviews)
        /// </summary>
        int GoodResponsesCount { get; }

        /// <summary>
        /// Count of bad responses (reviews)
        /// </summary>
        int BadResponsesCount { get; }
    }
}