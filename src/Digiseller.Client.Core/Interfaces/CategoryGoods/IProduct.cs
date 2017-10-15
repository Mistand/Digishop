using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.CategoryGoods
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
        /// Name of product
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Information
        /// </summary>
        string Information { get; }

        /// <summary>
        /// Price
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Base price
        /// </summary>
        decimal BasePrice { get; }

        /// <summary>
        /// Base currency 
        /// </summary>
        string BaseCurrency { get; }

        /// <summary>
        /// Partner comission
        /// </summary>
        int PartnerComission { get; }

        /// <summary>
        /// Product collection type (digi, pins, etc)
        /// </summary>
        ProductCollectionType? Collection { get; }

        /// <summary>
        /// Product in stock
        /// </summary>
        bool InStock { get; }

        /// <summary>
        /// Count of product in stock
        /// 
        /// This option is available after contacting technical support (documentation)
        /// </summary>
        int CountInStock { get; }
    }
}