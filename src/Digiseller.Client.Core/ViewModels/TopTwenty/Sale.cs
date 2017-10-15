using System;
using Digiseller.Client.Core.Interfaces.TopTwenty;

namespace Digiseller.Client.Core.ViewModels.TopTwenty
{
    public class Sale : ISale
    {
        public Sale(Models.Response.TopTwenty.Sale sale)
        {
            Date = DateTime.TryParse(sale.Date, out DateTime dtResult) ? dtResult : (DateTime?)null;

            if(sale.Product != null)
                Product = new Product(sale.Product);
        }

        public DateTime? Date { get; }
        public IProduct Product { get; }
    }
}