using System.Collections.Generic;
using System.Linq;

namespace GridMvc.Pagination
{
    /// <summary>
    ///     Cut's the current page from items collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagerGridItemsProcessor<T> : IGridItemsProcessor<T> where T : class
    {
        private readonly IGridPager _pager;

        public PagerGridItemsProcessor(IGridPager pager)
        {
            _pager = pager;
        }

        #region IGridItemsProcessor<T> Members

        public IEnumerable<T> Process(IDataQueryable<T> items)
        {
            _pager.Initialize(items); //init pager

            int currentPage = _pager.CurrentPage;

            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            int skip = (currentPage - 1) * _pager.PageSize;
            return items.Fetch(skip,_pager.PageSize);
        }

        #endregion
    }
}