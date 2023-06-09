using TCC_API.Models.Database;

namespace TCC_API.Services.Interfaces
{
    public interface IRotaParadaService : IServiceBase<RotaParada>
    {
        Task<IEnumerable<RotaParada>> CreateMultiple(IEnumerable<RotaParada> list);

        Task<IEnumerable<RotaParada>> GetParadasRotas(long idRota);
    }
}
