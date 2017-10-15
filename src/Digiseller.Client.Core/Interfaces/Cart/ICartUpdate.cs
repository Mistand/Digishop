using System.Collections.Generic;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.Cart
{
    /// <summary>
    /// ICArt Update
    /// </summary>
    public interface ICartUpdate
    {
        /// <summary>
        /// Total price of items in the cart
        /// </summary>
        decimal? CartPrice { get; }

        /// <summary>
        /// Currency cart
        /// </summary>
        Currency? Currency { get; }

        /// <summary>
        /// Goods in cart
        /// </summary>
        IEnumerable<ICartProduct> Products { get; }
    }
}