using Digiseller.Client.Core.Interfaces.CategoryGoods;

namespace Digiseller.Client.Core.ViewModels.CategoryGoods
{
    public class Category : ICategory
    {
        public Category(Models.Response.CategoryGoods.Category category)
        {
            Id = category.Id;
            Name = category.Name;
            GoodsCount = category.Cnt;

            if (category.ChildCategory != null)
                ChildCategory = new Category(category.ChildCategory);
        }

        public int Id { get; }
        public string Name { get; }
        public int GoodsCount { get; }
        public ICategory ChildCategory { get; }
    }
}
