using Digiseller.Client.Core.Enums;

namespace Digiseller.Client.Core.Models.Request.Cart
{
    public class DigisellerAddToCartRequest
    {
        public DigisellerAddToCartRequest(int productId, int productCount, Currency currency, string email, string languageCode, string cartUid = "")
        {
            product_id = productId;
            product_cnt = productCount;
            typecurr = currency.ToString();
            this.email = email;
            lang = languageCode;
            cart_uid = cartUid;
        }

        public int product_id { get;  }
        public int product_cnt { get;  }
        public string typecurr { get; }
        public string email { get; }
        public string lang { get; }
        public string cart_uid { get; }
    }
}
