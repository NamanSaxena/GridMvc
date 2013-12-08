using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridMvc
{
    public interface IGridItemsProcessor<T> where T : class
    {
        IEnumerable<T> Process(IDataQueryable<T> items);
    }
}
