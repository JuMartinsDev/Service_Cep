using Microsoft.EntityFrameworkCore;
using ServicoCepAtividade.Domain;

namespace ServicoCepAtividade.Repository
{
    public class CepDbContext : DbContext
    {
        public CepDbContext(DbContextOptions<CepDbContext> options) : base(options) { }

        public DbSet<Cep> Ceps { get; set; } = null!;
    }
}
