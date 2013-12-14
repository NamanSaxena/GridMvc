using System.Linq;

namespace GridMvc.Site.Models
{
    public interface IRepository<T>
    {
        IDataQueryable<T> GetAll();
        T GetById(object id);
    }
}