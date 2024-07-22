using Dapper;

namespace Dojo.DAO.Dapper.BaseRepository;

public interface IBaseRepositoryDapper<T> where T : class
{
    Task<IEnumerable<T>> GetAll(string selectQuery);

    Task<T?> GetById(int id, string selectQuery);

    Task Add (DynamicParameters parameters, string inserQuery);

    Task Update(T entity, string updateQuery);

    Task Delete(int id, string deleteQuery);
}