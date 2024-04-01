using Microsoft.AspNetCore.Mvc;
using TodoApi.Backend.Models;
using TodoApi.Backend.Repositories;
using TodoApi.Backend.Services;

namespace TodoApi.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoRepository _autenticacaoRepository;

        public AutenticacaoController(IAutenticacaoRepository autenticacaoRepository)
        {
            _autenticacaoRepository = autenticacaoRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var token = _autenticacaoRepository.GerarTokenJwtAsync(usuario.Login, usuario.Senha).Result;

            if (token == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            return Ok(new { token });
        }
    }
}
