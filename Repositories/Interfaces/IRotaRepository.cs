using TCC_API.Models.Database;

namespace TCC_API.Repositories.Interfaces
{
    public interface IRotaRepository : IRepositoryBase<Rota>
    {
        Task<IEnumerable<Rota>> GetRotasByCidadeOrigemCidadeDestino(long idCidadeOrigem, long idCidadeDestino);
    }
}
