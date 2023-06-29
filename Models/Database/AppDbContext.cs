using Microsoft.EntityFrameworkCore;

namespace TCC_API.Models.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<RotaParada> RotaParadas { get; set; }
        public DbSet<RotaParadaHorario> RotaParadaHorarios { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<RotaPreco> RotaPrecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyUtcDateTimeConverter();

            //Cidades para o banco de dados
            builder.Entity<Cidade>().HasData(
                new Cidade() { Id = 1, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Fortaleza" },
                new Cidade() { Id = 2, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Aracati" },
                new Cidade() { Id = 3, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Aquiraz" },
                new Cidade() { Id = 4, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Acaraú" },
                new Cidade() { Id = 5, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Viçosa do Ceará" },
                new Cidade() { Id = 6, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Antonina do Norte" },
                new Cidade() { Id = 7, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Abaiara" },
                new Cidade() { Id = 8, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Acarape" },
                new Cidade() { Id = 9, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Sobral" },
                new Cidade() { Id = 10, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Crato" },
                new Cidade() { Id = 11, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Juazeiro do Norte" },
                new Cidade() { Id = 12, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Itapipoca" },
                new Cidade() { Id = 13, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Canindé" },
                new Cidade() { Id = 14, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Massapê" },
                new Cidade() { Id = 15, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Martinópole" },
                new Cidade() { Id = 16, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Granja" },
                new Cidade() { Id = 17, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Uruoca" },
                new Cidade() { Id = 18, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Senador Sá" },
                new Cidade() { Id = 19, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Tianguá" },
                new Cidade() { Id = 20, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Frecheirinha" },
                new Cidade() { Id = 21, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "São Benedito" },
                new Cidade() { Id = 22, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Jijoca" },
                new Cidade() { Id = 23, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Cruz" },
                new Cidade() { Id = 24, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Meruoca" },
                new Cidade() { Id = 25, Estado = "CE", DataCriacao = DateTime.MinValue, Nome = "Camocim" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("sua conexao aqui :)");
    }
}
