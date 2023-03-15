using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TCC_API.Models.Database
{
    public class User : BaseTable
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
