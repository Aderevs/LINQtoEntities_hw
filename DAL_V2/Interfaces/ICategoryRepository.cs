using DAL_V2.Entity;

namespace DAL_V2.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> SelectIncludeProducts();
    }
}
