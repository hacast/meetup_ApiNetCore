using System;
using System.Collections.Generic;

namespace Birras.Core.Entities
{
    public partial class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int IdReunion { get; set; }
        public int IdUsuario { get; set; }
        public string Aceptada { get; set; }
        public string Cumplida { get; set; }
    }
}
