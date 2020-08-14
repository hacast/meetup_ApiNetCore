using System;

namespace Birras.Core.Entities
{
    public class Meet
    {
        public int Id { get; set; }
        public int IdUsuarioCreador { get; set; }
        public DateTime FechaReunion {get;set;}
        public int Temperatura { get; set; }
        public int Birras { get; set; }

    }
}
