using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Backend.Models;

namespace TodoApi.Backend.Data
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            await Usuarios.AddAsync(usuario);
            await SaveChangesAsync();
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            Usuarios.Update(usuario);
            await SaveChangesAsync();
        }

        public async Task RemoverUsuarioAsync(Guid id)
        {
            var usuario = await Usuarios.FindAsync(id);
            if (usuario != null)
            {
                Usuarios.Remove(usuario);
                await SaveChangesAsync();
            }
        }
    }
}
