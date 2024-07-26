using Dojo.DAO.Dapper.BaseRepository;
using Dojo.DAO.Dapper.Model;

namespace Dojo.DAO.Dapper.Repository;

public interface IUsuarioRepositoryDapper
{
    Task<IEnumerable<UsuarioDapper>> GetAll();

    Task<UsuarioDapper?> GetById(int id);

    Task Add(UsuarioDapper usuario);

    Task Update(UsuarioDapper usuario);

    Task Delete(int id);
}