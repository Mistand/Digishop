using System.Collections.Generic;

namespace Digiseller.Client.Core.Models.Response.Cart
{
    public class DigisellerUpdateCartResponse : DigisellerResponseJsonBase
    {
        public string cart_cnt { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public List<Product> products { get; set; }
    }
}