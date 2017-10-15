using System;
using System.Collections.Generic;
using System.Linq;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Helpers;
using Digiseller.Client.Core.Interfaces.Cart;
using Digiseller.Client.Core.Models.Response.Cart;

namespace Digiseller.Client.Core.ViewModels.Cart
{
    public class CartUpdate : ICartUpdate
    {
        public CartUpdate(DigisellerUpdateCartResponse res)
        {
            CartPrice = DecimalExtension.Parse(res.amount);
            Currency = Enum.TryParse(res.currency, out Currency result) ? result : (Currency?)null;
            Products = new List<ICartProduct>();
            if (res.products?.Count > 0)
                Products = res.products?.Select(p => new CartProduct(p));

        }

        public decimal? CartPrice { get; }
        public Currency? Currency { get; }
        public IEnumerable<ICartProduct> Products { get; }
    }
}