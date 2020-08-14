using System;
using System.Collections.Generic;

namespace Birras.Core.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
    }
}
