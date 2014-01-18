using System.Linq;

namespace GridMvc
{
    /// <summary>
    ///     Preprocess items to display
    ///     This objects process initial collection of items in the Grid.Mvc (sorting, filtering, paging etc.)
    /// </summary>
    public interface IGridItemsPreprocessor<T> where T : class
    {
        void Process(IDataQueryable<T> items);
    }
}