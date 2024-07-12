
namespace Dojo.DAO.BaseRepository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> getAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}