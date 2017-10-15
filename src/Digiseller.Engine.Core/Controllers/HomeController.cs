using System;
using System.Net;
using Digiseller.Client.Core.Enums;
using Digiseller.Engine.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Controllers
{
    public class HomeController : Controller
    {
        [Route("/error/{id}")]
        public IActionResult Error(int id)
        {
            switch (id)
            {
                case 404:
                    return View("~/Views/Home/Error404.cshtml");
                case 500:
                    return View("~/Views/Home/Error500.cshtml");
                default:
                    var code = (HttpStatusCode)id;
                    return View(code);
            }
        }

        [Route("[controller]/[action]/{selectedCurrency}")]
        public IActionResult Change(string selectedCurrency)
        {
            try
            {
                if (!Enum.TryParse(selectedCurrency, out Currency currency)) return BadRequest();

                HttpContext.Session.SetCurrency(currency);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
