using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.Cart
{
    public interface ICartProduct
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Item Id (for update / remove)
        /// </summary>
        int ItemId { get; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Aviable (no documentation digiseller. Support did not answer why this parameter is needed)
        /// </summary>
        bool Aviable { get; }

        /// <summary>
        /// Price
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Currency
        /// </summary>
        Currency? Currency { get; }

        /// <summary>
        /// Count of this product in cart
        /// </summary>
        int CountItem { get; }

        /// <summary>
        /// CountLock (no documentation digiseller. Support did not answer why this parameter is needed)
        /// </summary>
        int CountLock { get; }
    }
}