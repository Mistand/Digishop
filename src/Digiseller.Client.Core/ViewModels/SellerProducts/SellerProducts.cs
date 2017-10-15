using System;
using System.Collections.Generic;
using System.Linq;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Interfaces.SellerProducts;
using Digiseller.Client.Core.Models.Response.SellerProducts;

namespace Digiseller.Client.Core.ViewModels.SellerProducts
{
    public class SellerProducts : ISellerProducts
    {
        public SellerProducts(DigisellerSellerProductsResponseXml responseXml)
        {
            SellerId = responseXml.IdSeller;
            SellerName = responseXml.NameSeller;
            CountOfGoods = responseXml.CntGoods;
            PageCount = responseXml.Pages;
            PageNumber = responseXml.Page;
            RowsCount = responseXml.Rows?.Row?.Count ?? -1;
            
            Products = new List<IProduct>();
            if (responseXml.Rows?.Row?.Count > 0)
                Products = responseXml.Rows?.Row?.Select(p => new SellerProduct(p));

            if (responseXml.OrderDir.Length > 2)
            {
                var typeString = char.ToUpperInvariant(responseXml.OrderDir[0]) + responseXml.OrderDir.Substring(1);
                OrderDir = Enum.TryParse(typeString, out OrderDir orderDir) ? orderDir : (OrderDir?)null;
            }

            if (responseXml.OrderCol.Length > 2)
            {
                var typeString = char.ToUpperInvariant(responseXml.OrderCol[0]) + responseXml.OrderCol.Substring(1);
                Column = Enum.TryParse(typeString, out OrderColumn orderCol) ? orderCol : (OrderColumn?)null;
            }
        }

        public int SellerId { get; }
        public string SellerName { get; }
        public int CountOfGoods { get; }
        public IEnumerable<IProduct> Products { get; }
        public int PageCount { get; }
        public int PageNumber { get; }
        public int RowsCount { get; }
        public OrderColumn? Column { get; }
        public OrderDir? OrderDir { get; }
    }
}
