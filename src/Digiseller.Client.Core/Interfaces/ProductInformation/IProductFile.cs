namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// File
    /// </summary>
    public interface IProductFile : IProductText
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Trial url for preview
        /// </summary>
        string TrialUrl { get; }
    }
}