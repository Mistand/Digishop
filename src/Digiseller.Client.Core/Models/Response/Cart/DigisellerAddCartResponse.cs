using System.Collections.Generic;

namespace Digiseller.Client.Core.Models.Response.Cart
{
    public class DigisellerAddCartResponse : DigisellerResponseJsonTwoBase
    {
        public int cart_cnt { get; set; }
        public string cart_uid { get; set; }
        public string currency { get; set; }
        public List<Product> products { get; set; }
    }
}