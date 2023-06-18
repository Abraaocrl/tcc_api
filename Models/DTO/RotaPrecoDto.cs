using System.ComponentModel.DataAnnotations.Schema;
using TCC_API.Models.Database;

namespace TCC_API.Models.DTO
{
    public class RotaPrecoDTO
    {
        public long IdRota { get; set; }

        public string? Preco { get; set; }

        public string? Distancia { get; set; }

        public long IdRotaParadaOrigem { get; set; }

        public long IdRotaParadaDestino { get; set; }
    }
}
