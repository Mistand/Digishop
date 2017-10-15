using System;
using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class ProductFile : IProductFile
    {
        public DateTime? Date { get; }
        public int Size { get; }
        public string Name { get; }
        public string TrialUrl { get; }

        public ProductFile(File file)
        {
            Date = DateTime.TryParse(file.Date, out DateTime result) ? result : (DateTime?)null;

            Size = Int32.TryParse(file.Size, out int test) ? test : -1;

            Name = file.Name;
            TrialUrl = file.Trial;
        }
    }
}