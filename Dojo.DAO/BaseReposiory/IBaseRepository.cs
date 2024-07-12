namespace Dojo.DAO.BaseRepository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);

    Task<IEnumerable<TEntity>> getAllAsync();

    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(int id);
}