namespace Digiseller.Client.Core.Interfaces.ProductInformation
{
    /// <summary>
    /// Product statistics
    /// </summary>
    public interface IStatistics
    {
        int Sales { get; }
        int Refunds { get; }
        int GoodReviews { get; }
        int BadReviews { get; }
    }
}