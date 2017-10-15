namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Image
    /// </summary>
    public interface IProductImage
    {
        /// <summary>
        /// Real image
        /// </summary>
        IProductImageParameters Real { get; }

        /// <summary>
        /// Preview image
        /// </summary>
        IProductImageParameters Preview { get; }
    }
}