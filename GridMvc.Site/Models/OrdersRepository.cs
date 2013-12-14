using System.Linq;

namespace GridMvc.Site.Models
{
    public class OrdersRepository : SqlRepository<Order>
    {
        public OrdersRepository()
            : base(new NorthwindDbContext())
        {
        }

        public override IDataQueryable<Order> GetAll()
        {
            IDataQueryable<Order> order = new DataQueryable<Order>(EfDbSet.Include("Customer").OrderByDescending(o => o.OrderDate));
            
            return order;
        }

        public override Order GetById(object id)
        {
            return GetAll().Fetch().FirstOrDefault(o => o.OrderID == (int) id);
        }
    }
}