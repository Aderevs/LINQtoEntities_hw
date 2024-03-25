using BLL.Entity;

namespace BLL.Interfaces.Repository
{
    public interface IWordRepository : IBaseRepository<Word>
    {
        Task<IEnumerable<Word>> SelectIncludeKeyParamsProducts();
    }
}
