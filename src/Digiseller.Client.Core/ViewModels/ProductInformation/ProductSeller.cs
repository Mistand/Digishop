using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductSeller : IFullSeller
    {
        public int Id { get; }
        public string Username { get; }

        public ProductSeller(Seller seller)
        {
            Id = seller.Id;
            Username = seller.Name;
        }
    }
}