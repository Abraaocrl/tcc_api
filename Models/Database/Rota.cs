using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_API.Models.Database
{
    public class Rota : BaseTable
    {
        public long? IdRotaParadaOrigem { get; set; }

        public long? IdRotaParadaDestino { get; set; }

        [ForeignKey("Carro")]
        public long IdCarro { get; set; }

        public Carro? Carro { get; set; }

        [JsonIgnore]
        public virtual ICollection<RotaParada>? Paradas { get; set; }
    }
}
