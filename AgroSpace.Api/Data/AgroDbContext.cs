using AgroSpace.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroSpace.Api.Data
{
    public class AgroDbContext : DbContext
    {
        // Construtor
        public AgroDbContext(DbContextOptions<AgroDbContext> options) : base(options)
        {
        }

        // Mapeamento
        public DbSet<Local> Locais { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
    }
}