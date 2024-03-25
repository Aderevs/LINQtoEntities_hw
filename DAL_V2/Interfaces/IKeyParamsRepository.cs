using DAL_V2.Entity;

namespace DAL_V2.Interfaces
{
    public interface IKeyParamsRepository : IBaseRepository<KeyParams>
    {
        Task<IEnumerable<KeyParams>> SelectIncludeWords();
    }
}
