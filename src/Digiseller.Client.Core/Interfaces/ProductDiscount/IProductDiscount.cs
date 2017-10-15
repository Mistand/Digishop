using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.ProductDiscount
{
    /// <summary>
    /// Product discount
    /// </summary>
    public interface IProductDiscount
    {
        /// <summary>
        /// Product price in this currency
        /// </summary>
        decimal ProductPrice { get; }

        /// <summary>
        /// Price Currency
        /// </summary>
        Currency? ProductCurrency { get; }

        /// <summary>
        /// Discount percent
        /// </summary>
        int DiscountPercent { get; }

        /// <summary>
        /// Total purchase amount
        /// </summary>
        decimal Total { get; }

        /// <summary>
        /// Discount currency.
        /// 
        /// Always in USD (Documentation Digiseller)
        /// </summary>
        Currency? TotalCurrency { get; }
    }
}
