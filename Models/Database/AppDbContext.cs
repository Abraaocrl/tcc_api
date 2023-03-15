using Microsoft.EntityFrameworkCore;

namespace TCC_API.Models.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>  Users { get; set; }
        public DbSet<Motorista>  Motoristas { get; set; }
        public DbSet<Carro>  Carros { get; set; }
        public DbSet<Cidade>  Cidades { get; set; }
        public DbSet<RotaParada>  RotaParadas { get; set; }
        public DbSet<RotaParadaHorario>  RotaParadaHorarios { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<RotaPreco> RotaPrecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyUtcDateTimeConverter();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=tcc_db;Username=postgres;Password=12345");
    }
}
