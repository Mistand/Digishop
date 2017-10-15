using System.Linq;
using System.Threading.Tasks;
using Digiseller.Client.Core;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Component
{
    public class CategoryTreeViewComponent : ViewComponent
    {
        private readonly DigisellerClient _client;
        public CategoryTreeViewComponent(DigisellerClient client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _client.GetCategoryCatalog();
            return View("_Navigation", result.ToList());
        }
    }
}
