using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Backend.Models;
using TodoApi.Backend.Repositories;

namespace TodoApi.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            var usuarios = await _usuarioRepository.ObterTodosUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Usuario usuario)
        {
            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
            return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(Guid id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            await _usuarioRepository.AtualizarUsuarioAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverUsuario(Guid id)
        {
            await _usuarioRepository.RemoverUsuarioAsync(id);
            return NoContent();
        }
    }
}
