using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridMvc.Tests
{
    class TestDataQueryable<T> : IDataQueryable<T>
    {
        private IList<T> list;

        public TestDataQueryable(IEnumerable<T> enumeration)
        {
            if (enumeration == null)
            {
                throw new ArgumentNullException("enumeration");
            }

            list = enumeration.ToList();
            OrderList = new List<ColumnOrder>();
        }

        public int Count
        {
            get { return list.Count; }
        }

        public IEnumerable<T> Fetch()
        {
            return list;
        }

        public IEnumerable<T> Fetch(int skip, int take)
        {
            return list.Skip(skip).Take(take);
        }

        public IList<ColumnOrder> OrderList
        {
            get;
            private set;
        }
    }
}
