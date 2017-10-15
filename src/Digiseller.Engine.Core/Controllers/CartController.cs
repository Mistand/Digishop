using System.Threading.Tasks;
using Digiseller.Client.Core;
using Digiseller.Engine.Core.Component;
using Digiseller.Engine.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Controllers
{
    public class CartController : Controller
    {
        private readonly DigisellerClient _client;
        public CartController(DigisellerClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> ViewCart()
        {
            var cartUid = HttpContext.Session.GetCartId();
            return string.IsNullOrEmpty(cartUid) ? View(null) : View(await _client.UpdateCart(cartUid, currency: HttpContext.Session.GetCurrency()));
        }

        public async Task<IActionResult> AddToCart(int productId)
        {
            try
            {
                var result = await _client.AddToCart(productId, 1, email: string.Empty, cartUid: HttpContext.Session.GetCartId(),
                    currency: HttpContext.Session.GetCurrency());
                HttpContext.Session.SetCartId(result.CartUid);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult Clear()
        {
            HttpContext.Session.SetCartId(string.Empty);
            return RedirectToAction(nameof(ViewCart));
        }

        /// <summary>
        /// Обновить количество в корзине
        /// </summary>
        /// <param name="productPositionId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Route("[controller]/[action]/{productPositionId}/{count}")]
        public async Task<IActionResult> UpdateCart(int productPositionId, int count)
        {
            try
            {
                await _client.UpdateCart(HttpContext.Session.GetCartId(), productPositionId, count, currency: HttpContext.Session.GetCurrency());
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Получить корзину
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetCart()
        {
            var cartUid = HttpContext.Session.GetCartId();
            return !string.IsNullOrEmpty(cartUid) ? PartialView("_Cart", await _client.UpdateCart(cartUid, currency: HttpContext.Session.GetCurrency())) : PartialView("_Cart", null);
        }
    }
}