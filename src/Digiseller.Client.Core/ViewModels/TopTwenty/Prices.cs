using Digiseller.Client.Core.Interfaces.TopTwenty;

namespace Digiseller.Client.Core.ViewModels.TopTwenty
{
    public class Prices : IPriceList
    {
        public Prices(Models.Response.TopTwenty.Prices prices)
        {
            RUR = prices.Rur;
            USD = prices.Usd;
            EUR = prices.Eur;
            UAH = prices.Uah;
        }

        public decimal RUR { get; }
        public decimal USD { get; }
        public decimal EUR { get; }
        public decimal UAH { get; }
    }
}
