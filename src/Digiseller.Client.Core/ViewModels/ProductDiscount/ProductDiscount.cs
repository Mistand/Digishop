using System;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Helpers;
using Digiseller.Client.Core.Interfaces.ProductDiscount;
using Digiseller.Client.Core.Models.Response.ProductDiscount;

namespace Digiseller.Client.Core.ViewModels.ProductDiscount
{
    public class ProductDiscount : IProductDiscount
    {
        public ProductDiscount(DigisellerProductDiscountResponseXml responseXml)
        {
            ProductPrice = responseXml.Product?.Price?.Parse() ?? 0.0M;
            if (responseXml.Product?.Currency.Length > 2)
            {
                var typeString = char.ToUpperInvariant(responseXml.Product.Currency[0]) + responseXml.Product?.Currency.Substring(1);
                ProductCurrency = Enum.TryParse(typeString, out Currency currency) ? currency : (Currency?)null;
            }
            DiscountPercent = responseXml?.Discount?.Percent ?? -1;
            Total = responseXml.Discount?.Total?.Parse() ?? 0.0M;
            if (responseXml.Discount?.Currency.Length > 2)
            {
                var typeString = char.ToUpperInvariant(responseXml.Discount.Currency[0]) + responseXml.Discount?.Currency.Substring(1);
                TotalCurrency = Enum.TryParse(typeString, out Currency currency) ? currency : (Currency?)null;
            }
        }

        public decimal ProductPrice { get; }
        public Currency? ProductCurrency { get; }
        public int DiscountPercent { get; }
        public decimal Total { get; }
        public Currency? TotalCurrency { get; }
    }
}
