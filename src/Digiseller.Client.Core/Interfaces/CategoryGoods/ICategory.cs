namespace Digiseller.Client.Core.Interfaces.CategoryGoods
{
    /// <summary>
    /// ICategory
    /// </summary>
    public interface ICategory : ISubcategory
    {
        ICategory ChildCategory { get; }
    }
}
