using Mapster;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Repositories.Interfaces;

namespace TCC_API.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly AppDbContext _dbContext;

        public RotaRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Rota> Create(Rota model)
        {
            var result = _dbContext.Rotas.Add(model).Entity;

            await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<bool> Delete(long id)
        {
            var parada = await this.GetById(id);

            if (parada == null)
                return false;

            _dbContext.Rotas.Remove(parada);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Rota>> Get()
        {
            return await _dbContext.Rotas.Include(x => x.Paradas).ToListAsync();
        }

        public async Task<Rota> GetById(long id)
        {
            var parada = await _dbContext.Rotas.FirstOrDefaultAsync(x => x.Id == id);

            return parada;
        }

        public async Task<Rota> Update(Rota model)
        {
            var rotaDb = await GetById(model.Id);

            rotaDb = model.Adapt<Rota>();

            rotaDb.DataEdicao = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return rotaDb;
        }

        public async Task<IEnumerable<Rota>> GetRotasByCidadeOrigemCidadeDestino(long idCidadeOrigem, long idCidadeDestino)
        {
            var rotas = await _dbContext.Rotas.Include(x => x.Paradas).Where(x => x.Paradas.Any(y => idCidadeDestino == y.IdCidade) && x.Paradas.Any(y => idCidadeOrigem == y.IdCidade)).ToListAsync();

            return rotas;
        }
    }
}
