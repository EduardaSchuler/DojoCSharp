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

    public async Task<IEnumerable<T>> ListaTodos(string selectQuery)
    {
        return await _connection.QueryAsync<T>(selectQuery);
    }

    public async Task<T?> ObtemPorId(int id, string selectQuery)
    {
        return await _connection.QueryFirstOrDefaultAsync<T>(selectQuery, new { Id = id });
    }

    public async Task Adiciona(DynamicParameters parameters, string inserQuery)
    {
        await _connection.ExecuteAsync(inserQuery, parameters);
    }

        public async Task AdicionaEmLote(IEnumerable<T> TListEntity, string insertQuery)
    {
        await _connection.ExecuteAsync(insertQuery, TListEntity);
    }

    public async Task<int> AdicionaERetornaId(DynamicParameters parameters, string insertQuery)
    {
        return await _connection.ExecuteScalarAsync<int>(insertQuery, parameters);
    }

    public async Task Atualiza(DynamicParameters parameters, string updateQuery)
    {
        await _connection.ExecuteAsync(updateQuery, parameters);
    }

        public async Task Deleta(int id, string deleteQuery)
    {
        await _connection.ExecuteAsync(deleteQuery, new { id = id });
    }

}