using System;
namespace Digiseller.Client.Core.Interfaces.TopTwenty
{
    /// <summary>
    /// Sale
    /// </summary>
    public interface ISale
    {
        /// <summary>
        /// Sale date
        /// </summary>
        DateTime? Date { get; }

        /// <summary>
        /// Product
        /// </summary>
        IProduct Product { get; }
    }
}
