using System.Linq;
using GridMvc.Pagination;

namespace GridMvc.Site.Models.Grids
{
    public class OrdersGrid : Grid<Order>
    {
        public OrdersGrid(IDataQueryable<Order> items)
            : base(items)
        {
        }
    }
}