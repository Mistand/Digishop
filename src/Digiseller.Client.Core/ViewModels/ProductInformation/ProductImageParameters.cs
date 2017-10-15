using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductImageParameters : IProductImageParameters
    {
        public int Height { get; }
        public int Width { get; }
        public string Url { get; }

        public ProductImageParameters(ImgReal image)
        {
            Height = image.Height;
            Width = image.Width;
            Url = image.Url;
        }

        public ProductImageParameters(ImgSmall image)
        {
            Height = image.Height;
            Width = image.Width;
            Url = image.Url;
        }
    }
}