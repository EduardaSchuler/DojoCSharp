using System.Diagnostics.CodeAnalysis;
using Dojo.BLL;
using Dojo.DAO.BaseRepository;
using Moq;

namespace Dojo.Test;

public class UsuarioServiceTest
{
    private readonly UsuarioService _usuarioService;
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;

    public UsuarioServiceTest()
    {
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object); 
    }

    [Fact]
    public async Task DeveRetornarUmUsuarioPeloId(){
        _usuarioRepositoryMock.Setup(repo=> repo.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(new DAO.Context.Usuario {Id = 1, Nome="Usuario Teste", Cpf= "1910000000"});

        var usuario = await _usuarioService.GetByIdAsync(1);

        Assert.NotNull(usuario);
        Assert.Equal(1, usuario.Id);
    }

    [Fact]
    public async Task DeveFalharAoInserirUmUsuarioComIdZero(){
        _usuarioRepositoryMock.Setup(repo=> repo.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(new DAO.Context.Usuario {Id = 0, Nome="Usuario Teste", Cpf= "1910000000"});

        var usuario = await _usuarioService.GetByIdAsync(0);

        Assert.NotNull(usuario);
        Assert.Equal(1, usuario.Id);
    }
}
