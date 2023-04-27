using TCC_API.Models.Database;

namespace TCC_API.Services.Interfaces
{
    public interface IRotaService : IServiceBase<Rota>
    {
        Task<IEnumerable<Rota>> GetRotasByCidadeOrigemCidadeDestino(long idCidadeOrigem, long idCidadeDestino);
    }
}
