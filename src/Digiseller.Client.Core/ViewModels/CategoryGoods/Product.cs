using System;
using System.Globalization;
using System.Linq;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Interfaces.CategoryGoods;

namespace Digiseller.Client.Core.ViewModels.CategoryGoods
{
    public class Product : IProduct
    {
        public Product(Models.Response.CategoryGoods.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Information = product.Info;
            product.Price = product.Price.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            Price = decimal.Parse(product.Price, NumberStyles.Any,
                CultureInfo.InvariantCulture);
            BasePrice = decimal.Parse(product.BasePrice);
            BaseCurrency = product.BaseCurrency;
            PartnerComission = product.PartnerComiss;

            if (product.Collection.Length > 0)
            {
                var typeString = product.Collection.First().ToString().ToUpper() + product.Collection.Substring(1);

                Collection = Enum.TryParse(typeString, out ProductCollectionType type)
                    ? type
                    : ProductCollectionType.Unknown;
            }

            InStock = product.InStock == 1;
            CountInStock = product.NumInStock ?? -1;
        }

        public int Id { get; }
        public string Name { get; }
        public string Information { get; }
        public decimal Price { get; }
        public decimal BasePrice { get; }
        public string BaseCurrency { get; }
        public int PartnerComission { get; }
        public ProductCollectionType? Collection { get; }
        public bool InStock { get; }
        public int CountInStock { get; }
    }
}