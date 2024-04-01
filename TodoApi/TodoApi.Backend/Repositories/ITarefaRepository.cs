using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Backend.Models;

namespace TodoApi.Backend.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTodasTarefasAsync();
        Task<Tarefa> ObterTarefaPorIdAsync(Guid id);
        Task<IEnumerable<Tarefa>> ObterTarefasDoUsuarioAsync(Guid usuarioId);
        Task AdicionarTarefaAsync(Tarefa tarefa);
        Task AtualizarTarefaAsync(Tarefa tarefa);
        Task RemoverTarefaAsync(Guid id);
    }
}
