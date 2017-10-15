using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digiseller.Client.Core;
using Microsoft.AspNetCore.Mvc;

namespace Digiseller.Engine.Core.Component
{
    public class SellerIdViewComponent : ViewComponent
    {
        private readonly DigisellerClient _client;
        public SellerIdViewComponent(DigisellerClient client)
        {
            _client = client;
        }

        public IViewComponentResult Invoke()
        {
            return Content(_client.SellerId.ToString());
        }
    }
}
