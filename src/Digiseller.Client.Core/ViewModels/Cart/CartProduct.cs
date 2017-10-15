using System;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Helpers;
using Digiseller.Client.Core.Interfaces.Cart;
using Digiseller.Client.Core.Models.Response.Cart;

namespace Digiseller.Client.Core.ViewModels.Cart
{
    public class CartProduct : ICartProduct
    {
        public CartProduct(Product prod)
        {
            Id = prod.id;
            ItemId = prod.item_id;
            Name = prod.name;
            Aviable = prod.available != 0;
            Price = prod.price.Parse();
            Currency = Enum.TryParse(prod.currency, out Currency currency) ? currency : (Currency?)null;
            CountItem = prod.cnt_item;
            CountLock = prod.cnt_lock;
        }

        public int Id { get; }
        public int ItemId { get; }
        public string Name { get; }
        public bool Aviable { get; }
        public decimal Price { get; }
        public Currency? Currency { get; }
        public int CountItem { get; }
        public int CountLock { get; }
    }
}