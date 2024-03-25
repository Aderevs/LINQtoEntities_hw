using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V2.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<bool> Create(T entity);
        public Task<bool> Delete(T entity);
        public Task<T> Update(T entity);
        public Task<IEnumerable<T>> Select();
        public Task<T> GetById(Guid id);

    }
}
