using ServicoCepAtividade.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoCepAtividade.Repository
{
    public interface ICepRepository
    {
        Task AddCepAsync(Cep cep);
        Task<List<Cep>> GetAllCepsAsync();
        Task<Cep?> GetCepByCodeAsync(string cep);
    }
}
