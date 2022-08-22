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

        T Add(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindByName(string name);
        IEnumerable<T> FindById(int id);
        T Update(T entity);
        bool Delete(int id);
    }
}
