using Microsoft.Build.Framework;

namespace TCC_API.Models.Database
{
    public class Cidade : BaseTable
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Estado { get; set; }
    }
}
