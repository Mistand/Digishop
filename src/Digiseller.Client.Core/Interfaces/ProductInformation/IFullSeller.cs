namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Information by seller
    /// </summary>
    public interface IFullSeller
    {
        /// <summary>
        /// Id in digiseller system
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Username in digiseller system
        /// </summary>
        string Username { get; }
    }
}