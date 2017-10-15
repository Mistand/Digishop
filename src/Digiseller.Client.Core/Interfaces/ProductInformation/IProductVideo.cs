using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Videos
    /// </summary>
    public interface IProductVideo
    {
        VideoType Type { get; }
        string Id { get; }

        /// <summary>
        /// Image preview video
        /// </summary>
        string UrlImagePreview { get; }
    }
}