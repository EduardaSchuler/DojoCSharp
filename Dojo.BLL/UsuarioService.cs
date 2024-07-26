using Dojo.DAO.Dapper.Model;
using Dojo.DAO.Dapper.Repository;

namespace Dojo.BLL;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepositoryDapper _repository;

    //injeção de dependencia
    public UsuarioService(IUsuarioRepositoryDapper usuarioRepository){
        this._repository = usuarioRepository;
    }

    public async Task AddAsync(UsuarioDapper usuario)
    {
        if(usuario.Id < 0)
            throw new ArgumentException("Id deve ser maior que zero.");
        if(usuario == null)
            throw new ArgumentException("Objeto enviado é nulo.");
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new ArgumentException("Campo nome está em branco.");
        if (string.IsNullOrEmpty(usuario.Cpf))
            throw new ArgumentException("Campo cpf está em branco.");

        await _repository.Add(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        if(id == 0)
            throw new ArgumentException("O id não pode ser zero.");

        await _repository.Delete(id);
    }

    public async Task UpdateAsync(UsuarioDapper usuario)
    {
        if(usuario == null)
            throw new ArgumentException("Objeto enviado é nulo.");
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new ArgumentException("Campo nome está em branco.");
        if (string.IsNullOrEmpty(usuario.Cpf))
            throw new ArgumentException("Campo cpf está em branco.");

        await _repository.Update(usuario);
    }

        public async Task<IEnumerable<UsuarioDapper>> getAllAsync()
    {
        return await _repository.GetAll();
    }

    public async Task<UsuarioDapper?> GetByIdAsync(int id)
    {
        if(id == 0)
            throw new ArgumentException("O id não pode ser zero.");

        return await _repository.GetById(id);
    }
}
