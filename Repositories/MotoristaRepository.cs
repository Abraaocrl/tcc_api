using Mapster;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Repositories.Interfaces;

namespace TCC_API.Repositories
{
    public class MotoristaRepository : IRepositoryBase<Motorista>
    {
        private readonly AppDbContext _dbContext;

        public MotoristaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Motorista>> Get()
        {
            return await _dbContext.Motoristas.ToListAsync();
        }

        public async Task<Motorista> GetById(long id)
        {
            var motorista = await _dbContext.Motoristas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);

            return motorista;
        }

        public async Task<Motorista> GetByDocumento(string documento)
        {
            var motorista = await _dbContext.Motoristas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Documento == documento);

            return motorista;
        }

        public async Task<Motorista> Create(Motorista motorista)
        {
            var motoristaExistente = await GetByDocumento(motorista.Documento);
            if (motoristaExistente != null)
                throw new ArgumentException("Documento já cadastrado.");

            motorista.DataNascimento = motorista.DataNascimento.Date;
            motorista.DataCriacao = DateTime.Now;
            motorista.DataEdicao = null;

            var resultado = _dbContext.Motoristas.Add(motorista).Entity;
            _dbContext.SaveChanges();

            return resultado;
        }

        public async Task<Motorista> Update(Motorista motorista)
        {
            var motoristaExistente = await GetByDocumento(motorista.Documento);
            if (motoristaExistente.Id != motorista.Id)
                throw new ArgumentException("Documento já cadastrado.");

            var motoristaDb = await GetById(motorista.Id);

            if (motoristaDb == null)
                throw new ArgumentException("Motorista não encontrado.");

            motoristaDb = motorista.Adapt<Motorista>();

            motoristaDb.DataEdicao = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return motoristaDb;
        }

        public async Task<bool> Delete(long id)
        {
            var motorista = await GetById(id);

            if (motorista == null)
                return false;

            _dbContext.Motoristas.Remove(motorista);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
