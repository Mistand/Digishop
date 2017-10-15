using System;
using System.Collections.Generic;
using System.Linq;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Interfaces.Cart;
using Digiseller.Client.Core.Models.Response.Cart;

namespace Digiseller.Client.Core.ViewModels.Cart
{
    public class AddCart : ICartAdd
    {
        public AddCart(DigisellerAddCartResponse res)
        {
            ProductsCount = res.cart_cnt;
            CartUid = res.cart_uid;
            Currency = Enum.TryParse(res.currency, out Currency result) ? result : (Currency?)null;
            Products = new List<ICartProduct>();
            if (res.products?.Count > 0)
                Products = res.products?.Select(p => new CartProduct(p));

        }

        public int ProductsCount { get; }
        public string CartUid { get; }
        public Currency? Currency { get; }
        public IEnumerable<ICartProduct> Products { get; }
    }
}
