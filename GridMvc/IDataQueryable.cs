using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridMvc
{
    /// <summary>
    /// Provides ordering, filtering and paging management.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataQueryable<T>
    {
        /// <summary>
        /// Fetches row count.
        /// </summary>
        int FetchCount();

        /// <summary>
        /// Fetches all rows.
        /// </summary>
        /// <returns>Fetched rows.</returns>
        IEnumerable<T> Fetch();

        /// <summary>
        /// Fetches rows.
        /// </summary>
        /// <param name="skip">Row count to skip from the beginning.</param>
        /// <param name="take">Row count to take.</param>
        /// <returns>Fetched enumeration.</returns>
        IEnumerable<T> Fetch(int skip, int take);

        /// <summary>
        /// Order list.
        /// </summary>
        IList<ColumnOrder<T>> OrderList
        {
            get;
        }
    }
}
