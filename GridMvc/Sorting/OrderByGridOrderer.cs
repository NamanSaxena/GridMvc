using System;
using System.Linq;
using System.Linq.Expressions;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Object applies order (OrderBy, OrderByDescending) for items collection
    /// </summary>
    internal class OrderByGridOrderer<T, TKey> : IColumnOrderer<T>
    {
        private readonly Expression<Func<T, TKey>> _expression;

        public OrderByGridOrderer(Expression<Func<T, TKey>> expression)
        {
            _expression = expression;
        }

        #region IColumnOrderer<T> Members

        public void ApplyOrder(IDataQueryable<T> items)
        {
            ApplyOrder(items, GridSortDirection.Ascending);
        }

        public void ApplyOrder(IDataQueryable<T> items, GridSortDirection direction)
        {
            switch (direction)
            {
                case GridSortDirection.Ascending:
                    items.OrderList.Clear();
                    items.OrderList.Add(ColumnOrder<T>.NewColumnOrder(_expression));
                    break;
                case GridSortDirection.Descending:
                    items.OrderList.Clear();
                    items.OrderList.Add(ColumnOrder<T>.NewColumnOrder(_expression, OrderDirection.Descending));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        #endregion
    }
}