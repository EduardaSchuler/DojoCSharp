using Dojo.DAO.Context;
using Dojo.DAO.Repository;
using Microsoft.EntityFrameworkCore;

namespace Dojo.Test;

public class UsuarioRepositoryTest{
    private readonly MockDbContext _context;
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioRepositoryTest(){
        Environment.SetEnvironmentVariable("IS_TEST", "True");

        var options = new DbContextOptionsBuilder<DbdojoContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new MockDbContext(options);
        _usuarioRepository = new UsuarioRepository(_context);
    }


    [Fact]

    public async Task DeveRetornarUmUsuario()
    {
        var usuario = new Usuario
        {
            Id = 1,
            Nome = "Usuario Teste",
            Cpf = "1910000000"
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        var usuarioDoBancoDeDados = await _usuarioRepository.GetByIdAsync(usuario.Id);

        Assert.NotNull(usuarioDoBancoDeDados);
        Assert.Equal(usuario.Id, usuarioDoBancoDeDados.Id);
    }
}
