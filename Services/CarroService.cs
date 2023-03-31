using TCC_API.Models.Database;
using TCC_API.Repositories;
using TCC_API.Repositories.Interfaces;
using TCC_API.Services.Interfaces;

namespace TCC_API.Services
{
    public class CarroService : IServiceBase<Carro>
    {
        private readonly CarroRepository _repository;

        public CarroService(CarroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Carro> Create(Carro model)
        {
            var carroExistente = await _repository.GetByPlaca(model.Placa);
            if(carroExistente != null) {
                throw new Exception("Placa já cadastrada!");
            }

            var carro = await _repository.Create(model);

            return carro;
        }

        public async Task<bool> Delete(long id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Carro>> Get()
        {
            var carros = await _repository.Get();

            return carros;
        }

        public async Task<Carro> GetById(long id)
        {
            var carros = await _repository.GetById(id);

            return carros;
        }

        public async Task<Carro> Update(Carro model)
        {
            var carroExistente = await _repository.GetByPlaca(model.Placa);
            if (carroExistente != null && carroExistente.Id != model.Id)
            {
                throw new Exception("Placa já cadastrada!");
            }

            var carroAtualizado = await _repository.Update(model);

            return carroAtualizado;
        }
    }
}
