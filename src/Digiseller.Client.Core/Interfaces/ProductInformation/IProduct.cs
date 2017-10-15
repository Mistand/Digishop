using System;
using System.Collections.Generic;
using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Product information
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Trial url
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Information
        /// </summary>
        string Information { get; }

        /// <summary>
        /// Additional information
        /// </summary>
        string AdditionalInformation { get; }

        /// <summary>
        /// Date added
        /// </summary>
        DateTime? Release { get; }

        /// <summary>
        /// Agency fee (percent)
        /// </summary>
        int AgencyFee { get; }

        /// <summary>
        /// In stock
        /// </summary>
        bool? InStock { get; }

        /// <summary>
        /// Count in stock 
        /// 
        /// This option is available after contacting technical support (documentation)
        /// </summary>
        int? CountInStock { get; }

        /// <summary>
        /// Price list
        /// </summary>
        IPriceList Prices { get; }

        /// <summary>
        /// Images
        /// </summary>
        IEnumerable<IProductImage> Images { get; }

        /// <summary>
        /// Videos
        /// </summary>
        IEnumerable<IProductVideo> Videos { get; }

        /// <summary>
        /// Type of product
        /// </summary>
        ProductType Type { get; }

        /// <summary>
        /// If type of product text - text information
        /// </summary>
        IProductText Text { get; }

        /// <summary>
        /// If type of product file - file information
        /// </summary>
        IProductFile File { get; }

        /// <summary>
        /// Category information
        /// </summary>
        ICategory Category { get; }

        /// <summary>
        /// Discounts of this product
        /// </summary>
        IEnumerable<IDiscount> Discounts { get; }

        /// <summary>
        /// Product statistics
        /// </summary>
        IStatistics Statistics { get; }

        /// <summary>
        /// Product seller
        /// </summary>
        IFullSeller Seller { get; }
    }
}
