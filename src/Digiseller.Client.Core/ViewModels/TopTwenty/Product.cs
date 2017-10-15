using Digiseller.Client.Core.Interfaces.TopTwenty;

namespace Digiseller.Client.Core.ViewModels.TopTwenty
{
    public class Product : IProduct
    {
        public Product(Models.Response.TopTwenty.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            if(product.Prices != null)
                Prices = new Prices(product.Prices);
        }

        public int Id { get; }
        public string Name { get; }
        public IPriceList Prices { get; }
    }
}