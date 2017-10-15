namespace Digiseller.Client.Core.Models.Response.Cart
{
    public class Product
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public string name { get; set; }
        public int available { get; set; }
        public string price { get; set; }
        public string currency { get; set; }
        public int cnt_item { get; set; }
        public int cnt_lock { get; set; }
    }
}
