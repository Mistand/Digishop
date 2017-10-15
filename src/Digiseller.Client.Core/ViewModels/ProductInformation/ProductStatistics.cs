using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductStatistics : IStatistics
    {
        public int Sales { get; }
        public int Refunds { get; }
        public int GoodReviews { get; }
        public int BadReviews { get; }

        public ProductStatistics(Statistics stats)
        {
            Sales = !string.IsNullOrEmpty(stats.Sales) ? int.Parse(stats.Sales) : 0;
            Refunds = !string.IsNullOrEmpty(stats.Refunds) ? int.Parse(stats.Refunds) : 0;
            GoodReviews = !string.IsNullOrEmpty(stats.GoodReviews) ? int.Parse(stats.GoodReviews) : 0;
            BadReviews = !string.IsNullOrEmpty(stats.BadReviews) ? int.Parse(stats.BadReviews) : 0;
        }
    }
}