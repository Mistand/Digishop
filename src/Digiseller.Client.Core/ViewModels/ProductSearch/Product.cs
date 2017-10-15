using Digiseller.Client.Core.Helpers;
using Digiseller.Client.Core.Interfaces.ProductSearch;

namespace Digiseller.Client.Core.ViewModels.ProductSearch
{
    public class Product : IProduct
    {
        public Product(Models.Response.ProductSearch.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = DecimalExtension.Parse(product.Price);
            AgencyFee = (int)DecimalExtension.Parse(product.AgencyFee);
            if(product.Snippets != null)
                Snippet = new Snippet(product.Snippets);
        }

        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int AgencyFee { get; }
        public ISnippet Snippet { get; }
    }
}