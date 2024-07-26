using Dojo.BLL;
using Dojo.DAO.Context;
using Dojo.WebApp;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Dojo.Test;

public class UsuarioControllerTest
{
    private readonly UsuarioController _usuarioController;
    private readonly Mock<IUsuarioService> _usuarioService;

    public UsuarioControllerTest(){
        _usuarioService = new Mock<IUsuarioService>();
       // _usuarioController = new UsuarioController(_usuarioService.Object);
    }

    // [Fact]
    // public async Task DeveRetornarUmUsuarioPeloId()
    // {
    //     _usuarioService.Setup(service => service.GetByIdAsync(It.IsAny<int>()))
    //     .ReturnsAsync(
    //         new Usuario 
    //         { 
    //             Id = 1, 
    //             Nome = "Usuario Teste", 
    //             Cpf = "1910000000"
    //         });

    //         var usuarioController = await _usuarioController.GetById(1);

    //         var okResult = Assert.IsType<OkObjectResult>(usuarioController);
    //         var usuarioRetornado = Assert.IsType<Usuario>(okResult.Value);

    //         Assert.Equal(1, usuarioRetornado.Id);
    // }
}
