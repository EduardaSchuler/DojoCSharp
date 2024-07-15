﻿using Dojo.DAO.Context;

namespace Dojo.BLL;

public interface IUsuarioService 
{
    Task<Usuario> GetByIdAsync(int id);

    Task<IEnumerable<Usuario>> getAllAsync();

    Task AddAsync(Usuario usuario);

    Task UpdateAsync(Usuario usuario);

    Task DeleteAsync(int id);
}
