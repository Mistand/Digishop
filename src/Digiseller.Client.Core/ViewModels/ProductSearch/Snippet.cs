using Digiseller.Client.Core.Interfaces.ProductSearch;
using Digiseller.Client.Core.Models.Response.ProductSearch;

namespace Digiseller.Client.Core.ViewModels.ProductSearch
{
    public class Snippet : ISnippet
    {
        public Snippet(Snippets snippet)
        {
            Name = snippet.Name;
            Information = snippet.Info;
        }

        public string Name { get; }
        public string Information { get; }
    }
}