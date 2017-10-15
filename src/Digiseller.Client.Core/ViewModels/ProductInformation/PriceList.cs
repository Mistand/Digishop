using Digiseller.Client.Core.Interfaces.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductInformation;

namespace Digiseller.Client.Core.ViewModels.ProductInformation
{
    public class PriceList : IPriceList
    {
        public string Wmz { get; }
        public string Wmr { get; }
        public string Wme { get; }
        public string Wmu { get; }
        public string Wmx { get; }
        public string Rcc { get; }
        public string Zcc { get; }
        public string Ecc { get; }
        public string Mts { get; }
        public string Bln { get; }
        public string Mgf { get; }
        public string Tl2 { get; }
        public string Pcr { get; }
        public string Mrr { get; }
        public string Qsr { get; }
        public string Atm { get; }
        public string Rub { get; }
        public string Bnk { get; }

        public PriceList(Prices prices)
        {
            Wmz = prices.Wmz;
            Wmr = prices.Wmr;
            Wme = prices.Wme;
            Wmu = prices.Wmu;
            Wmx = prices.Wmx;
            Rcc = prices.Rcc;
            Zcc = prices.Zcc;
            Ecc = prices.Ecc;
            Mts = prices.Mts;
            Bln = prices.Bln;
            Mgf = prices.Mgf;
            Tl2 = prices.Tl2;
            Pcr = prices.Pcr;
            Mrr = prices.Mrr;
            Qsr = prices.Qsr;
            Atm = prices.Atm;
            Rub = prices.Rub;
            Bnk = prices.Bnk;
        }
    }
}
