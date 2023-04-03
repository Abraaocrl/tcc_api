using TCC_API.Models.Database;
using TCC_API.Repositories;
using TCC_API.Repositories.Interfaces;
using TCC_API.Services.Interfaces;

namespace TCC_API.Services
{
    public class MotoristaService : IServiceBase<Motorista>
    {
        private readonly MotoristaRepository _motoristaRepository;

        public MotoristaService(MotoristaRepository motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
        }

        public async Task<IEnumerable<Motorista>> Get()
        {
            return await _motoristaRepository.Get();
        }

        public async Task<Motorista> GetById(long id)
        {
            return await _motoristaRepository.GetById(id);
        }

        public async Task<Motorista> Create(Motorista motorista)
        {
            var motoristaExistente = await _motoristaRepository.GetByDocumento(motorista.Documento);
            if (motoristaExistente != null)
                throw new ArgumentException("Documento já cadastrado.");

            motorista.DataNascimento = motorista.DataNascimento.Date;

            return await _motoristaRepository.Create(motorista);
        }

        public async Task<Motorista> Update(Motorista motorista)
        {
            var motoristaExistente = await _motoristaRepository.GetByDocumento(motorista.Documento);
            if (motoristaExistente.Id != motorista.Id)
                throw new ArgumentException("Documento já cadastrado.");

            return await _motoristaRepository.Update(motorista);
        }

        public async Task<bool> Delete(long id)
        {
            return await _motoristaRepository.Delete(id);
        }

    }
}
