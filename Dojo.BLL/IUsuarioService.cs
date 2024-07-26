﻿using Dojo.DAO.Dapper.Model;

namespace Dojo.BLL;

public interface IUsuarioService 
{
    Task<UsuarioDapper?> ObtemUsuarioPorId(int id);

    Task<IEnumerable<UsuarioDapper>> ListaUsuarios();

    Task AdicionaUsuario(UsuarioDapper usuario);

    Task AtualizaUsuario(UsuarioDapper usuario);

    Task DeletaUsuario(int id);
}
