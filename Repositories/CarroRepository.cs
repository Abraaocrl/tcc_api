using Mapster;
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

        public async Task<Carro> Create(Carro model)
        {
            model.DataCriacao = DateTime.Now;
            model.DataEdicao = null;

            var resultado = _dbContext.Carros.Add(model).Entity;
            await _dbContext.SaveChangesAsync();

            return resultado;
        }

        public async Task<bool> Delete(long id)
        {
            var carro = await this.GetById(id);

            if (carro == null)
                return false;

            _dbContext.Carros.Remove(carro);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<Carro>> Get()
        {
            return await _dbContext.Carros.Include(x => x.Motorista).ToListAsync();
        }

        public async Task<Carro> GetById(long id)
        {
            var carro = await _dbContext.Carros.FirstOrDefaultAsync(x => x.Id == id);

            return carro;
        }

        public async Task<Carro> GetByPlaca(string placa)
        {
            var carro = await _dbContext.Carros.FirstOrDefaultAsync(x => x.Placa == placa);

            return carro;
        }

        public async Task<Carro> Update(Carro model)
        {
            var carroDb = await this.GetById(model.Id);

            carroDb = model.Adapt<Carro>();

            carroDb.DataEdicao = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return carroDb;
        }
    }
}
