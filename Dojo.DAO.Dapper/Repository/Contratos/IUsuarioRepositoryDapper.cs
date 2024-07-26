using Dojo.DAO.Dapper.Model;

namespace Dojo.DAO.Dapper.Repository.Contratos;

public interface IUsuarioRepositoryDapper
{
    Task<IEnumerable<UsuarioDapper>> ListaUsuarios();

    Task<UsuarioDapper?> ObtemUsuarioPorId(int id);

    Task AdicionaUsuario(UsuarioDapper usuario);

    Task AtualizaUsuario(UsuarioDapper usuario);

    Task DeletaUsuario(int id);
}