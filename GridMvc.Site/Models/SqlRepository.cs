using System.Data.Entity;
using System.Linq;

namespace GridMvc.Site.Models
{
    public abstract class SqlRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> EfDbSet;

        protected SqlRepository(DbContext context)
        {
            EfDbSet = context.Set<T>();
        }

        #region IRepository<T> Members

        public virtual IDataQueryable<T> GetAll()
        {
            return new DataQueryable<T>(EfDbSet);
        }

        public abstract T GetById(object id);

        #endregion
    }
}