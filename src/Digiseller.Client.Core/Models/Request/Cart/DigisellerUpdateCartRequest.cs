namespace Digiseller.Client.Core.Models.Request.Cart
{
    public class DigisellerUpdateCartRequest
    {
        public DigisellerUpdateCartRequest()
        {
            
        }

        public DigisellerUpdateCartRequest(string cartUid, int? itemUpdate, int? productCount, string currencyCode, string languageCode)
        {
            cart_uid = cartUid;
            cart_curr = currencyCode;
            item_id = itemUpdate?.ToString() ?? "";
            product_cnt = productCount?.ToString() ?? "";
            lang = languageCode;
        }

        public string cart_uid { get; set; }
        public string cart_curr { get; set; }
        public string item_id { get; set; }
        public string product_cnt { get; set; }
        public string lang { get; set; }
    }
}
