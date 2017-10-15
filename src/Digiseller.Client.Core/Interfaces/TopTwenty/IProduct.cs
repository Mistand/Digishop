namespace Digiseller.Client.Core.Interfaces.TopTwenty
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
        /// Prices
        /// </summary>
        IPriceList Prices { get; }
    }
}