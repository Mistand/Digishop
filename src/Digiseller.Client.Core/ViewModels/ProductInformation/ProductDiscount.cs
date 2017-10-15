using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductDiscount : IDiscount
    {
        public decimal Summa { get; }
        public int Percent { get; }

        public ProductDiscount(Discount discount)
        {
            Summa = discount.Summa;
            Percent = discount.Percent;
        }
    }
}