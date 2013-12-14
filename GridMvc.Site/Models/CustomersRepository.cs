using System.Linq;

namespace GridMvc.Site.Models
{
    public class CustomersRepository : SqlRepository<Customer>
    {
        public CustomersRepository()
            : base(new NorthwindDbContext())
        {
        }

        public override IDataQueryable<Customer> GetAll()
        {
            return new DataQueryable<Customer>(base.GetAll().Fetch().OrderBy(o => o.CompanyName));
        }

        public override Customer GetById(object id)
        {
            return GetAll().Fetch().FirstOrDefault(c => c.CustomerID == (string)id);
        }
    }
}