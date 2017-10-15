using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductCategory : ICategory
    {
        public int Id { get; }
        public string Name { get; }
        public int GoodsCount { get; }
        public ICategory ChildCategory { get; }

        public ProductCategory(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            GoodsCount = category.GoodsCount;

            if(category.ChildCategory != null)
                ChildCategory = new ProductCategory(category.ChildCategory);
        }
    }
}