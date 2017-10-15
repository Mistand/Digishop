using Digiseller.Client.Core;
using Digiseller.Engine.Core.Areas.Dashboard.Models;
using Digiseller.Engine.Core.Areas.Dashboard.Models.Settings;
using Digiseller.Engine.Core.Attributes;
using Digiseller.Engine.Core.Helpers;
using Digiseller.Engine.Core.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [ServiceFilter(typeof(AuthAttribute))]
    public class HomeController : Controller
    {
        private readonly IConfProvider _conf;
        private readonly DigisellerClient _client;
        public HomeController(IConfProvider conf, DigisellerClient client)
        {
            _conf = conf;
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Install()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!HttpContext.Session.IsAuthorized()) return View();

            TempData["fail"] = "Вы уже авторизованы";
            return RedirectToAction("Index", "Home", new { Area = "Dashboard" });
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var adminSettings = _conf.Get<AdminSettings>();

            if (model.Password == adminSettings.Password && model.Login == adminSettings.Login)
            {
                HttpContext.Session.Authorize();
                return RedirectToAction("Index", "Home", new {Area = "Dashboard"});
            }

            TempData["fail"] = "Ошибка авторизации";
            return View(model);
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Deauthorize();
            return RedirectToAction("Login", "Home", new {Area = "Dashboard"});
        }

        [HttpPost]
        public IActionResult Install(Install mdl)
        {
            var shop = _conf.Get<MainSettings>();

            if (!ModelState.IsValid)
            {
                return View(mdl);
            }

            
            var admin = _conf.Get<AdminSettings>();
            var digiseller = _conf.Get<DigisellerSettings>();

            digiseller.DigisellerId = mdl.DigisellerId;
            digiseller.DigisellerUid = mdl.DigisellerUid;
            _conf.Save(digiseller);
            
            admin.Login = mdl.AdminLogin;
            admin.Password = mdl.Password;
            _conf.Save(admin);

            shop.Installed = true;
            _conf.Save(shop);

            _client.SellerId = (int)digiseller.DigisellerId;
            _client.SellerUid = digiseller.DigisellerUid;

            HttpContext.Session.Authorize();

            TempData["success"] = "Установка Digishop произведена успешно!";
            return RedirectToAction("Index", "Home", new { controller = "Home", action = "Index", area = "Dashboard" });
        }
    }
}