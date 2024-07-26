using Dapper;

namespace Dojo.DAO.Dapper.BaseRepository;

public interface IBaseRepositoryDapper<T> where T : class
{
    Task<IEnumerable<T>> ListaTodos(string selectQuery);

    Task<T?> ObtemPorId(int id, string selectQuery);

    Task Adiciona(DynamicParameters parameters, string inserQuery);

    Task AdicionaEmLote(IEnumerable<T> TListEntity, string insertQuery);

    Task<int> AdicionaERetornaId(DynamicParameters parameters, string insertQuery);

    Task Atualiza(DynamicParameters parameters, string updateQuery);

    Task Deleta(int id, string deleteQuery);
}