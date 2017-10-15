using System.Linq;
using System.Threading.Tasks;
using Digiseller.Client.Core;
using Digiseller.Engine.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Component
{
    public class CartCountItemsViewComponent : ViewComponent
    {
        private readonly DigisellerClient _client;
        public CartCountItemsViewComponent(DigisellerClient client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartUid = HttpContext.Session.GetCartId();

            if (cartUid == string.Empty)
            {
                return Content("0");
            }

            var result = await _client.UpdateCart(cartUid);
            return Content(result.Products.Select(a => a.CountItem).Sum().ToString());
        }
    }
}
