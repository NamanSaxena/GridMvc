using System.Linq;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Custom user column orderer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IColumnOrderer<T>
    {
        void ApplyOrder(IDataQueryable<T> items);
        void ApplyOrder(IDataQueryable<T> items, GridSortDirection direction);
    }
}