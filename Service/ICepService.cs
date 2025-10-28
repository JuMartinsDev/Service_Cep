using ServicoCepAtividade.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoCepAtividade.Service
{
    public interface ICepService
    {
        Task<Cep> ConsultarCepAsync(string cep);
        Task<List<Cep>> GetAllCepsAsync();
    }
}
