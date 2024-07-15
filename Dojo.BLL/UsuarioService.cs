using System.Data.Common;
using System.Diagnostics;
using System.Net.Http.Headers;
using Dojo.DAO.BaseRepository;
using Dojo.DAO.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dojo.BLL;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    //injeção de dependencia
    public UsuarioService(IUsuarioRepository usuarioRepository){
        this._repository = usuarioRepository;
    }

    public async Task AddAsync(Usuario usuario)
    {
        if(usuario.Id > 0)
            throw new ArgumentException("Id deve ser maior que zero.");
        if(usuario == null)
            throw new ArgumentException("Objeto enviado é nulo.");
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new ArgumentException("Campo nome está em branco.");
        if (string.IsNullOrEmpty(usuario.Cpf))
            throw new ArgumentException("Campo cpf está em branco.");

        await _repository.AddAsync(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        if(id == 0)
            throw new ArgumentException("O id não pode ser zero.");

        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        if(usuario == null)
            throw new ArgumentException("Objeto enviado é nulo.");
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new ArgumentException("Campo nome está em branco.");
        if (string.IsNullOrEmpty(usuario.Cpf))
            throw new ArgumentException("Campo cpf está em branco.");

        await _repository.UpdateAsync(usuario);

        throw new ArgumentException("Usuario informado não encontrado");
    }

        public async Task<IEnumerable<Usuario>> getAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        if(id == 0)
            throw new ArgumentException("O id não pode ser zero.");

        return await _repository.GetByIdAsync(id);
    }
}
