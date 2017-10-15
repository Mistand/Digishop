using System;
using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductText : IProductText
    {
        public DateTime? Date { get; }
        public int Size { get; }

        public ProductText(Text text)
        {
            Date = DateTime.TryParse(text.Date, out DateTime result) ? result : (DateTime?)null;
            Size = text.Size ?? -1;
        }
    }
}