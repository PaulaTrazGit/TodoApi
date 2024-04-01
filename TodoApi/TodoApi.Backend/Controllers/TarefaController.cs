using Microsoft.AspNetCore.Mvc;
using TodoApi.Backend.Models;
using TodoApi.Backend.Repositories;



namespace TodoApi.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasTarefas()
        {
            var tarefas = await _tarefaRepository.ObterTodasTarefasAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterTarefaPorId(Guid id)
        {
            var tarefa = await _tarefaRepository.ObterTarefaPorIdAsync(id);
            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTarefa([FromBody] Tarefa tarefa)
        {
            await _tarefaRepository.AdicionarTarefaAsync(tarefa);
            return CreatedAtAction(nameof(ObterTarefaPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa(Guid id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id)
                return BadRequest();

            await _tarefaRepository.AtualizarTarefaAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTarefa(Guid id)
        {
            await _tarefaRepository.RemoverTarefaAsync(id);
            return NoContent();
        }
    }
}
