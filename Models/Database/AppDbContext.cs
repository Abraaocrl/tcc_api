using Microsoft.EntityFrameworkCore;

namespace TCC_API.Models.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Carro> Carros { get; set; }
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

            builder.Entity<User>().HasData(
                new User() { Nome = "Abraão", Sobrenome = "Costa", Id = 1, Email = "abraaocrl@email.com.br", Username = "abraaocrl", Senha = "827CCB0EEA8A706C4C34A16891F84E7B", DataCriacao = DateTime.MinValue }
                );

            builder.Entity<Motorista>().HasData(
                new Motorista() { Id = 1, IdUsuario = 1, DataCriacao = DateTime.MinValue, Nome = "Abraão Costa", Documento = "123.123.123-12", DataNascimento = new DateTime(1998, 11, 27) }
                );

            builder.Entity<Carro>().HasData(
                new Carro() { Id = 1, IdMotorista = 1, Passageiros = 10, Placa = "HWI8828", DataCriacao = DateTime.MinValue }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=tcc_db;Username=postgres;Password=12345");
    }
}
