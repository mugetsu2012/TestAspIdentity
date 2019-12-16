using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiTestAspIdentity.Web.Model
{
    public class GuardarUsuarioDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Password { get; set; }
    }
}
