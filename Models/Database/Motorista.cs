using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TCC_API.Models.Database
{
    public class Motorista : BaseTable
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public DateTime DataNascimento { get; set; }

        [ForeignKey("Usuario")]
        public long IdUsuario { get; set; }        
        public User? Usuario { get; set; }
    }
}
