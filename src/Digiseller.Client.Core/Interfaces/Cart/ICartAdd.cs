using System.Collections.Generic;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.Cart
{
    /// <summary>
    /// ICart Added products
    /// </summary>
    public interface ICartAdd
    {
        /// <summary>
        /// Total number of items in the cart
        /// </summary>
        int ProductsCount { get; }

        /// <summary>
        /// Cart UID
        /// </summary>
        string CartUid { get; }

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
