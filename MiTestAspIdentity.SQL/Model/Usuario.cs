using System.ComponentModel.DataAnnotations;

namespace MiTestAspIdentity.SQL.Model
{
    public class Usuario: Microsoft.AspNetCore.Identity.IdentityUser
    {
        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(200)]
        [Required]
        public string Apellido { get; set; }
    }
}
