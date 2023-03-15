using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_API.Models.Database
{
    public class Carro : BaseTable
    {
        [Required]
        public string Placa { get; set; }

        public int Passageiros { get; set; }

        [ForeignKey("Motorista")]
        public long IdMotorista { get; set; }
        public Motorista? Motorista { get; set; }
    }
}
