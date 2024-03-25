using BLL.Entity;

namespace BLL.Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> SelectIncludeProducts();
    }
}
