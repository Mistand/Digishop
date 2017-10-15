using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductImage : IProductImage
    {
        public IProductImageParameters Real { get; }
        public IProductImageParameters Preview { get; }

        public ProductImage(PreviewImg image)
        {
            if(image.ImgReal != null)
                Real = new ProductImageParameters(image.ImgReal);

            if(image.ImgSmall != null)
                Preview = new ProductImageParameters(image.ImgSmall);
        }
    }
}