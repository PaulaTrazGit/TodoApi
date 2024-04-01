using System.Threading.Tasks;

namespace TodoApi.Backend.Repositories
{
    public interface IAutenticacaoRepository
    {
        Task<string> GerarTokenJwtAsync(string login, string senha);
        Task<bool> ValidarTokenJwtAsync(string token);
    }
}
