namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Image parameters
    /// </summary>
    public interface IProductImageParameters
    {
        int Height { get; }
        int Width { get; }
        string Url { get; }
    }
}