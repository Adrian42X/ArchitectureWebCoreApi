using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T>
    {
        T Get();
        Task<T> Add(T entity);
        IEnumerable<T> GetAll(int offset,int limit);
        T FindByName(string name);
        Task<T?> FindById(int id);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
