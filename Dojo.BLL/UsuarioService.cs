using Dojo.DAO.Dapper.Model;
using Dojo.DAO.Dapper.Repository.Contratos;

namespace Dojo.BLL;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepositoryDapper _repository;

    //injeção de dependencia
    public UsuarioService(IUsuarioRepositoryDapper usuarioRepository){
        this._repository = usuarioRepository;
    }

    public async Task AdicionaUsuario(UsuarioDapper usuario)
    {
        if(usuario.Id < 0)
            throw new ArgumentException("Id deve ser maior que zero.");
        if(usuario == null)
            throw new ArgumentException("Objeto enviado é nulo.");
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new ArgumentException("Campo nome está em branco.");
        if (string.IsNullOrEmpty(usuario.Cpf))
            throw new ArgumentException("Campo cpf está em branco.");

        await _repository.AdicionaUsuario(usuario);
    }

    public async Task DeletaUsuario(int id)
    {
        if(id == 0)
            throw new ArgumentException("O id não pode ser zero.");

        await _repository.DeletaUsuario(id);
    }

    public async Task AtualizaUsuario(UsuarioDapper usuario)
    {
        if(usuario == null)
            throw new ArgumentException("Objeto enviado é nulo.");
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new ArgumentException("Campo nome está em branco.");
        if (string.IsNullOrEmpty(usuario.Cpf))
            throw new ArgumentException("Campo cpf está em branco.");

        await _repository.AtualizaUsuario(usuario);
    }

        public async Task<IEnumerable<UsuarioDapper>> ListaUsuarios()
    {
        return await _repository.ListaUsuarios();
    }

    public async Task<UsuarioDapper?> ObtemUsuarioPorId(int id)
    {
        if(id == 0)
            throw new ArgumentException("O id não pode ser zero.");

        return await _repository.ObtemUsuarioPorId(id);
    }
}
