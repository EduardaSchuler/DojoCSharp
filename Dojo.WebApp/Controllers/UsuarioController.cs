using Dojo.BLL;
using Dojo.DAO.Dapper.Model;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.WebApp;

[ApiController]
[Route("controller")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.ListaUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioService.ObtemUsuarioPorId(id);

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Post(UsuarioDapper usuario)
    {
        await _usuarioService.AdicionaUsuario(usuario);
        return CreatedAtAction(nameof(GetById), new {id = usuario.Id}, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UsuarioDapper usuario)
    {
        if(id != usuario.Id)
            return BadRequest("Usuario solicitado nao encontrado");
        
        await _usuarioService.AtualizaUsuario(usuario);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usuarioService.DeletaUsuario(id);
        return NoContent();
    }
}
