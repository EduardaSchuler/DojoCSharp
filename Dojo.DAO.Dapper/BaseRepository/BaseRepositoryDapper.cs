using System.Data;
using Dapper;

namespace Dojo.DAO.Dapper.BaseRepository;

public class BaseRepositoryDapper<T> : IBaseRepositoryDapper<T> where T : class
{

    private readonly IDbConnection _connection;

    public BaseRepositoryDapper(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<T>> GetAll(string selectQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        return await dbConnection.QueryAsync<T>(selectQuery);
    }

    public async Task<T?> GetById(int id, string selectQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        return await dbConnection.QueryFirstOrDefaultAsync<T>(selectQuery, new { Id = id });
    }

    public async Task Add(DynamicParameters parameters, string inserQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        await dbConnection.ExecuteAsync(inserQuery, parameters);
    }

    public async Task Update(T entity, string updateQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        await dbConnection.ExecuteAsync(updateQuery, entity);
    }

        public async Task Delete(int id, string deleteQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        await dbConnection.ExecuteAsync(deleteQuery, new { id = id });
    }
}