using Digiseller.Client.Core;
using Digiseller.Engine.Core.Areas.Dashboard.Models.Settings;
using Digiseller.Engine.Core.Attributes;
using Digiseller.Engine.Core.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [ServiceFilter(typeof(AuthAttribute))]
    public class AdminController : Controller
    {
        private readonly IConfProvider _conf;
        private readonly DigisellerClient _client;
        public AdminController(IConfProvider conf, DigisellerClient client)
        {
            _conf = conf;
            _client = client;
        }

        [HttpGet]
        public IActionResult System()
        {
            return View(_conf.Get<MainSettings>());
        }

        [HttpPost]
        public IActionResult System(MainSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return View(settings);
            }
            _conf.Save(settings);
            return RedirectToMainWithMessage(true, "Настройки системы успешно сохранены.");
        }

        [HttpGet]
        public IActionResult Digiseller()
        {
            return View(_conf.Get<DigisellerSettings>());
        }

        [HttpPost]
        public IActionResult Digiseller(DigisellerSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return View(settings);
            }
            _conf.Save(settings);
            _client.SellerId = (int)settings.DigisellerId;
            _client.SellerUid = settings.DigisellerUid;
            return RedirectToMainWithMessage(true, "Настройки соединения с Digiseller успешно сохранены.");
        }

        [HttpGet]
        public IActionResult Admin()
        {
            return View(_conf.Get<AdminSettings>());
        }

        [HttpPost]
        public IActionResult Admin(AdminSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return View(settings);
            }
            _conf.Save(settings);
            return RedirectToMainWithMessage(true, "Настройки администратора успешно сохранены.");
        }

        /// <summary>
        /// Redirect to main page with message in tempdata (success/fail)
        /// </summary>
        /// <param name="success">Message type (succes / fail)</param>
        /// <param name="message">Message to put in tempdata</param>
        /// <returns></returns>
        private IActionResult RedirectToMainWithMessage(bool success, string message)
        {
            var key = success ? "success" : "fail";
            TempData[key] = message;
            return RedirectToAction("Index", "Home", new { controller = "Home", action = "Index", area = "Dashboard" });
        }
    }
}