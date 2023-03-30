using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Repositories.Interfaces;

namespace TCC_API.Repositories
{
    public class CarroRepository : IRepositoryBase<Carro>
    {
        private readonly AppDbContext _dbContext;

        public CarroRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Carro Create(Carro model)
        {
            var resultado = _dbContext.Carros.Add(model).Entity;
            _dbContext.SaveChanges();

            return resultado;
        }

        public bool Delete(long id)
        {
            var carro = _dbContext.Carros.FirstOrDefault(x => x.Id == id);

            if (carro == null)
                return false;

            _dbContext.Carros.Remove(carro);
            _dbContext.SaveChanges();

            return true;
        }

        public List<Carro> Get()
        {
            return _dbContext.Carros.Include(x => x.Motorista).ToList();
        }

        public Carro GetById(long id)
        {
            var carro = _dbContext.Carros.FirstOrDefault(x => x.Id == id, null);

            if (carro == null)
                throw new Exception();

            return carro;
        }

        public Carro Update(Carro model)
        {
            var carroDb = _dbContext.Carros.FirstOrDefault(x => x.Id == model.Id);

            if (carroDb == null)
                throw new Exception();

            carroDb.Placa = model.Placa;
            carroDb.Passageiros = model.Passageiros;
            carroDb.IdMotorista = model.IdMotorista;
            carroDb.DataEdicao = DateTime.Now;

            _dbContext.SaveChanges();

            return carroDb;
        }
    }
}
