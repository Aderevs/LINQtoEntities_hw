using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepositoryDAL : IBaseRepository<Product>
    {
        Task<Product> GetByName(string name);
    }
}
