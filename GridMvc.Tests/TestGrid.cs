using System.Collections.Generic;
using System.Linq;

namespace GridMvc.Tests
{
    public class TestGrid : Grid<TestModel>
    {
        public TestGrid(IDataQueryable<TestModel> items)
            : base(items)
        {
        }
    }
}