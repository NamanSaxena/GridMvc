using System;
using System.Linq;
using System.Linq.Expressions;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Object applies ThenBy and ThenByDescending order for items collection
    /// </summary>
    internal class ThenByColumnOrderer<T, TKey> : IColumnOrderer<T>
    {
        private readonly Expression<Func<T, TKey>> _expression;
        private readonly GridSortDirection _initialDirection;

        public ThenByColumnOrderer(Expression<Func<T, TKey>> expression, GridSortDirection initialDirection)
        {
            _expression = expression;
            _initialDirection = initialDirection;
        }

        #region IColumnOrderer<T> Members

        public void ApplyOrder(IDataQueryable<T> items)
        {
            switch (_initialDirection)
            {
                case GridSortDirection.Ascending:
                    items.OrderList.Add(ColumnOrder<T>.NewColumnOrder(_expression));
                    break;
                case GridSortDirection.Descending:
                    items.OrderList.Add(ColumnOrder<T>.NewColumnOrder(_expression, OrderDirection.Descending));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ApplyOrder(IDataQueryable<T> items, GridSortDirection direction)
        {
            ApplyOrder(items);
        }

        #endregion
    }
}