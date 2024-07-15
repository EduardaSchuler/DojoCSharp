using Dojo.BLL;
using Dojo.DAO.Context;
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
        var usuarios = await _usuarioService.getAllAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Usuario usuario)
    {
        await _usuarioService.AddAsync(usuario);
        return CreatedAtAction(nameof(GetById), new {id = usuario.Id}, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Usuario usuario)
    {
        if(id != usuario.Id)
            return BadRequest("Usuario solicitado nao encontrado");
        
        await _usuarioService.UpdateAsync(usuario);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usuarioService.DeleteAsync(id);
        return NoContent();
    }
}
