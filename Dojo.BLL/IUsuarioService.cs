using Dojo.DAO.Dapper.Model;

namespace Dojo.BLL;

public interface IUsuarioService 
{
    Task<UsuarioDapper?> GetByIdAsync(int id);

    Task<IEnumerable<UsuarioDapper>> getAllAsync();

    Task AddAsync(UsuarioDapper usuario);

    Task UpdateAsync(UsuarioDapper usuario);

    Task DeleteAsync(int id);
}
