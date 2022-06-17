using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitOfWorkDP.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
