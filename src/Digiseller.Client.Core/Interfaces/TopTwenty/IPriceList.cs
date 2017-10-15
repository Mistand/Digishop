namespace Digiseller.Client.Core.Interfaces.TopTwenty
{
    /// <summary>
    /// Prices
    /// </summary>
    public interface IPriceList
    {
        decimal RUR { get; }
        decimal USD { get; }
        decimal EUR { get; }
        decimal UAH { get; }
    }
}