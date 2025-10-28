using ServicoCepAtividade.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoCepAtividade.Repository
{
    public class CepRepository : ICepRepository
    {
        private readonly CepDbContext _context;

        public CepRepository(CepDbContext context)
        {
            _context = context;
        }

        public async Task AddCepAsync(Cep cep)
        {
            _context.Ceps.Add(cep);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cep>> GetAllCepsAsync()
        {
            return await _context.Ceps.ToListAsync();
        }

        public async Task<Cep?> GetCepByCodeAsync(string cep)
        {
            return await _context.Ceps.FirstOrDefaultAsync(c => c.CepCode == cep);
        }
    }
}
