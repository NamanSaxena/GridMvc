using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridMvc.Site.Models
{
    public class DataQueryable<T> : IDataQueryable<T>
    {
        private IEnumerable<T> _enumeration;
        private List<ColumnOrder> _columnOrder;

        public DataQueryable(IEnumerable<T> enumeration)
        {
            if (enumeration == null)
            {
                throw new ArgumentNullException("enumeration");
            }

            _enumeration = enumeration;
            _columnOrder = new List<ColumnOrder>();
        }

        public int Count
        {
            get 
            {
                return _enumeration.Count();
            }
        }

        public IEnumerable<T> Fetch()
        {
            return _enumeration;
        }

        public IEnumerable<T> Fetch(int skip, int take)
        {
            return _enumeration.Skip(skip).Take(take);
        }

        public IList<ColumnOrder> OrderList
        {
            get 
            {
                return _columnOrder; 
            }
        }
    }
}