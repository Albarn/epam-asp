using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Find(params Object[] keyValues);
        void Update(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
