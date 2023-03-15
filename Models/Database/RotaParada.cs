using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_API.Models.Database
{
    public class RotaParada : BaseTable
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [ForeignKey("Cidade")]
        public long IdCidade { get; set; }

        public Cidade? Cidade { get; set; }

        [ForeignKey("Carro")]
        public long IdCarro { get; set; }

        public Carro? Carro { get; set; }

        [ForeignKey("Rota")]
        public long IdRota { get; set; }

        public Rota? Rota { get; set; }
    }
}
