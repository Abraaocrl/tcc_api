using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_API.Models.Database
{
    public class RotaParadaHorario : BaseTable
    {
        public DateTime Horario { get; set; }

        [ForeignKey("RotaParada")]
        public long IdRotaParada { get; set; }
        public RotaParada? RotaParada { get; set; }
    }
}
