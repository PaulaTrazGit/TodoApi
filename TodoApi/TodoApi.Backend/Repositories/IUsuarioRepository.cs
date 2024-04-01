using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Backend.Models;

namespace TodoApi.Backend.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync();
        Task<Usuario> ObterUsuarioPorIdAsync(Guid id);
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task AtualizarUsuarioAsync(Usuario usuario);
        Task RemoverUsuarioAsync(Guid id);
    }
}
