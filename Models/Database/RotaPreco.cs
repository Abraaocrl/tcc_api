using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_API.Models.Database
{
    public class RotaPreco : BaseTable
    {
        [ForeignKey("Rota")]
        [Required]
        public long IdRota { get; set; }

        public Rota? Rota { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        public double Distancia { get; set; }

        [ForeignKey("RotaParadaOrigem")]
        public long? IdRotaParadaOrigem { get; set; }

        public RotaParada? RotaParadaOrigem { get; set; }

        [ForeignKey("RotaParadaDestino")]
        public long? IdRotaParadaDestino { get; set; }

        public RotaParada? RotaParadaDestino { get; set; }


    }
}
