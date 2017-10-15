using Digiseller.Client.Core.Interfaces.CategoryGoods;

namespace Digiseller.Client.Core.ViewModels.CategoryGoods
{
    public class Subcategory : ISubcategory
    {
        public Subcategory(Models.Response.CategoryGoods.Subcategory category)
        {
            Id = category.Id;
            Name = category.Name;
            GoodsCount = category.Cnt;
        }

        public int Id { get; }
        public string Name { get; }
        public int GoodsCount { get; }
    }
}