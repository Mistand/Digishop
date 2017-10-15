using System;
using System.Threading.Tasks;
using Digiseller.Client.Core;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Interfaces.ProductReviews;
using Digiseller.Engine.Core.Areas.Dashboard.Models.Settings;
using Digiseller.Engine.Core.Helpers;
using Digiseller.Engine.Core.Providers;
using Digiseller.Engine.Core.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Controllers
{
    public class ProductController : Controller
    {
        private readonly DigisellerClient _client;

        private readonly IConfProvider _conf;
        public ProductController(DigisellerClient client, IConfProvider conf)
        {
            _client = client;
            _conf = conf;
        }

        public async Task<IActionResult> Index(int category = 0, int page = 1)
        {
            var result = await _client.GetCategoryGoods(categoryId: category, currency: HttpContext.Session.GetCurrency(), pageNumber: page, countGoods: (int)_conf.Get<MainSettings>().CountOfGoodsPerPage);
            return View(result);
        }

        public async Task<IActionResult> Search(string search, int page = 1)
        {
            var result = await _client.GetGoodsBySearchString(searchString: search, currency: HttpContext.Session.GetCurrency(), pageNumber: page, rowsCount: (int)_conf.Get<MainSettings>().CountOfGoodsPerPage);
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _client.GetFullProductInformation(id);

            Task<IProductReviews>[] tasks =
            {
                _client.GetProductReviews(id, ReviewType.Good, rowsCount: 10),
                _client.GetProductReviews(id, ReviewType.Bad, rowsCount: 10),
                _client.GetProductReviews(id, rowsCount: 10)
            };

            var reviews = await Task.WhenAll(tasks);
            return View(new ProductDetailViewModel { GoodReviews = reviews[0], BadReviews = reviews[1], AllReviews = reviews[2], Product = product });
        }
    }
}