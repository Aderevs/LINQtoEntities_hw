using BLL.Entity;

namespace BLL.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByIdIncludWord(string name);
    }
}
