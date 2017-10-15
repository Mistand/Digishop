using System;
using System.Collections.Generic;
using System.Linq;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductInformation : IProduct
    {
        public int Id { get; }
        public string Name { get; }
        public string Url { get; }
        public string Information { get; }
        public string AdditionalInformation { get; }
        public DateTime? Release { get; }
        public int AgencyFee { get; }
        public bool? InStock { get; }
        public int? CountInStock { get; }
        public IPriceList Prices { get; }
        public IEnumerable<IProductImage> Images { get; }
        public IEnumerable<IProductVideo> Videos { get; }
        public ProductType Type { get; }
        public IProductText Text { get; }
        public IProductFile File { get; }
        public ICategory Category { get; }
        public IEnumerable<IDiscount> Discounts { get; }
        public IStatistics Statistics { get; }
        public IFullSeller Seller { get; }

        public ProductInformation(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Url = product.Url;
            Information = product.Info;
            AdditionalInformation = product.AddInfo;
            Release = DateTime.TryParse(product.ReleaseDate, out DateTime result) ? result : (DateTime?) null;
            AgencyFee = product.AgencyFee;
            InStock = product.InStock == 1;
            CountInStock = product.NumInStock;

            if(product.Prices != null)
                Prices = new PriceList(product.Prices);

            Images = new List<IProductImage>();
            if (product.PreviewsImg?.PreviewImg?.Count > 0)
                Images = product.PreviewsImg?.PreviewImg?.Select(p => new ProductImage(p));

            Videos = new List<IProductVideo>();
            if (product.PreviewsVideo?.PreviewVideo?.Count > 0)
                Videos = product.PreviewsVideo?.PreviewVideo?.Select(v => new ProductVideo(v));

            if (product.Type.Length >= 2)
            {
                var typeString = char.ToUpperInvariant(product.Type[0]) + product.Type.Substring(1);
                Type = Enum.TryParse(typeString, out ProductType type) ? type : ProductType.Unknown;
            }
            else
            {
                Type = ProductType.Unknown;
            }

            if(product.Text != null)
                Text = new ProductText(product.Text);

            if (product.File != null)
                File = new ProductFile(product.File);

            if(product.Categories?.Category != null)
                Category = new ProductCategory(product.Categories?.Category);

            if (product.Discounts?.Discount?.Count > 0)
                Discounts = Enumerable.Select(product.Discounts?.Discount, p => new ProductDiscount(p));

            if(product.Statistics != null)
                Statistics = new ProductStatistics(product.Statistics);

            if(product.Seller != null)
                Seller = new ProductSeller(product.Seller);
        }
    }
}