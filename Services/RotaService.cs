using TCC_API.Models.Database;
using TCC_API.Repositories.Interfaces;
using TCC_API.Services.Interfaces;

namespace TCC_API.Services
{
    public class RotaService : IRotaService
    {
        private IRotaRepository _rotaRepository { get; set; }

        public RotaService(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }

        public async Task<Rota> Create(Rota model)
        {
            return await _rotaRepository.Create(model);
        }

        public async Task<bool> Delete(long id)
        {
            return await _rotaRepository.Delete(id);
        }

        public async Task<IEnumerable<Rota>> Get()
        {
            return await _rotaRepository.Get();
        }

        public async Task<Rota> GetById(long id)
        {
            return await _rotaRepository.GetById(id);
        }

        public async Task<IEnumerable<Rota>> GetRotasByCidadeOrigemCidadeDestino(long idCidadeOrigem, long idCidadeDestino)
        {
            return await _rotaRepository.GetRotasByCidadeOrigemCidadeDestino(idCidadeOrigem,idCidadeDestino);
        }

        public async Task<Rota> Update(Rota model)
        {
            return await _rotaRepository.Update(model);
        }

    }
}