using System;

namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Text
    /// </summary>
    public interface IProductText
    {
        /// <summary>
        /// Date added / updated
        /// </summary>
        DateTime? Date { get; }

        /// <summary>
        /// Size
        /// </summary>
        int Size { get; }
    }
}