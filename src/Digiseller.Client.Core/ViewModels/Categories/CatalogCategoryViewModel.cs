using System.Collections.Generic;
using Digiseller.Client.Core.Interfaces.Categories;
using Digiseller.Client.Core.Models.Response.Categories;
using System.Linq;

namespace Digiseller.Client.Core.ViewModels.Categories
{
    public class CatalogCategoryViewModel : ICatalogCategory
    {
        private readonly Category _category;
        public int Id => _category.Id;
        public string Name => _category.Name;
        public IEnumerable<ICatalogCategory> ChildCategories { get; }

        public CatalogCategoryViewModel(Category category)
        {
            _category = category;

            ChildCategories = new List<ICatalogCategory>();

            if(_category.ChildCategories?.Count > 0 )
                ChildCategories = _category.ChildCategories.Select(p => new CatalogCategoryViewModel(p));
        }
    }
}
