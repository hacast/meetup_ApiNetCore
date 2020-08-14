using System;
using System.Collections.Generic;

namespace Birras.Core.Entities
{
    public partial class Reunion
    {
        public int Id { get; set; }
        public int IdUsuarioCreador { get; set; }
        public DateTime FechaReunion { get; set; }
        public int Temperatura { get; set; }
        public int Birras { get; set; }
    }
}
