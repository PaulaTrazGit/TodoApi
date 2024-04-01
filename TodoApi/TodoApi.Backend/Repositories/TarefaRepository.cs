using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Backend.Data;
using TodoApi.Backend.Models;

namespace TodoApi.Backend.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly InMemoryDbContext _context;

        public TarefaRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ObterTodasTarefasAsync()
        {
            return _context.Tarefas.ToList();
        }

        public async Task<Tarefa> ObterTarefaPorIdAsync(Guid id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasDoUsuarioAsync(Guid usuarioId)
        {
            return _context.Tarefas.Where(t => t.UsuarioId == usuarioId).ToList();
        }

        public async Task AdicionarTarefaAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverTarefaAsync(Guid id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
