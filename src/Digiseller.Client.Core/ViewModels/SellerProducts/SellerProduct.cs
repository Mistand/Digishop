using System;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Interfaces.SellerProducts;
using Digiseller.Client.Core.Models.Response.SellerProducts;

namespace Digiseller.Client.Core.ViewModels.SellerProducts
{
    public class SellerProduct : IProduct
    {
        public SellerProduct(Row row)
        {
            Id = row.Id;
            Name = row.NameGoods;
            Information = row.InfoGoods;
            AdditionalInformation = row.AddInfo;
            Price = row.Price;
            if (row.Currency.Length > 2)
            {
                var typeString = char.ToUpperInvariant(row.Currency[0]) + row.Currency.Substring(1);
                Currency = Enum.TryParse(typeString, out Currency currency) ? currency : (Currency?)null;
            }
            SellCount = row.CntSell;
            ReturnCount = row.CntReturn;
            GoodResponsesCount = row.CntGoodresponses;
            BadResponsesCount = row.CntBadresponses;
        }

        public int Id { get; }
        public string Name { get; }
        public string Information { get; }
        public string AdditionalInformation { get; }
        public decimal Price { get; }
        public Currency? Currency { get; }
        public int SellCount { get; }
        public int ReturnCount { get; }
        public int GoodResponsesCount { get; }
        public int BadResponsesCount { get; }
    }
}