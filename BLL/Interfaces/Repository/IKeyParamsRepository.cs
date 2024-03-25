using BLL.Entity;

namespace BLL.Interfaces.Repository
{
    public interface IKeyParamsRepository : IBaseRepository<KeyParams>
    {
        Task<IEnumerable<KeyParams>> SelectIncludeWords();
    }
}
