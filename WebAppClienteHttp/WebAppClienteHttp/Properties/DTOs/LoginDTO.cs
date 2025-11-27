using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WebAppClienteHttp.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Token { get; set; }

    }
}
