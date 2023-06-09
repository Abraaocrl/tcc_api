using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Repositories;
using TCC_API.Repositories.Interfaces;
using TCC_API.Services.Interfaces;

namespace TCC_API.Services
{
    public class RotaParadaService : IRotaParadaService
    {
        private readonly RotaParadaRepository _rotaParadaRepository;

        public RotaParadaService(RotaParadaRepository rotaParadaRepository)
        {
            _rotaParadaRepository = rotaParadaRepository;
        }

        public async Task<RotaParada> Create(RotaParada rotaParada)
        {
            var paradaExistente = _rotaParadaRepository.ExistParada(rotaParada);
            if (paradaExistente)
                throw new Exception("Parada já cadastrada na localização para a rota.");

            return await _rotaParadaRepository.Create(rotaParada);
        }

        public async Task<IEnumerable<RotaParada>> CreateMultiple(IEnumerable<RotaParada> list)
        {
            try
            {
                List<RotaParada> paradasCriadas = new List<RotaParada>();
                foreach (var item in list)
                {
                    var paradaCriada = await Create(item);
                    paradasCriadas.Add(paradaCriada);
                }

                return paradasCriadas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(long id)
        {
            var rotaParadaDb = await _rotaParadaRepository.GetById(id);
            if (rotaParadaDb == null)
                throw new Exception("Parada não encontrada.");

            return await _rotaParadaRepository.Delete(id);
        }

        public async Task<IEnumerable<RotaParada>> Get()
        {
            return await _rotaParadaRepository.Get();
        }

        public async Task<RotaParada> GetById(long id)
        {
            return await _rotaParadaRepository.GetById(id);
        }

        public async Task<IEnumerable<RotaParada>> GetParadasRotas(long idRota)
        {
            return await _rotaParadaRepository.GetByRotaId(idRota);
        }

        public async Task<RotaParada> Update(RotaParada rotaParada)
        {
            var paradaExistente = _rotaParadaRepository.ExistParada(rotaParada);
            if (paradaExistente)
                throw new Exception("Parada já cadastrada na localização para a rota.");

            return await _rotaParadaRepository.Update(rotaParada);
        }
    }
}
