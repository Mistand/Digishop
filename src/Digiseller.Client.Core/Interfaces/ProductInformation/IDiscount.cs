namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Discount
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// Total summa for this discount
        /// </summary>
        decimal Summa { get; }

        /// <summary>
        /// Discount percent
        /// </summary>
        int Percent { get; }
    }
}