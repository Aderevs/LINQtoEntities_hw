using DAL_V2.Entity;

namespace DAL_V2.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByIdIncludWord(string name);
        Task<IEnumerable<Product>> SelectIncludeCategory();
    }
}
