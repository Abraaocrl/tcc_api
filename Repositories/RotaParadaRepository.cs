using Mapster;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Repositories.Interfaces;
using static TCC_API.Repositories.RotaParadaRepository;

namespace TCC_API.Repositories
{
    public class RotaParadaRepository : IRepositoryBase<RotaParada>
    {
        private readonly AppDbContext _dbContext;

        public RotaParadaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RotaParada>> Get()
        {
            return await _dbContext.RotaParadas.ToListAsync();
        }

        public async Task<RotaParada> GetById(long id)
        {
            var parada = await _dbContext.RotaParadas.FirstOrDefaultAsync(x => x.Id == id);

            return parada;
        }

        public async Task<RotaParada> Create(RotaParada rotaParada)
        {
            var result = _dbContext.RotaParadas.Add(rotaParada).Entity;

            await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<RotaParada> Update(RotaParada rotaParada)
        {
            var rotaParadaDb = await GetById(rotaParada.Id);
            if(rotaParadaDb == null)
            {
                throw new Exception("Parada não encontrada");
            }

            rotaParadaDb = rotaParada.Adapt<RotaParada>();

            rotaParadaDb.DataEdicao = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return rotaParadaDb;
        }

        public async Task<bool> Delete(long id)
        {
            var parada = await this.GetById(id);

            if (parada == null)
                return false;

            _dbContext.RotaParadas.Remove(parada);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public bool ExistParada(RotaParada rotaParada)
        {
            return _dbContext.RotaParadas.Any(x => x.Latitude == rotaParada.Latitude && x.Longitude == rotaParada.Longitude && x.IdRota == rotaParada.IdRota && x.Id != rotaParada.Id);
        }
    }
}
